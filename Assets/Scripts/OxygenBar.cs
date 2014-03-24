using UnityEngine;
using System.Collections;

public class OxygenBar : MonoBehaviour {
	private float currentOxygen;
	private float maxOxygen;
	private GameObject player;
	private float startingScaleY;
	private float colorIncrement;
	private bool toggledMid;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		currentOxygen = player.GetComponent<FloatingControls>().oxygen;
		maxOxygen = currentOxygen;
		startingScaleY = this.transform.localScale.y;
		Debug.Log(colorIncrement);
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
		Color tempColor = this.transform.FindChild("Health Bar").renderer.material.color;
		if(currentOxygen/maxOxygen <= 0.5f && !toggledMid){
			this.transform.FindChild("Health Bar").renderer.material.color = new Color(0.5f, 0.3f, 0.08f);
			toggledMid = true;
			Debug.Log(tempColor);
		}
		if(currentOxygen/maxOxygen <= 0.3f && tempColor.r != 0.8f){
			this.transform.FindChild("Health Bar").renderer.material.color = new Color(0.8f, 0.1f, 0.0f);
			Debug.Log(tempColor);
		}
	}
}
