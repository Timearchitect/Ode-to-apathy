using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogs : MonoBehaviour {
	TextAsset textFile;
	string[] textLines;
	Text content;
	int line=0;
	// Use this for initialization
	void Start () {
		textFile = Resources.Load ("Dialogues") as TextAsset;
		if(textFile!=null){
			textLines=textFile.text.Split ('\n');
		}
		print (textLines[0]);
		content = GetComponent<Text>();
		content = GetComponentsInChildren<Text> ()[0]; 

		if (content != null) {
			content.text = textLines [0];
		} else
			print ("dialogs is missing");


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown && !Game.pause) {
			if (line < textLines.Length-1) {
				line++;
				content.text = textLines [line];
			}
		}
	}
}
