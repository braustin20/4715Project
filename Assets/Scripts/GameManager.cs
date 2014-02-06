using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject ovrCameraController;
	public GameObject fpsCharacter;
	private GameObject ovrCharacter;
	private bool oculus;

	
	// Use this for initialization
	void Start () {
		if(Application.isPlaying){
			Screen.lockCursor = true;
			Screen.showCursor = false;
		}
		oculus = false;
		ovrCharacter = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		//Toggle for oculus display
		if(Input.GetKeyDown(KeyCode.O)){
			if(oculus == true){
				oculus = false;
				ovrCameraController.gameObject.SetActive(false);
				fpsCharacter.gameObject.SetActive(true);
			}
			else if(oculus == false){
				oculus = true;
				
				ovrCameraController.gameObject.SetActive(true);
				fpsCharacter.gameObject.SetActive(false);
			}
		}
		if(oculus == true){
			//Specific Oculus controls
		}
		else{
			//Specific FPS controls
		}

		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}
	}
	
	
}
