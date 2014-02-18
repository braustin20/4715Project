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
		if(other.gameObject.tag == "Player"){
			other.transform.parent.rigidbody.AddForce(this.transform.up * 10.0f);

			//other.rigidbody.AddForce(this.transform.forward * 10.0f);
		}
	}
}
