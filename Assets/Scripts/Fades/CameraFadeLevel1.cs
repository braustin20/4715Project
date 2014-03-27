using UnityEngine;


public class CameraFadeLevel1 : MonoBehaviour
{   
	// Style for background tiling
	private GUIStyle m_BackgroundStyle = new GUIStyle();
	// 1x1 pixel texture used for fading
	private Texture2D m_FadeTexture;				
	//Default starting color: black and fully transparrent
	private Color m_CurrentScreenOverlayColor = new Color(0,0,0,0);
	//Default target color: black and fully transparrent
	private Color m_TargetScreenOverlayColor = new Color(0,0,0,0);
	//The delta-color is basically the "speed / second" at which the current color should change
	private Color m_DeltaColor = new Color(0,0,0,0);
	//Make sure this texture is drawn on top of everything
	private int m_FadeGUIDepth = -1000;								
	public bool isFading = false;
	private float loadTimer = 0.0f;
	public float fadeTime = 2.0f;
	public GameObject beam;

	// initialize the texture, background-style and initial color:
	private void Awake()
	{		
		loadTimer = 0.0f;
		m_FadeTexture = new Texture2D(1, 1);        
		m_BackgroundStyle.normal.background = m_FadeTexture;
		SetScreenOverlayColor(m_CurrentScreenOverlayColor);
		
		// TEMP:
		// usage: use "SetScreenOverlayColor" to set the initial color, then use "StartFade" to set the desired color & fade duration and start the fade
		//SetScreenOverlayColor(new Color(0,0,0,1));
		//StartFade(new Color(1,0,0,1), 5);
	}

	 void Update(){
		if(isFading == true){
			loadTimer += Time.deltaTime;
		}
		if(loadTimer >= fadeTime){
			loadTimer = 0.0f;
			Debug.Log ("Fading Complete");
			Application.LoadLevel(Application.loadedLevel + 1);
		}

	}
	
	//Draw the texture and perform the fade
	private void OnGUI()
	{   
		//If the current color of the screen is not equal to the desired color, keep fading
		if (m_CurrentScreenOverlayColor != m_TargetScreenOverlayColor)
		{			
			//If the difference between the current alpha and the desired alpha is smaller than delta-alpha * deltaTime, then we're done fading
			if (Mathf.Abs(m_CurrentScreenOverlayColor.a - m_TargetScreenOverlayColor.a) < Mathf.Abs(m_DeltaColor.a) * Time.deltaTime)
			{
				m_CurrentScreenOverlayColor = m_TargetScreenOverlayColor;
				SetScreenOverlayColor(m_CurrentScreenOverlayColor);
				m_DeltaColor = new Color(0,0,0,0);
			}
			else
			{
				//Apply the fade
				SetScreenOverlayColor(m_CurrentScreenOverlayColor + m_DeltaColor * Time.deltaTime);
			}
		}
		
		//Only draw the texture when the alpha value is greater than 0
		if (m_CurrentScreenOverlayColor.a > 0)
		{			
			GUI.depth = m_FadeGUIDepth;
			GUI.Label(new Rect(-10, -10, Screen.width + 10, Screen.height + 10), m_FadeTexture, m_BackgroundStyle);
		}
	}
	
	
	//Sset the current color of the screen-texture to "newScreenOverlayColor"
	//Can be useful if you want to start a scene fully black and then fade to opague
	public void SetScreenOverlayColor(Color newScreenOverlayColor)
	{
		m_CurrentScreenOverlayColor = newScreenOverlayColor;
		m_FadeTexture.SetPixel(0, 0, m_CurrentScreenOverlayColor);
		m_FadeTexture.Apply();
	}
	
	
	//Initiate a fade from the current screen color (set using "SetScreenOverlayColor") towards "newScreenOverlayColor" taking "fadeDuration" seconds
	public void StartFade(Color newScreenOverlayColor, float fadeDuration)
	{
		if (fadeDuration <= 0.0f)
		{
			SetScreenOverlayColor(newScreenOverlayColor);
		}
		else					
			//Initiate the fade: set the target-color and the delta-color
		{
			m_TargetScreenOverlayColor = newScreenOverlayColor;
			m_DeltaColor = (m_TargetScreenOverlayColor - m_CurrentScreenOverlayColor) / fadeDuration;
		}

	}

	public void OnTriggerEnter(Collider other){

		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Ship"){
			Debug.Log ("Fade Started");
			//Fire a laser ending the level
			GameObject tempBeam = GameObject.Instantiate(beam, GameObject.Find("AlienCraft").transform.position + new Vector3(-56.0f, 0.0f, -73.0f),
			                                             beam.transform.rotation) as GameObject;
			tempBeam.transform.parent = GameObject.Find("AlienCraft").transform;
			tempBeam.transform.rotation = beam.transform.rotation;
			StartFade (Color.black, fadeTime);
			isFading = true;
			/*
			PlayerPrefs.SetFloat ("PlayerX", GameObject.Find("spawn").transform.position.x);
			PlayerPrefs.SetFloat ("PlayerY", GameObject.Find("spawn").transform.position.y);
			PlayerPrefs.SetFloat ("PlayerZ", GameObject.Find("spawn").transform.position.z);
			PlayerPrefs.SetString("isDead", "false");
			*/
		}
		
	}
}