using UnityEngine;
using System.Collections;

public class LaserChargeTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Ship"){
			Debug.Log("Laser Charging");
			GameObject.Find("ChargeUpParticle").GetComponent<ParticleEmitter>().emit = true;
			GameObject.Find("ChargeUpParticle").GetComponent<Light>().enabled = true;
		}
	}
}
