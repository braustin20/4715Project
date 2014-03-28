using UnityEngine;
using System.Collections;

public class RotatingDebris: MonoBehaviour {
	public GameObject explosionEffect;
	private GameObject spawner;
	public float rotationVelocity = 500000.0f;
	//public float moveVelocity = 300000.0f;

	// Use this for initialization
	void Start () {
		float randomX = Random.Range(-rotationVelocity, rotationVelocity);
		Debug.Log ("Random X: " + randomX);
		float randomY = Random.Range(-rotationVelocity, rotationVelocity);
		Debug.Log ("Random Y: " + randomY);
		float randomZ = Random.Range(-rotationVelocity, rotationVelocity);
		Debug.Log ("Random Z: " + randomZ);



		rigidbody.
		rigidbody.AddRelativeTorque(randomX, randomY, randomZ);
		//rigidbody.AddForce(transform.forward * moveVelocity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		//If this debris collided with the ship explode and destroy this debris
		if(other.gameObject.tag == "Ship" || other.gameObject.tag == "Player"){
			//Place the explosion in front of the ship by 3 units
			GameObject.Instantiate(explosionEffect, other.transform.position + Vector3.forward * 3, this.transform.rotation);
			GameObject.Destroy(this.gameObject);
			GameObject.Find("OVRCharacterFlying").GetComponent<FlyingControls>().damagePlayer();
		}
	}
	public void destroyDebris(){
		//spawner.GetComponent<DebrisSpawner>().removeFromList(this.gameObject);
	}
	public void setSpawner(GameObject sp){
		//spawner = sp;
	}
}
