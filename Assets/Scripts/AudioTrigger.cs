using UnityEngine;
using System.Collections;

public class AudioTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Ship" || other.gameObject.tag == "Player"){
			audio.Play();
		}
	}
}
