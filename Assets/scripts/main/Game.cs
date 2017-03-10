using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class Game  {
	public static AsyncOperation aos;
	public static bool cheatMode,pause, lose, win , cutscene;
	public static GameObject statScreen,panel;
	public static Image panelImage;

	public static void end () {
		if (!pause) {
			//UnityEngine.Debug.Log(this.name);
			GameObject gui;
			GameObject reviewPanel;
			gui = GameObject.Find ("GUI");
			reviewPanel = GameObject.Find ("ReviewPanel");
			//reviewPanel = GameObject.FindGameObjectWithTag("reviewPanel");
			statScreen = GameObject.Find ("dialogCanvas");
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

			aos = SceneManager.LoadSceneAsync(Stats.currentLevel);
			aos.allowSceneActivation = true;


			SceneManager.LoadScene (Stats.currentLevel);
		}
	}
	public static void refresh(){
		pause=false;
		Stats.wordCount = 0;
		Stats.timeleft = 90;
		Stats.drawProgess = 0;
		Stats.codeProgess = 0;
	}

}
