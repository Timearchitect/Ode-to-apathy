using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public static class Game  {

	public static bool pause, lose, win , cutscene;
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
			"\n typed: " + Mathf.Ceil (Stats.wordCount) +
			"\n apathy left: " + Mathf.Floor (Stats.apathy)+"%"+
			"\n total ignored: " + Stats.ignoredObstacle ; 
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
		}
	}

	/*public static void pause () {
		
	}*/
}
