using UnityEngine;
using System.Collections;

public class InteriorControls : MonoBehaviour {

	private GameObject OVRCamera;
	private GameObject FPSCamera;
	private GameManager gameManager;
	private bool oculusEnabled;
	private bool allowJetpack;

	public float moveSpeed = 1.0f;
	public float maxSpeed = 7.0f;
	public float jumpForce = 500.0f;

	private float currentSpeed;

	// Use this for initialization
	void Start () {
		allowJetpack = true;

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
		if(Input.GetKey(KeyCode.W) && allowJetpack){
			if(oculusEnabled){
				rigidbody.AddForce(OVRCamera.transform.forward * moveSpeed);
			}
			else{
				rigidbody.AddForce(FPSCamera.transform.forward * moveSpeed);
			}
		}
		if(Input.GetKey(KeyCode.S) && allowJetpack){
			if(oculusEnabled){
				rigidbody.AddForce(-OVRCamera.transform.forward * moveSpeed);
			}
			else{
				rigidbody.AddForce(-FPSCamera.transform.forward * moveSpeed);
			}
		}
		if(Input.GetKey(KeyCode.A) && allowJetpack){
			if(oculusEnabled){
				rigidbody.AddForce(-OVRCamera.transform.right * moveSpeed);
			}
			else{
				rigidbody.AddForce(-FPSCamera.transform.right * moveSpeed);
			}
		}
		if(Input.GetKey(KeyCode.D) && allowJetpack){
			if(oculusEnabled){
				rigidbody.AddForce(OVRCamera.transform.right * moveSpeed);
			}
			else{
				rigidbody.AddForce(FPSCamera.transform.right * moveSpeed);
			}
		}
		if(Input.GetKey(KeyCode.E) && allowJetpack){
			if(oculusEnabled){
				rigidbody.AddForce(OVRCamera.transform.up * moveSpeed);
			}
			else{
				rigidbody.AddForce(FPSCamera.transform.up * moveSpeed);
			}
		}
		if(Input.GetKey(KeyCode.Q) && allowJetpack){
			if(oculusEnabled){
				rigidbody.AddForce(-OVRCamera.transform.up * moveSpeed);
			}
			else{
				rigidbody.AddForce(-FPSCamera.transform.up * moveSpeed);
			}
		}
		if(Input.GetKeyDown(KeyCode.Space) && !allowJetpack){
			if(oculusEnabled){
				rigidbody.AddForce(OVRCamera.transform.forward * jumpForce);
			}
			else{
				rigidbody.AddForce(FPSCamera.transform.forward * jumpForce);
			}
			allowJetpack = true;
		}
	}
	void FixedUpdate() {
		Vector3 tempVelocity = rigidbody.velocity;
		//If we exceed the maximum speed, determine velocity direction and lock it
		if(tempVelocity.magnitude > maxSpeed){
			rigidbody.velocity = tempVelocity.normalized * maxSpeed;
		}   
	}
	void OnTriggerEnter(Collider other){
		if(other.collider.gameObject.tag == "GrappleObj"){
			resetVelocity();
			allowJetpack = false;
		}
	}
	public void resetVelocity(){
		rigidbody.velocity = new Vector3(0,0,0);
	}
	public float getCurrentSpeed(){
		return currentSpeed;
	}
}
