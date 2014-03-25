using UnityEngine;
using System.Collections;

public class DebrisSpawner : MonoBehaviour {
	public GameObject[] debris;
	public int maxDebris = 200;
	public float debrisScale = 10.0f;
	public float rotationVelocity = 20.0f;
	public float velocity = -40000.0f;

	//private GameObject[] aliveDebris;
	private ArrayList aliveDebris = new ArrayList();
	private GameObject player;

	// Use this for initialization
	void Start () {
		//Find the player
		player = GameObject.FindGameObjectWithTag("Player");
		//Create an array with a capacity to hold our set max debris number
//		aliveDebris = new GameObject[maxDebris];

		//Fill the array of debris
		for(int i = 0; i <= maxDebris; i++){
			spawnDebris(7000.0f);
		}
	}
	private void spawnDebris(float offset){
		int randomSize = Random.Range(0, (debris.Length));
		
		GameObject tempDebris = GameObject.Instantiate(debris[randomSize], this.transform.position, this.transform.rotation) as GameObject;
		aliveDebris.Add(tempDebris);

		Vector3 spawnPosition = player.transform.position;

		tempDebris.transform.position = new Vector3(
			spawnPosition.x + (Random.Range(-450.0f, 450.0f)), 
			spawnPosition.y + (Random.Range(-375.0f, 375.0f)), 
			spawnPosition.z + (offset + Random.Range(0.0f, 5000.0f)));
		//Push the debris towards the player
		//Apply a set force, but control speed by rigidbody weight in the inspector
		tempDebris.rigidbody.AddForce(transform.forward * velocity);
		//Make the debris spin and flip at a random speed
		
		tempDebris.rigidbody.AddTorque(Random.Range(-rotationVelocity, rotationVelocity),
		                               Random.Range(-rotationVelocity, rotationVelocity),
		                               Random.Range(-rotationVelocity, rotationVelocity));
		//Resize the debris to make it a challenge
		tempDebris.transform.localScale = new Vector3(debrisScale, debrisScale, debrisScale);
		tempDebris.GetComponent<DebrisLevel1>().setSpawner(this.gameObject);
	}
	// Update is called once per frame
	void Update () {
	}
	public void removeFromList(GameObject debris){
		aliveDebris.Remove(debris);
		GameObject.Destroy(debris);
		spawnDebris(5000.0f);
	}
}
