using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]

public class Record : MonoBehaviour 
{

	//The maximum and minimum available recording frequencies
	private int minFreq;
	private int maxFreq;

	//A handle to the attached AudioSource
	private AudioSource goAudioSource;
	public AudioSource darkCello;
	public AudioSource clubDrums;
	public AudioSource asia;
	public AudioSource synth;
	public AudioSource strings;
	public AudioSource percussions;
	public AudioSource reggaeDrums;
	private GUIStyle buttonRed;
	private GUIStyle buttonGreen;
	public ArrayList instruments = new ArrayList();
	
	//Use this for initialization
	void Start() 
	{
		
		instruments.Add (darkCello);
		instruments.Add (clubDrums);
		instruments.Add (asia);
		instruments.Add (synth);
		instruments.Add (strings);
		instruments.Add (percussions);
		instruments.Add (reggaeDrums);
		
	}
	
	
	void OnGUI() 
	{
		if(buttonRed == null)
		{
			buttonRed = new GUIStyle(GUI.skin.button);
			buttonRed.normal.textColor = Color.red;
			buttonRed.fontStyle = FontStyle.Bold;
			buttonRed.fontSize = 15;
			buttonRed.alignment = TextAnchor.MiddleCenter;
		}
		if(buttonGreen == null)
		{
			buttonGreen = new GUIStyle(GUI.skin.button);
			buttonGreen.normal.textColor = Color.green;
			buttonGreen.fontStyle = FontStyle.Bold;
			buttonGreen.fontSize = 15;
			buttonGreen.alignment = TextAnchor.MiddleCenter;
		}
		/*if(GUI.Button(new Rect(10, 120, 70, 50), "Cello"))
		{
				if(darkCello.volume == 0)
				{
					darkCello.volume = 1;
				}
				else darkCello.volume = 0;
		}
		if(GUI.Button(new Rect(10, 170, 70, 50), "Drums"))
		{
				if(clubDrums.volume == 0)
				{
					clubDrums.volume = 1;
				}
				else clubDrums.volume = 0;
		}
		if(GUI.Button(new Rect(10, 220, 70, 50), "Asia"))
		{
				if(asia.volume == 0)
				{
					asia.volume = 1;
				}
				else asia.volume = 0;
		}
		if(GUI.Button(new Rect(10, 270, 70, 50), "Perc"))
		{
				if(percussions.volume == 0)
				{
					percussions.volume = 1;
				}
				else percussions.volume = 0;
		}
		if(GUI.Button(new Rect(10, 320, 70, 50), "Synth"))
		{
				if(synth.volume == 0)
				{
					synth.volume = 1;
				}
				else synth.volume = 0;
		}
		if(GUI.Button(new Rect(10, 370, 70, 50), "Strings"))
		{
				if(strings.volume == 0)
				{
					strings.volume = 1;
				}
				else strings.volume = 0;
		}
		if(GUI.Button(new Rect(10, 420, 70, 50), "Reggae"))
		{
				if(reggaeDrums.volume == 0)
				{
					reggaeDrums.volume = 1;
				}
				else reggaeDrums.volume = 0;
		}
		*/
		if(gameObject.GetComponent<rippleSharp>().mode.Equals ("synthesizer"))
		{
			if(GUI.Button(new Rect(Screen.width-110, 120, 100, 50), "Synthesizer", buttonGreen))
			{
					gameObject.GetComponent<rippleSharp>().mode = "none";
			}
		}
		else
		{
			if(GUI.Button(new Rect(Screen.width-110, 120, 100, 50), "Synthesizer", buttonRed))
			{
					gameObject.GetComponent<rippleSharp>().mode = "synthesizer";
				
					
			}

		}	
		
		if(GUI.Button(new Rect(Screen.width-110, 170, 100, 50), "Reset Synth"))
		{
				gameObject.GetComponent<rippleSharp>().resetSynth();
		}
		if(gameObject.GetComponent<rippleSharp>().mode.Equals ("guitar"))
		{
			if(GUI.Button(new Rect(Screen.width-110, 220, 100, 50), "Guitar", buttonGreen))
			{
					gameObject.GetComponent<rippleSharp>().mode = "none";
			}
		}
		else
		{
			if(GUI.Button(new Rect(Screen.width-110, 220, 100, 50), "Guitar", buttonRed))
			{
					gameObject.GetComponent<rippleSharp>().mode = "guitar";
				
					
			}

		}
		if(gameObject.GetComponent<rippleSharp>().mode.Equals ("keyboard"))
		{
			if(GUI.Button(new Rect(Screen.width-110, 270, 100, 50), "Keyboard", buttonGreen))
			{
					gameObject.GetComponent<rippleSharp>().mode = "none";
			}
		}
		else
		{
			if(GUI.Button(new Rect(Screen.width-110, 270, 100, 50), "Keyboard", buttonRed))
			{
					gameObject.GetComponent<rippleSharp>().mode = "keyboard";
				
					
			}

		}
		if(gameObject.GetComponent<rippleSharp>().mode.Equals ("musicbox"))
		{
			if(GUI.Button(new Rect(Screen.width-110, 320, 100, 50), "Musicbox", buttonGreen))
			{
					gameObject.GetComponent<rippleSharp>().mode = "none";
			}
		}
		else
		{
			if(GUI.Button(new Rect(Screen.width-110, 320, 100, 50), "Musicbox", buttonRed))
			{
					gameObject.GetComponent<rippleSharp>().mode = "musicbox";
				
					
			}

		}
		if(gameObject.GetComponent<rippleSharp>().mode.Equals ("glassharp"))
		{
			if(GUI.Button(new Rect(Screen.width-110, 370, 100, 50), "Glassharp", buttonGreen))
			{
					gameObject.GetComponent<rippleSharp>().mode = "none";
			}
		}
		else
		{
			if(GUI.Button(new Rect(Screen.width-110, 370, 100, 50), "Glassharp", buttonRed))
			{
					gameObject.GetComponent<rippleSharp>().mode = "glassharp";
				
					
			}

		}

		if(GUI.Button(new Rect(0, Screen.height-30, 60, 30), "Reset"))
		{
				gameObject.GetComponent<rippleSharp>().resetSynth();
				gameObject.GetComponent<rippleSharp>().mode = "none";
				GameObject guiInstruments = GameObject.Find("gui_instruments");
				Component[] instrumentLayers = guiInstruments.GetComponentsInChildren<MovePoint2>();
				foreach (MovePoint2 mP in instrumentLayers)
				{
					((MovePoint2)mP).ResetPosition();
				}
		}
		
		

	}
}