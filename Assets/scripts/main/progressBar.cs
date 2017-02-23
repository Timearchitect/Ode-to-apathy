using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressBar : MonoBehaviour {
	private GameObject go;
	float val=0.0f;
	private Slider progress;
	int maxWordCount=50;
	// Use this for initialization
	void Start () {
		//go = this.gameObject;
		go= GameObject.FindGameObjectWithTag("progressBar");
		Debug.Log(go.name);
		progress = go.GetComponent<Slider>();
		if (progress != null) {
			print("got it");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		//val += 0.05f; 

		//val=(keyboardControlls.wordCount*0.001f);
		if (keyboardControlls.wordCount != 0) {
			val = ( (float)keyboardControlls.wordCount / maxWordCount);
			Debug.Log (maxWordCount+ " of " + keyboardControlls.wordCount +" %"+val);
			if (val >= 1) {
				print ("LEVEL CLEAR!!!");   
				//coverEyes.alphaL = 1;
				//coverEyes.alphaR = 0;
			}
			progress.value = val;
	
		}

	}
}
