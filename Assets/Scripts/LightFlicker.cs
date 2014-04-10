using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {
	private Light[] lightList;

	private float duration;
	private float timer;

	// Use this for initialization
	void Start () {
		lightList = this.GetComponentsInChildren<Light>();
		duration = Random.Range(0.0f, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {


		timer += Time.deltaTime;
		if(timer >= duration){
			foreach(Light light in lightList){
				if(light.enabled == false){
					light.enabled = true;
				}
				else{
					light.enabled = false;
				}
			}
			duration = Random.Range(0.0f, 1.0f);
			timer = 0.0f;
		}
	}
}
