using UnityEngine;
using System.Collections;

public class OVRFlashlight : MonoBehaviour {
	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		//this.transform.rotation = gameManager.getOVRCamera().GetComponent<OVRCameraController>().
		this.transform.localEulerAngles = new Vector3(gameManager.getRightCamera().transform.localEulerAngles.x + 5.0f,
		                                              gameManager.getRightCamera().transform.localEulerAngles.y - 8.0f,
		                                              gameManager.getRightCamera().transform.localEulerAngles.z);
									
	}
}
