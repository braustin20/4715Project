using UnityEngine;
using System.Collections;

public class Border : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider other){

		//Only act if the player or their ship has touched the border
		if(other.gameObject.tag == "Ship"){
			//Push the player along the y axis if this is a top or bottom border
			if(transform.up.normalized.y != 0.0f){
				if(transform.up.normalized.y > 0.0f){
					Rigidbody playerRigidbody = other.transform.parent.rigidbody;
					playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, 80.0f, playerRigidbody.velocity.z);
					//other.transform.parent.rigidbody.AddForce(this.transform.up * 20.0f);
				}
				if(transform.up.normalized.y < 0.0f){
					Rigidbody playerRigidbody = other.transform.parent.rigidbody;
					playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, -80.0f, playerRigidbody.velocity.z);
				}
			}
			//Push the player along the x axis if this is a left or right border
			if(transform.up.normalized.x != 0.0f){
				if(transform.up.normalized.x > 0.0f){
					Rigidbody playerRigidbody = other.transform.parent.rigidbody;
					playerRigidbody.velocity = new Vector3(80.0f, playerRigidbody.velocity.y, playerRigidbody.velocity.z);
					//other.transform.parent.rigidbody.AddForce(this.transform.up * 20.0f);
				}
				if(transform.up.normalized.x < 0.0f){
					Rigidbody playerRigidbody = other.transform.parent.rigidbody;
					playerRigidbody.velocity = new Vector3(-80.0f, playerRigidbody.velocity.y, playerRigidbody.velocity.z);
				}
			//	Rigidbody playerRigidbody = other.transform.parent.rigidbody;
			//	playerRigidbody.velocity = new Vector3(30, playerRigidbody.velocity.y, playerRigidbody.velocity.z);
				//other.transform.parent.rigidbody.AddForce(this.transform.up * 20.0f);
			}
		}
	}
}
