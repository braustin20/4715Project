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
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Ship"){
			Debug.Log(transform.up.normalized);
			if(transform.up.normalized.y != 0.0f){
				Rigidbody playerRigidbody = other.transform.parent.rigidbody;
				playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, 0, playerRigidbody.velocity.z);
				other.transform.parent.rigidbody.AddForce(this.transform.up * 20.0f);
			}
			if(transform.up.normalized.x != 0.0f){
				Rigidbody playerRigidbody = other.transform.parent.rigidbody;
				playerRigidbody.velocity = new Vector3(0, playerRigidbody.velocity.x, playerRigidbody.velocity.z);
				other.transform.parent.rigidbody.AddForce(this.transform.up * 20.0f);
			}
		}
	}
}
