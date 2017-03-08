using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressBar : MonoBehaviour {
	private GameObject go,apathyBar;
	float val=0.0f;
	private Slider progress,apathy;

	void Start () {
		go= GameObject.FindGameObjectWithTag("progressBar");
		progress = go.GetComponent<Slider>();
		apathyBar= GameObject.FindGameObjectWithTag("apathyBar");
		apathy = apathyBar.GetComponent<Slider>();

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
				print ("LEVEL CLEAR!!!");   
				Game.end();
			}
			progress.value = val;
		}
		if (Stats.apathy != 0) {
			val = ( (float)Stats.apathy / Stats.maxApathy);
			//Debug.Log (Stats.maxApathy+ " of " + Stats.apathy +" %"+val);
			if (val <= 0.01f) {
				print ("LEVEL CLEAR!!!");   
				Game.end();
			}
			apathy.value = val;
		}
		Stats.regenApathy ();


	}


}
