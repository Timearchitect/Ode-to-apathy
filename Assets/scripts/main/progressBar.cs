using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressBar : MonoBehaviour {
	private GameObject go;
	float val=0.0f;
	private Slider progress;
	// Use this for initialization

	void Start () {
		//go = this.gameObject;
		go= GameObject.FindGameObjectWithTag("progressBar");
		progress = go.GetComponent<Slider>();
	/*	if (progress != null) {
			print("got it");
		}*/
	}
	
	void Update () {

		if (Stats.wordCount != 0) {
			val = ( (float)Stats.wordCount / Stats.maxWordCount);
			Debug.Log (Stats.maxWordCount+ " of " + Stats.wordCount +" %"+val);
			if (val >= 1) {
				print ("LEVEL CLEAR!!!");   
			}
			progress.value = val;
		}

	}

}
