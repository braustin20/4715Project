using UnityEngine;
using System.Collections;

public class DebrisDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		//If debris has touched the collider, destroy and respawn it
		if(other.tag == "Debris"){
			other.gameObject.GetComponent<DebrisLevel2>().setAllowDestroy(true);
		}
	}

}
