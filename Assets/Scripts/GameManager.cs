using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	private GameObject OVRCamera;

	private GameObject FPSCamera;
	private bool oculus;

	
	// Use this for initialization
	void Start () {
		OVRCamera = GameObject.Find("OVRCameraController");
		FPSCamera = GameObject.Find("FPS Character");

		if(Application.isPlaying){
			Screen.showCursor = false;
		}

		OVRCamera.SetActive(false);
		oculus = false;
	}
	
	// Update is called once per frame
	void Update () {
		//Toggle for oculus display
		if(Input.GetKeyDown(KeyCode.O)){
			if(oculus == true){
				oculus = false;
				OVRCamera.gameObject.SetActive(false);
				FPSCamera.gameObject.SetActive(true);
			}
			else if(oculus == false){
				oculus = true;
				
				OVRCamera.gameObject.SetActive(true);
				FPSCamera.gameObject.SetActive(false);
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
