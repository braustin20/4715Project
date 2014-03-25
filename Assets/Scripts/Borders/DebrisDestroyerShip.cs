using UnityEngine;
using System.Collections;

public class DebrisDestroyerShip: MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		//If the player has hit this border, reload the level
		if(other.tag == "Debris"){
			other.gameObject.GetComponent<DebrisLevel1>().destroyDebris();
		}
	}

}
