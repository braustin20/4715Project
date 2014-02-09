using UnityEngine;
using System.Collections;

public class FloatingControls : MonoBehaviour {

	private GameObject OVRCamera;
	private GameObject FPSCamera;
	private GameManager gameManager;
	private bool oculusEnabled;

	public float moveSpeed = 1.0f;
	public float maxSpeed = 1.0f;

	private float currentSpeed;

	// Use this for initialization
	void Start () {
		//Find and store the camera objects and manager
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		OVRCamera = gameManager.getOVRCamera();
		FPSCamera = gameManager.getFPSCamera();
	}
	
	// Update is called once per frame
	void Update () {
		//Detect the player's current speed
		currentSpeed = rigidbody.velocity.magnitude;

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
		if(Input.GetKey(KeyCode.S)){
			if(oculusEnabled){
				rigidbody.AddForce(-OVRCamera.transform.forward * moveSpeed);
			}
			else{
				rigidbody.AddForce(-FPSCamera.transform.forward * moveSpeed);
			}
		}
		if(Input.GetKey(KeyCode.A)){
			if(oculusEnabled){
				rigidbody.AddForce(-OVRCamera.transform.right * moveSpeed);
			}
			else{
				rigidbody.AddForce(-FPSCamera.transform.right * moveSpeed);
			}
		}
		if(Input.GetKey(KeyCode.D)){
			if(oculusEnabled){
				rigidbody.AddForce(OVRCamera.transform.right * moveSpeed);
			}
			else{
				rigidbody.AddForce(FPSCamera.transform.right * moveSpeed);
			}
		}
		if(Input.GetKey(KeyCode.E)){
			if(oculusEnabled){
				rigidbody.AddForce(OVRCamera.transform.up * moveSpeed);
			}
			else{
				rigidbody.AddForce(FPSCamera.transform.up * moveSpeed);
			}
		}
		if(Input.GetKey(KeyCode.Q)){
			if(oculusEnabled){
				rigidbody.AddForce(-OVRCamera.transform.up * moveSpeed);
			}
			else{
				rigidbody.AddForce(-FPSCamera.transform.up * moveSpeed);
			}
		}
	}
	void FixedUpdate() {
		Vector3 tempVelocity = rigidbody.velocity;
		//If we exceed the maximum speed, determine velocity direction and lock it
		if(tempVelocity.magnitude > maxSpeed){
			rigidbody.velocity = tempVelocity.normalized * maxSpeed;
		}   
	}
	public float getCurrentSpeed(){
		return currentSpeed;
	}
}
