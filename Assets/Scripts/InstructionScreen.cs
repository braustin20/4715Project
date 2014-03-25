using UnityEngine;
using System.Collections;

public class InstructionScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnGUI() {
		if(Event.current.type == EventType.KeyDown || Event.current.type == EventType.MouseDown) {
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}
