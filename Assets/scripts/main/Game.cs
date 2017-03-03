using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public static class Game  {
	
	public static void end () {
		GameObject gui;
		GameObject reviewPanel;
		gui = GameObject.Find ("GUI");
		reviewPanel = GameObject.Find ("ReviewPanel");
		//reviewPanel = GameObject.FindGameObjectWithTag("reviewPanel");

		//gui.SetActive (false);
		reviewPanel.SetActive (true);
		//GUI.enabled = false;
		Debug.Log ("end!!!");
	}

	public static void pause () {
		
	}
}
