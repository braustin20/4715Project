using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	private GameObject OVRCamera;
	private GameObject OVRRightCamera;
	private GameObject FPSCamera;

	public GameObject pauseMenu;
	private GameObject spawnedMenu;

	private bool paused;

	private bool oculus;

	
	// Use this for initialization
	void Start () {
		//Find the two kinds of cameras
		OVRCamera = GameObject.Find("OVRCameraController");
		OVRRightCamera = GameObject.Find("CameraRight");
		FPSCamera = GameObject.Find("FPS Character");

		//If this is a build of the game, hide and lock the cursor
		if(Application.isPlaying || Application.isEditor){
			Screen.showCursor = false;
			Screen.lockCursor = true;
		}
		//If the OVR Camera is present, make sure it is disabled at the start
		if(OVRCamera != null){
			OVRCamera.SetActive(false);
		}

		if(PlayerPrefs.GetInt("Oculus Enabled") == 1){
			toggleOculus();
		}
		else{
			oculus = false;
		}

	}
	
	// Update is called once per frame
	void Update () {
		//fps
	//	Debug.Log(1/Time.deltaTime);
		//Toggle for oculus display
		if(Input.GetKeyDown(KeyCode.O)){
			toggleOculus();
		}
		if(oculus == true){
			//Specific Oculus management
		}
		else{
			//Specific FPS management
		}

		if(Input.GetKeyDown(KeyCode.Escape)){
			if(!paused){
				pause();
			}
			else{
				resume();
			}
		}
	}
	public void pause(){
		//FPSCamera.GetComponent<MouseLook>().enabled = false;
		if(oculus){
			if(FPSCamera.transform.parent.GetComponent<MouseLook>() != null){
				FPSCamera.transform.parent.GetComponent<MouseLook>().enabled = false;
			}
			//OVRCamera.GetComponent<MouseLook>().enabled = false;
			spawnedMenu = GameObject.Instantiate(pauseMenu, OVRCamera.transform.position + ((OVRCamera.transform.forward) * 0.35f), OVRCamera.transform.rotation) as GameObject;
		}
		else{
			if(FPSCamera.transform.parent.GetComponent<MouseLook>() != null){
				FPSCamera.transform.parent.GetComponent<MouseLook>().enabled = false;
			}
			FPSCamera.GetComponent<MouseLook>().enabled = false;
			spawnedMenu = GameObject.Instantiate(pauseMenu, FPSCamera.transform.position + ((FPSCamera.transform.forward) * 0.35f), FPSCamera.transform.rotation) as GameObject;

		}
		Time.timeScale = 0.0f;
		paused = true;
		Screen.showCursor = true;
		Screen.lockCursor = false;
		//spawnedMenu = GameObject.Instantiate(pauseMenu, FPSCamera.transform.position + ((FPSCamera.transform.forward) * 0.35f), FPSCamera.transform.rotation) as GameObject;

	}
	public void resume(){
		Time.timeScale = 1.0f;
		paused = false;
		Screen.showCursor = false;
		Screen.lockCursor = true;
		if(oculus){
			if(FPSCamera.transform.parent.GetComponent<MouseLook>() != null){
				FPSCamera.transform.parent.GetComponent<MouseLook>().enabled = true;
			}
			//OVRCamera.GetComponent<MouseLook>().enabled = true;
		}
		else{
			if(FPSCamera.transform.parent.GetComponent<MouseLook>() != null){
				FPSCamera.transform.parent.GetComponent<MouseLook>().enabled = true;
			}
			FPSCamera.GetComponent<MouseLook>().enabled = true;
		}
		GameObject.Destroy(spawnedMenu);
	}
	private void toggleOculus(){
		if(!paused){
		if(oculus == true){
			oculus = false;
			OVRCamera.gameObject.SetActive(false);
			FPSCamera.gameObject.SetActive(true);
			if(OVRCamera.GetComponent<MouseLook>() != null){
				OVRCamera.GetComponent<MouseLook>().enabled = false;
			}
			PlayerPrefs.SetInt("Oculus Enabled", 0);
		}
		else if(oculus == false){
			oculus = true;
			
			OVRCamera.gameObject.SetActive(true);
			FPSCamera.gameObject.SetActive(false);
			if(OVRCamera.GetComponent<MouseLook>() != null){
				OVRCamera.GetComponent<MouseLook>().enabled = true;
			}
			PlayerPrefs.SetInt("Oculus Enabled", 1);
		}
		}
	}
	//------Getters and Setters-----
	public bool isOculusEnabled(){
		return oculus;
	}
	public GameObject getFPSCamera(){
		if(FPSCamera == null){
			FPSCamera = GameObject.Find("FPS Character");
		}
		return FPSCamera;
	}
	public GameObject getOVRCamera(){
		if(OVRCamera == null){
			OVRCamera = GameObject.Find("OVRCameraController");
		}
		return OVRCamera;
	}
	public GameObject getRightCamera(){
		if(OVRRightCamera == null){
			OVRRightCamera = GameObject.Find("RightCamera");
		}
		return OVRRightCamera;
	}
}
