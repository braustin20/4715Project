using UnityEngine;
using System.Collections;

public class OxygenBar : MonoBehaviour {
	private float currentOxygen;
	private float maxOxygen;
	private GameObject player;
	private float startingScaleY;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		currentOxygen = player.GetComponent<FloatingControls>().oxygen;
		maxOxygen = currentOxygen;
		startingScaleY = this.transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
		if(player.GetComponent<FloatingControls>().oxygen != currentOxygen){
			currentOxygen = player.GetComponent<FloatingControls>().oxygen;
			//Need to align pivot at the bottom to make it scale in only one direction
			this.transform.localScale = new Vector3(this.transform.localScale.x,
													startingScaleY * (currentOxygen/maxOxygen),
			                                        this.transform.localScale.z);
		}
	}
}
