using UnityEngine;
using System.Collections;

public class DebrisLevel2: MonoBehaviour {
	public GameObject explosionEffect;
	public float killTime = 2.0f;
	private float timer = 0.0f;
	private GameObject spawner;
	private bool allowDestroy = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(allowDestroy){
			timer += Time.deltaTime;
			if(timer >= killTime){
				spawner.GetComponent<DebrisSpawnerLevel2>().removeFromList(this.gameObject);
				GameObject.Destroy(this.gameObject);
			}
		}
	}
	void OnTriggerEnter(Collider other){
		//If this debris collided with the ship explode and destroy this debris
		if(other.gameObject.tag == "Ship" || other.gameObject.tag == "Player"){
			//Place the explosion in front of the ship by 3 units
			GameObject.Instantiate(explosionEffect, other.transform.position + Vector3.forward * 1, this.transform.rotation);
			GameObject.Destroy(this.gameObject);
			GameObject.Find("OVRCharacterFloating").GetComponent<FloatingControls>().damagePlayer();
		}
	}
	public void setSpawner(GameObject sp){
		spawner = sp;
	}
	public void setAllowDestroy(bool allow){
		allowDestroy = allow;
	}
}
