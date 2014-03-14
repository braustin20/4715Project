using UnityEngine;
using System.Collections;

public class DebrisSpawner : MonoBehaviour {
	public GameObject[] debris;
	public int maxDebris = 20;
	public float debrisScale = 3.0f;
	public float rotationVelocity = 20.0f;

	private GameObject[] aliveDebris;
	private GameObject player;

	// Use this for initialization
	void Start () {
		//Find the player
		player = GameObject.FindGameObjectWithTag("Player");
		//Create an array with a capacity to hold our set max debris number
		aliveDebris = new GameObject[maxDebris];

		//Fill the array of debris
		for(int i = 0; i < maxDebris; i++){
			//Pick a debris prefab from the list made in the inspector
			int randomSize = Random.Range(0, (debris.Length));

			//Instantiate and add a debris object to the array of alive debris
			aliveDebris[i] = GameObject.Instantiate(debris[randomSize]) as GameObject;
			//Create a temporary value to store the player's position
			//Move this debris relative to the player
			Vector3 tempPosition = player.transform.position;
			//Randomly find a point within the bounding area to place this debris
			aliveDebris[i].transform.position = new Vector3(
				tempPosition.x + (Random.Range(-150.0f, 150.0f)), 
				tempPosition.y + (Random.Range(-75.0f, 75.0f)), 
				tempPosition.z + (100 + Random.Range(0.0f, 400.0f)));
			//Push the debris towards the player
			//Apply a set force, but control speed by rigidbody weight in the inspector
			aliveDebris[i].rigidbody.AddForce(0, 0, -1000.0f);
			//Make the debris spin and flip at a random speed

			aliveDebris[i].rigidbody.AddTorque(Random.Range(-rotationVelocity, rotationVelocity),
			                                   Random.Range(-rotationVelocity, rotationVelocity),
			                                   Random.Range(-rotationVelocity, rotationVelocity));
			//Resize the debris to make it a challenge
			aliveDebris[i].transform.localScale = new Vector3(debrisScale, debrisScale, debrisScale);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
