using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]

public class Record : MonoBehaviour 
{
	//A boolean that flags whether there's a connected microphone
	private bool micConnected = false;

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
	public ArrayList instruments = new ArrayList();
	
	//Use this for initialization
	IEnumerator Start() 
	{
		
		instruments.Add (darkCello);
		instruments.Add (clubDrums);
		instruments.Add (asia);
		instruments.Add (synth);
		instruments.Add (strings);
		instruments.Add (percussions);
		instruments.Add (reggaeDrums);
		
		yield return Application.RequestUserAuthorization(UserAuthorization.Microphone);
        if (Application.HasUserAuthorization(UserAuthorization.Microphone))
        {
            InitMicrophone ();
        }
        else
        {
            // no permission. Show error here.
        }
	}
	
	void InitMicrophone() {
		//Check if there is at least one microphone connected
		if(Microphone.devices.Length <= 0)
		{
			//Throw a warning message at the console if there isn't
			Debug.LogWarning("Microphone not connected!");
		}
		else //At least one microphone is present
		{
			//Set 'micConnected' to true
			micConnected = true;

			//Get the default microphone recording capabilities
			Microphone.GetDeviceCaps(null, out minFreq, out maxFreq);

			//According to the documentation, if minFreq and maxFreq are zero, the microphone supports any frequency...
			if(minFreq == 0 && maxFreq == 0)
			{
				//...meaning 44100 Hz can be used as the recording sampling rate
				maxFreq = 44100;
			}

			//Get the attached AudioSource component
			goAudioSource = this.GetComponent<AudioSource>();
		}
	}
	
	void OnGUI() 
	{
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
		if(GUI.Button(new Rect(Screen.width-80, 120, 70, 50), "Guitar"))
		{
				gameObject.GetComponent<rippleSharp>().mode = "guitar";
		}
		if(GUI.Button(new Rect(Screen.width-80, 170, 70, 50), "Keyboard"))
		{
				gameObject.GetComponent<rippleSharp>().mode = "keyboard";
		}
		if(GUI.Button(new Rect(Screen.width-80, 220, 70, 50), "Musicbox"))
		{
				gameObject.GetComponent<rippleSharp>().mode = "musicbox";
		}
		if(GUI.Button(new Rect(Screen.width-80, 270, 70, 50), "Glassharp"))
		{
				gameObject.GetComponent<rippleSharp>().mode = "glassharp";
		}
		if(GUI.Button(new Rect(Screen.width-80, 320, 70, 50), "Synthesizer"))
		{
				gameObject.GetComponent<rippleSharp>().mode = "synthesizer";
		}
		if(GUI.Button(new Rect(Screen.width-80, 370, 70, 50), "Reset Synth"))
		{
				gameObject.GetComponent<rippleSharp>().resetSynth();
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
		
		
		//If there is a microphone
		if(micConnected)
		{
			//If the audio from any microphone isn't being captured
			if(!Microphone.IsRecording(null))
			{
				if(goAudioSource != null)
				{
					if(!goAudioSource.isPlaying)
					{
						goAudioSource.Play ();
					}
				}
				//Case the 'Record' button gets pressed
				if(GUI.Button(new Rect(50, 20, 100, 50), "Record"))
				{
					//Start recording and store the audio captured from the microphone at the AudioClip in the AudioSource
					goAudioSource.clip = Microphone.Start(null, true, 5, maxFreq);
				}
			}
			else //Recording is in progress
			{
				//Case the 'Stop and Play' button gets pressed
				if(GUI.Button(new Rect(50, 20, 100, 50), "Stop and Play!"))
				{
					Microphone.End(null); //Stop the audio recording
					//goAudioSource.loop = true;
					goAudioSource.Play(); //Playback the recorded audio
					
				}

				GUI.Label(new Rect(50, 70, 100, 50), "Recording in progress...");
			}
		}
		else // No microphone
		{
			//Print a red "Microphone not connected!" message at the center of the screen
			GUI.contentColor = Color.red;
			GUI.Label(new Rect(Screen.width/2-100, Screen.height/2-25, 200, 50), "Microphone not connected!");
		}

	}
}