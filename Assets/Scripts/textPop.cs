using UnityEngine;
using System.Collections;

public class textPop : MonoBehaviour {

	// Use this for initialization
	void Start () {
		foreach (Renderer r in this.GetComponentsInChildren(typeof(Renderer)))
			
		{
			r.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		foreach (Renderer r in this.GetComponentsInChildren(typeof(Renderer)))
			
		{
			r.enabled = true;
		}
	}

	void OnTriggerExit(Collider other){
		foreach (Renderer r in this.GetComponentsInChildren(typeof(Renderer)))
			
		{
			r.enabled = false;
		}
	}
}
