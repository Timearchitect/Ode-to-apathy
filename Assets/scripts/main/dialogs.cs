using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogs : MonoBehaviour {

	[SerializeField]
	public string fileSource="Dialogues";
	private TextAsset textFile;
	private string[] textLines;
	private Text content;
	private int line=0;
	private float timer;
	private bool skip;
	// Use this for initialization

	public dialogs initialize(string filename,Vector3 pos){
		transform.position = pos;
		fileSource = filename;
		return this;		
	}

	void Start () {
		try{
			textFile = Resources.Load (fileSource) as TextAsset;
			print(textFile.name);
			if(textFile!=null){
				textLines=textFile.text.Split ('\n');
			}
			content = GetComponentsInChildren<Text> ()[0]; 
			print(content.name);

			if (content != null) {
				content.text = textLines [0];
			} else
				print (fileSource+".txt is missing");
		}catch(Exception ex ){
			UnityEngine.Debug.LogError ("Error in "+this.name +" please check row "+ex.ToString ().Split (':') [3]+" in script: ");			
			UnityEditor.EditorApplication.isPlaying = false;
			UnityEditor.EditorApplication.isPaused = true;

		}
	}
	
	// Update is called once per frame
	void Update () {
		if (timer+2.5<Time.time  && !Game.pause) { //Input.anyKeyDown
			timer=Time.time;
			if (line < textLines.Length - 1) {
				line++;
				content.text = textLines [line];
			} else {
				print (this.gameObject+"typing destroy!!!");
				Destroy (gameObject);
			}
		}
		if ( skip ) {
			Destroy (gameObject);
			print (this.gameObject+"destroy!!!");
		}
	}

	public void destroy(){
		print("destroy?");
		line = textLines.Length;
		skip = true;
		//Destroy (this.gameObject);
	}
}
