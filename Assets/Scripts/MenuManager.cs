using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
	private bool oculus;

	private GameObject OVRCamera;
	private GameObject FPSCamera;

	// Use this for initialization
	void Start () {
		//Find the two kinds of cameras
		OVRCamera = GameObject.Find("OVRCameraController");
		FPSCamera = GameObject.Find("Main Camera");

		if(Application.loadedLevel == 0){
			Screen.showCursor = true;
			Screen.lockCursor = false;
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
		if(Input.GetKeyDown(KeyCode.O)){
			toggleOculus();
		}
	}
	private void toggleOculus(){
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
