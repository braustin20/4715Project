using UnityEngine;
using System.Collections;

public class Debris : MonoBehaviour {
	public GameObject explosionEffect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			GameObject.Instantiate(explosionEffect, this.transform.position, this.transform.rotation);
			GameObject.Destroy(this.gameObject);
		}
	}
}
