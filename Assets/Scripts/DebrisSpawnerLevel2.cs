using UnityEngine;
using System.Collections;

public class DebrisSpawnerLevel2: MonoBehaviour {
	public GameObject[] debris;
	public int maxDebris = 5;
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
		int randomSize = Random.Range(0, (debris.Length));

		//Fill the array of debris
		for(int i = 0; i < maxDebris; i++){
			//Pick a debris prefab from the list made in the inspector
			randomSize = Random.Range(0, (debris.Length));

			//Instantiate and add a debris object to the array of alive debris
			aliveDebris.Add(GameObject.Instantiate(debris[randomSize], this.transform.position, this.transform.rotation) as GameObject);

			GameObject tempDebris = (GameObject) aliveDebris[i];
			//Randomly find a point within the bounding area to place this debris
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
		}
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		Debug.Log(aliveDebris.Count);
		if(aliveDebris.Count < 20 && timer >= spawnInterval){
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
	}
	public void removeFromList(GameObject debris){
		aliveDebris.Remove(debris);
		spawnDebris();
	}
}
