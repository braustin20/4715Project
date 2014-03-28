using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	private GameObject OVRCamera;
	private GameObject FPSCamera;

	private bool oculus;

	
	// Use this for initialization
	void Start () {
		//Find the two kinds of cameras
		OVRCamera = GameObject.Find("OVRCameraController");
		FPSCamera = GameObject.Find("FPS Character");

		//If this is a build of the game, hide and lock the cursor
		if(Application.isPlaying && !Application.isEditor){
			Screen.showCursor = false;
			Screen.lockCursor = true;
		}
		//If the OVR Camera is present, make sure it is disabled at the start
		if(OVRCamera != null){
			OVRCamera.SetActive(false);
		}
		oculus = false;
	}
	
	// Update is called once per frame
	void Update () {
		//fps
	//	Debug.Log(1/Time.deltaTime);
		//Toggle for oculus display
		if(Input.GetKeyDown(KeyCode.O)){
			if(oculus == true){
				oculus = false;
				OVRCamera.gameObject.SetActive(false);
				FPSCamera.gameObject.SetActive(true);
				if(OVRCamera.GetComponent<MouseLook>() != null){
					OVRCamera.GetComponent<MouseLook>().enabled = false;
				}
			}
			else if(oculus == false){
				oculus = true;
				
				OVRCamera.gameObject.SetActive(true);
				FPSCamera.gameObject.SetActive(false);
				if(OVRCamera.GetComponent<MouseLook>() != null){
					OVRCamera.GetComponent<MouseLook>().enabled = true;
				}
			}
		}
		if(oculus == true){
			//Specific Oculus management
		}
		else{
			//Specific FPS management
		}

		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}
	}
	public void pause(){
		Time.timeScale = 0.0f;
	}
	public void resume(){
		Time.timeScale = 1.0f;
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
}
