using System.Collections;
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
	private bool skip;
	// Use this for initialization

	public dialogs initialize(string filename,Vector3 pos){
		transform.position = pos;
		fileSource = filename;
		return this;		
	}

	void Start () {
		try{
			print("start dialog");
			textFile = Resources.Load (fileSource) as TextAsset;
			if(textFile!=null){
				textLines=textFile.text.Split ('\n');
			}
			//print (textLines[0]);
			content = GetComponent<Text>();
			content = GetComponentsInChildren<Text> ()[0]; 

			if (content != null) {
				content.text = textLines [0];
			} else
				print (fileSource+".txt is missing");
		}catch{
			UnityEngine.Debug.LogError ("Error in "+this.name +" please check in script: ");
			UnityEditor.EditorApplication.isPlaying = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown && !Game.pause) {
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
