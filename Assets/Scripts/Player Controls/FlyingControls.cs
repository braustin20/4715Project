using UnityEngine;
using System.Collections;

public class FlyingControls : MonoBehaviour {

	private GameManager gameManager;
	private bool oculusEnabled;
	private bool allowJetpack;

	public float moveSpeed = 100.0f;
	public float maxSpeed = 100.0f;
	public float minSpeed = 30.0f;

	private int timesHit = 0;
	private bool deathTimerActive;
	private float deathTimer = 0.0f;

	public Material damagedMaterial;
	public Material destroyedMaterial;

	private float currentSpeed;

	// Use this for initialization
	void Start () {

		//Find and store the camera objects and manager
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();


		rigidbody.AddForce(new Vector3(0, 0, 1) * minSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		//Detect the player's current speed
		currentSpeed = rigidbody.velocity.magnitude;

		//Before any Input is processed, check to see if Oculus is enabled
		oculusEnabled = gameManager.isOculusEnabled();

		//Input grabbing - doesn't move relative to current camera
		if(Input.GetKey(KeyCode.LeftShift) && !checkMaxSpeed()){
			rigidbody.AddForce(new Vector3(0, 0, 1.0f) * moveSpeed);
		}
		if(!Input.GetKey(KeyCode.LeftShift) && !checkMinSpeed()){
			rigidbody.AddForce(new Vector3(0, 0, -1.0f) * moveSpeed);
		}
		if(Input.GetKey(KeyCode.LeftControl) && !checkMinSpeed()){
			rigidbody.AddForce(new Vector3(0, 0, -1.0f) * moveSpeed);
		}
		if(Input.GetKey(KeyCode.A)){
			rigidbody.AddForce(new Vector3(-1.0f, 0, 0) * moveSpeed);
		}
		if(Input.GetKey(KeyCode.D)){
			rigidbody.AddForce(new Vector3(1.0f, 0, 0) * moveSpeed);
		}
		if(Input.GetKey(KeyCode.W)){
			rigidbody.AddForce(new Vector3(0, 1.0f, 0) * moveSpeed);
		}
		if(Input.GetKey(KeyCode.S)){
			rigidbody.AddForce(new Vector3(0, -1.0f, 0) * moveSpeed);
		}
		if(deathTimerActive){
			deathTimer += Time.deltaTime;
			if(deathTimer >= 0.2f){
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
	void FixedUpdate() {
		//If we exceed the maximum speed, determine velocity direction and lock it
		if(checkMaxSpeed()){
			//Debug.Log("Speed too high: " + tempVelocity.z);
			rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, (1.0f * maxSpeed));
			//rigidbody.AddForce(new Vector3(0, 0, 1.0f) * maxSpeed);
		}  
		if(checkMinSpeed()){
			//Debug.Log("Speed not sufficient: " + tempVelocity.z);
			rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, (1.0f * minSpeed));
			//rigidbody.AddForce(new Vector3(0, 0, 1.0f) * minSpeed);
		}
	}
	private bool checkMaxSpeed(){
		Vector3 tempVelocity = rigidbody.velocity;
		if(tempVelocity.z > maxSpeed){
			return true;
		}
		else{
			return false;
		}
	}
	private bool checkMinSpeed(){
		Vector3 tempVelocity = rigidbody.velocity;
		if(tempVelocity.z < minSpeed){
			return true;
		}
		else{
			return false;
		}
	}
	public void resetVelocity(){
		rigidbody.velocity = new Vector3(0,0,0);
	}
	public void damagePlayer(){
		Debug.Log("Damaging Player");
		Material tempMaterial = GameObject.Find("Glass").renderer.material;
		Material[] materialList = new Material[2];

		switch (timesHit){
		case 0:
			materialList[0] = tempMaterial;
			materialList[1] = damagedMaterial;
			GameObject.Find("Glass").renderer.materials = materialList;
			timesHit++;
			break;
		case 1:
			materialList[0] = tempMaterial;
			materialList[1] = destroyedMaterial;
			GameObject.Find("Glass").renderer.materials = materialList;
			timesHit++;
			break;
		case 2:
			deathTimerActive = true;
			timesHit++;
			break;
		}

	}
	public float getCurrentSpeed(){
		return currentSpeed;
	}
}
