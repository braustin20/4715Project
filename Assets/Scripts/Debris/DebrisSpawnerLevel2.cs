using UnityEngine;
using System.Collections;

public class DebrisSpawnerLevel2: MonoBehaviour {
	public GameObject[] debris;
	public int maxDebris = 20;
	public float debrisScale = 0.5f;
	public float rotationVelocity = 20.0f;
	public float velocity = 4000.0f;
	public float spawnInterval = 1.0f;

	private float timer = 0.0f;
	private Vector3 spawnPosition;

	private ArrayList aliveDebris = new ArrayList();

	// Use this for initialization
	void Start () {
		spawnPosition = this.transform.position;
		spawnDebris();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(aliveDebris.Count < maxDebris && timer >= spawnInterval){
			timer = 0.0f;
			spawnDebris();
		}

	}
	private void spawnDebris(){
		int randomSize = Random.Range(0, (debris.Length));

		GameObject tempDebris = GameObject.Instantiate(debris[randomSize], this.transform.position, this.transform.rotation) as GameObject;
		aliveDebris.Add(tempDebris);

		tempDebris.transform.position = new Vector3(
			spawnPosition.x + (Random.Range(-5.0f, 5.0f)), 
			spawnPosition.y + (Random.Range(-5.0f, 5.0f)), 
			spawnPosition.z + (0.0f));
		//Push the debris towards the player
		//Apply a set force, but control speed by rigidbody weight in the inspector
		tempDebris.rigidbody.AddForce(transform.forward * velocity);
		//Make the debris spin and flip at a random speed
		
		tempDebris.rigidbody.AddTorque(Random.Range(-rotationVelocity, rotationVelocity),
		                               Random.Range(-rotationVelocity, rotationVelocity),
		                               Random.Range(-rotationVelocity, rotationVelocity));
		//Resize the debris to make it a challenge
		tempDebris.transform.localScale = new Vector3(debrisScale, debrisScale, debrisScale);
		tempDebris.GetComponent<DebrisLevel2>().setSpawner(this.gameObject);
	}
	public void removeFromList(GameObject debris){
		aliveDebris.Remove(debris);
		spawnDebris();
	}
}
