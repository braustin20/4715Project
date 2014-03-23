using UnityEngine;
using System.Collections;

public class DebrisLevel2: MonoBehaviour {
	public GameObject explosionEffect;
	public float killTime = 1.0f;
	private float timer = 0.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer >= killTime){
			Debug.Log("Destroying myself");
			GameObject.Destroy(this);
		}
	}
	void OnTriggerEnter(Collider other){
		//If this debris collided with the ship explode and destroy this debris
		if(other.gameObject.tag == "Ship" || other.gameObject.tag == "Player"){
			//Place the explosion in front of the ship by 3 units
			GameObject.Instantiate(explosionEffect, other.transform.position + Vector3.forward * 3, this.transform.rotation);
			GameObject.Destroy(this.gameObject);
		}
	}
}
