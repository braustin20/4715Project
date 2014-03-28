using UnityEngine;
using System.Collections;

public class Cutscene : MonoBehaviour {
	private float timer = 0.0f;
	private float duration;

	// Use this for initialization
	void Start () {
		MovieTexture movie = renderer.material.mainTexture as MovieTexture;
		movie.Play();
		duration = movie.duration;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer >= duration){
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}
