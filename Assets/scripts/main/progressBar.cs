using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
public class progressBar : MonoBehaviour {
	public GameObject go,apathyBar,camera;
	public ColorCorrectionCurves desaturation;
	float val=0.0f;
	private Slider progress,apathy;

	void Start () {
		try{
			camera= GameObject.Find("Camera");
				print(camera.name);			
			desaturation = camera.GetComponent<ColorCorrectionCurves> ();
				print(desaturation.name);
			go= GameObject.FindGameObjectWithTag("progressBar");
				print(go.name);
			progress = go.GetComponent<Slider>();
				print(progress.name);
			apathyBar= GameObject.FindGameObjectWithTag("apathyBar");
				print(apathyBar.name);
			apathy = apathyBar.GetComponent<Slider>();
				print(apathy.name);
		}catch(Exception ex ){
			UnityEngine.Debug.LogError ("Error in "+this.name +" please check row "+ex.ToString ().Split (':') [3]+" in script: ");			
			UnityEditor.EditorApplication.isPlaying = false;
			UnityEditor.EditorApplication.isPaused = true;

		}
	}
	
	void Update () {
		
		Stats.timeleft=Stats.totalTime-Time.timeSinceLevelLoad;
		if (Stats.timeleft <= 0) {
			Game.end ();
		}

		if (Stats.wordCount != 0) {
			val = ( (float)Stats.wordCount / Stats.maxWordCount);
			//Debug.Log (Stats.maxWordCount+ " of " + Stats.wordCount +" %"+val);
			if (val >= 1) {
				//print ("LEVEL CLEAR!!!");   
				Game.end();
			}
			progress.value = val;
		}
		if (Stats.apathy != 0) {
			val = ( (float)Stats.apathy / Stats.maxApathy);
			//Debug.Log (Stats.maxApathy+ " of " + Stats.apathy +" %"+val);
			if (val <= 0.01f) {
				//print ("LEVEL CLEAR!!!");   
				Game.end();
			}
			apathy.value = val;
			desaturation.saturation = 1-val;
		}
		Stats.regenApathy ();


	}


}
