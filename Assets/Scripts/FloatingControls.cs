using UnityEngine;
using System.Collections;

public class FloatingControls : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W)){
			rigidbody.AddForce(this.transform.forward);
		}
	}
}
