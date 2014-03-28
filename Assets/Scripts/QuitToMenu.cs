using UnityEngine;
using System.Collections;

public class QuitToMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		Time.timeScale = 1.0f;
		Application.LoadLevel(0); 
	}  
}
