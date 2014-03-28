using UnityEngine;
using System.Collections;

public class Resume : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		GameObject.Find("GameManager").GetComponent<GameManager>().resume(); 
	}  
}
