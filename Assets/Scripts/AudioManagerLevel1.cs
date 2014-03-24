using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class AudioManagerLevel1 : MonoBehaviour {
	private bool musicFaded = false;

	// Use this for initialization
	void Start () {
		audio.volume = 0.0f;
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if(!musicFaded){
			if(audio.volume < 0.5f){
				audio.volume += 0.0005f;
			}
			else{
				musicFaded = true;
			}
		}
	}
}
