﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {
	//public static float gametimer = 90.0f;
	private int minutes  , seconds ;
	private  GUIStyle timeStyle,currentStyle;
	public Texture2D myGUITexture;
	public static bool resetSoundNoArduino=true;
	// Use this for initialization
	void Start () { 
		Ardunity.ArdunityApp arduino = GameObject.Find ("Ardunity").GetComponent<Ardunity.ArdunityApp>();
		arduino.Connect ();
		//print (arduino.GetType().ToString()+"!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

		timeStyle  = new GUIStyle("box");
		timeStyle.fontSize = Mathf.FloorToInt(Screen.width*.04f);
		timeStyle.alignment = TextAnchor.MiddleCenter;
		timeStyle.font = (Font)Resources.Load("helvetica-normal-58c53b4136502");
		GUI.backgroundColor = new Color (1, 1, 1, 0.2f);
		GUI.color = Color.white;
		//	currentStyle = new GUIStyle( GUI.skin.box );
		//	currentStyle.normal.background = MakeTex( 2, 2, new Color( 0f, 1f, 0f, 0.5f ) );
	}
	
	void Update () {
		if (resetSoundNoArduino && Time.timeSinceLevelLoad > 0.5f) {
			resetSoundNoArduino = false;
			AudioSource[] As = GameObject.FindObjectsOfType<AudioSource> ();
			foreach (AudioSource a in As) {
				a.volume = 1;
				a.bypassEffects = true;
			}
			Game.audioBasedOnLevel ();
		
		}
		//	gametimer -= Time.deltaTime;
		minutes = Mathf.FloorToInt(Stats.timeleft / 60);
		seconds = Mathf.FloorToInt(Stats.timeleft % 60);
		if(Stats.timeleft <= 0){
			Stats.timeleft = 0;
			seconds=0;
			minutes=0;
			print("finished");
			// Game.end();
			// Förlust
		}

	}

	void OnGUI(){
		if (!Game.pause) {
			Rect r = new Rect (Screen.width * .5f, Screen.height * .02f, Screen.width * .25f, Screen.height * .1f);
			r.center = new Vector2 (Screen.width * .5f, Screen.height * .1f);
			GUI.backgroundColor = new Color (1, 1, 1, 0.2f);
			GUI.color = Color.white;
			GUI.contentColor = Color.white;
			GUI.Box (r, " " + minutes.ToString ("00") + ":" + seconds.ToString ("00"), timeStyle);
		}
	}
}

/*

function Update () {
	timer -= Time.deltaTime;
	minutes = Mathf.Floor(timer / 60);
	seconds = Mathf.Ceil(timer % 60);
	if(timer <= 0){
		timer = 0;
		seconds=0;
		minutes=0;
		print("finished");
		// Game.end();
		// Förlust
	}
}

function OnGUI(){
	//"" + timer.ToString("0")
	var timeStyle : GUIStyle = new GUIStyle("box");
	timeStyle.fontSize = Screen.height*.025f;

	GUI.Box(new Rect(Screen.width*.5f, Screen.height*.02f, 80, Screen.height*.04f), " "+ minutes.ToString("00") +":"+seconds.ToString("00"),timeStyle);
}
*/