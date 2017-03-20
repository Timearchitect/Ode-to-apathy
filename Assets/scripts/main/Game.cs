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
	public static AudioSource disR;
	public static AudioSource disL;
	public static AudioSource cafeR;
	public static AudioSource cafeL;
	public static AudioSource machL;
	public static AudioSource machR;
	public static Image leftEye;
	public static Image rightEye;
	public static GameObject player;

	public static void loadStaticReferences(){
		disR = GameObject.Find("distraction Right").GetComponent<AudioSource> ();
		 disL = GameObject.Find("distraction Left").GetComponent<AudioSource> ();
		cafeR = GameObject.Find ("Cafe bgm Right").GetComponent<AudioSource> ();
		cafeL = GameObject.Find ("Cafe bgm Left").GetComponent<AudioSource> ();
		machL= GameObject.Find ("maching Left").GetComponent<AudioSource> ();
		 machR = GameObject.Find ("maching Right").GetComponent<AudioSource> ();
		leftEye = GameObject.Find ("leftEye").GetComponent<Image> ();
		rightEye = GameObject.Find ("rightEye").GetComponent<Image> ();
		 player= GameObject.FindGameObjectWithTag("Player");
	}

	public static void gameover(){
		aos = SceneManager.LoadSceneAsync(8);
		aos.allowSceneActivation = true;
	}
	public static void apathyDeath(){
		aos = SceneManager.LoadSceneAsync(9);
		aos.allowSceneActivation = true;
	}

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
			Stats.currentLevel++;
			aos = SceneManager.LoadSceneAsync((SceneManager.GetActiveScene ().buildIndex + 1));
			aos.allowSceneActivation = true;
			//refresh ();
			//SceneManager.LoadScene ((SceneManager.GetActiveScene ().buildIndex + 1));
		}
	}

	public static void alert(){
		UnityEngine.Debug.Log ("ALERT!!"+Time.timeSinceLevelLoad);
	}

	public static void refresh(){
		pause=false;
		Time.timeScale = 1;
		//Time.timeSinceLevelLoad;
		//print ("build index +1: " + ());
		win=false;
		UnityEngine.Debug.Log ("refresh!!"+Time.timeSinceLevelLoad+" current LVL:"+Stats.currentLevel);

		Stats.difficultyBasedOnLevel();
		Stats.wordCount = 0;
		Stats.workMode = 0;
		Stats.timeleft = Stats.totalTime;
		Stats.drawProgess = 0;
		Stats.codeProgess = 0;
		Stats.apathyLost = 0;
		Stats.apathy = Stats.maxApathy;
		timer.resetSoundNoArduino = true;
	}
	public static void setCurrentlevelBasedOnbuildIndex(int biuldIndex){	
		switch(biuldIndex ){
		case 2:
			Stats.currentLevel = 1;
			break;
		case 4:
			Stats.currentLevel = 2;
			break;
		case 6:
			Stats.currentLevel = 3;
			break;
		default:
			UnityEngine.Debug.Log(biuldIndex);
			break;
		}
		UnityEngine.Debug.Log ("setCurrentlevelBasedOnbuildIndex!!: "+biuldIndex+" current LVL:"+Stats.currentLevel);

	}
	public static void audioBasedOnLevel(){
	
		switch(Stats.currentLevel){
		case 1:
			break;
		case 2:
			break;
		case 3:
			AudioSource cafeR = UnityEngine.GameObject.Find ("Cafe bgm Right").GetComponent<AudioSource> ();
			AudioSource cafeL = UnityEngine.GameObject.Find ("Cafe bgm Left").GetComponent<AudioSource> ();
			AudioSource machR = UnityEngine.GameObject.Find ("maching Right").GetComponent<AudioSource> ();
			AudioSource machL = UnityEngine.GameObject.Find ("maching Left").GetComponent<AudioSource> ();
			cafeR.mute = true;
			cafeL.mute = true;
			machR.bypassReverbZones = true;
			machL.bypassReverbZones = true;
			UnityEngine.Debug.Log ("MUTE!!!!");
			break;
		default:
			break;
		}
	}

	[System.Diagnostics.DebuggerStepThrough]
	public static void check(UnityEngine.Object obj,String name){
		if (obj == null)
			throw new Exception ("can't find :"+name);
	}

}
