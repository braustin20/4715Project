using UnityEngine;
using System.Collections;

public class LaserGrow : MonoBehaviour {
	public float finalMaxSize = 50.0f;
	public float finalMaxAmt = 100.0f;

	private bool finalReached = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!finalReached){
			if(particleEmitter.maxSize < 50.0f  && particleEmitter.emit){
				this.particleEmitter.maxSize += 0.01f;
				this.particleEmitter.minSize += 0.01f;
				this.particleEmitter.maxEmission += 0.01f;
				this.particleEmitter.minEmission += 0.01f;
			}
			else if(particleEmitter.maxSize >= 50.0f  && particleEmitter.emit){
				finalReached = true;
			}
		}
	}
}
