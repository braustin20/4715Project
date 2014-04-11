using UnityEngine;
using System.Collections;

public class HelmetRotate : MonoBehaviour {
	public GameObject trackingReference;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//this.transform.rotation = trackingReference.transform.rotation;
	/*	this.transform.rotation = new Quaternion(trackingReference.transform.rotation.x,
		                                         this.transform.rotation.y,
		                                         trackingReference.transform.rotation.z,
		                                         trackingReference.transform.rotation.w);*/
		/*
		this.transform.RotateAround(trackingReference.transform.position, 
		                            this.transform.right, 
		                            trackingReference.transform.rotation.x);
		                            */
		//this.transform.LookAt(trackingReference.transform);
	}
}
