using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class Game  {
	public static AsyncOperation aos;
	public static bool cheatMode=true,pause, lose, win , cutscene;
	public static GameObject statScreen,panel;
	public static Image panelImage;
	public enum Conditions : short {visualLeft=0,visualRight=1,audioLeft=2,audioRight=3};
	public static AudioSource disR = GameObject.Find("distraction Right").GetComponent<AudioSource> ();
	public static AudioSource disL = GameObject.Find("distraction Left").GetComponent<AudioSource> ();
	public static AudioSource cafeR = GameObject.Find ("Cafe bgm Right").GetComponent<AudioSource> ();
	public static AudioSource cafeL = GameObject.Find ("Cafe bgm Left").GetComponent<AudioSource> ();
	public static AudioSource  machL= GameObject.Find ("maching Left").GetComponent<AudioSource> ();
	public static AudioSource  machR = GameObject.Find ("maching Right").GetComponent<AudioSource> ();
	public static Image leftEye = GameObject.Find ("leftEye").GetComponent<Image> ();
	public static Image rightEye = GameObject.Find ("rightEye").GetComponent<Image> ();
	public static GameObject player= GameObject.FindGameObjectWithTag("Player");

	public static void end () {
		if (!pause) {
	
			GameObject gui;
			GameObject reviewPanel;
			gui = GameObject.Find ("GUI");
			reviewPanel = GameObject.Find ("ReviewPanel");
			//reviewPanel = GameObject.FindGameObjectWithTag("reviewPanel");
			//statScreen = GameObject.Find ("dialogCanvas");
			statScreen = GameObject.Instantiate((GameObject)Resources.Load("PreFabs/dialogCanvas", typeof(GameObject)));

			panel = GameObject.FindGameObjectWithTag ("dialogPanel");
			panelImage = panel.GetComponent<Image> ();
			panelImage.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
			statScreen.SetActive (true);

			Text content = statScreen.GetComponentsInChildren<Text> () [0];
			content.text = "GAMEOVER" +
				"\n timeLeft: " + Mathf.Ceil (Stats.timeleft) +"s"+
				"\n progress made: " + Mathf.Ceil (Stats.wordCount) +" of "+ Stats.maxWordCount+
				"\n apathy left: " + Mathf.Floor (Stats.apathy)+"%"+
				"\n total people ignored: " + Stats.ignoredObstacle ; 
			UnityEngine.Debug.Log( "GAMEOVER" +
				"\n timeLeft: " + Mathf.Ceil (Stats.timeleft) +"s"+
				"\n progress made: " + Mathf.Ceil (Stats.wordCount) +" of "+ Stats.maxWordCount+
				"\n apathy left: " + Mathf.Floor (Stats.apathy)+"%"+
				"\n total people ignored: " + Stats.ignoredObstacle );
			if (Time.timeScale == 1) {            
				Time.timeScale = 0.00001f;
				//Screen.showCursor = true;
				//Screen.lockCursor = false;
			}       
			//gui.SetActive (false);
			//reviewPanel.SetActive (true);
			//GUI.enabled = false;
			Debug.Log ("end!!!");
			Game.pause = true;

			aos = SceneManager.LoadSceneAsync((SceneManager.GetActiveScene ().buildIndex + 1));
			aos.allowSceneActivation = true;
		//	refresh ();
		//	SceneManager.LoadScene ((SceneManager.GetActiveScene ().buildIndex + 1));
		}
	}
	public static void alert(){
		UnityEngine.Debug.Log ("ALERT!!"+Time.timeSinceLevelLoad);
	}
	public static void refresh(){
		
		UnityEngine.Debug.Log ("refresh!!"+Time.timeSinceLevelLoad);
		pause=false;
		Time.timeScale = 1;
		//Time.timeSinceLevelLoad;

		Stats.wordCount = 0;
		Stats.timeleft = 90;
		Stats.drawProgess = 0;
		Stats.codeProgess = 0;
		Stats.apathyLost = 0;
		Stats.apathy = Stats.maxApathy;

	}
	[System.Diagnostics.DebuggerStepThrough]
	public static void check(UnityEngine.Object obj,String name){
		if (obj == null)
			throw new Exception ("can't find :"+name);
	}

}
