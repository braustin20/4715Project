using UnityEngine;
using System.Collections;

public class FloatingControls : MonoBehaviour {

	private GameObject OVRCamera;
	private GameObject FPSCamera;
	private GameManager gameManager;
	private bool oculusEnabled;

	public float moveSpeed = 2.0f;

	// Use this for initialization
	void Start () {
		//Find and store the camera objects and manager
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		OVRCamera = gameManager.getOVRCamera();
		FPSCamera = gameManager.getFPSCamera();
	}
	
	// Update is called once per frame
	void Update () {
		//Before any Input is processed, check to see if Oculus is enabled
		oculusEnabled = gameManager.isOculusEnabled();

		//Input grabbing - moves relative to current camera
		if(Input.GetKey(KeyCode.W)){
			if(oculusEnabled){
				rigidbody.AddForce(OVRCamera.transform.forward * moveSpeed);
			}
			else{
				rigidbody.AddForce(FPSCamera.transform.forward * moveSpeed);
			}
		}
	}
}
