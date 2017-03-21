using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bystander : MonoBehaviour {
	//int range;
	private float wobbleMagnitude= 0.06f,walkWobble;
	private GameObject self;
	void Start () {
		try{
		//range=100;
			self=this.gameObject;
		}catch(Exception ex ){
			UnityEngine.Debug.LogError ("Error in "+this.name +" please check row "+ex.ToString ().Split (':') [3]+" in script: ");			
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			UnityEditor.EditorApplication.isPaused = true;
			#endif
		}
	}
		
	void Update () {
		wobble ();
	}

	public void wobble(){
		if (!Game.pause) {
			walkWobble += 0.08f;
			self.transform.position = new Vector3 (self.transform.position.x+ Mathf.Cos (walkWobble) * wobbleMagnitude*0.5f, self.transform.position.y + Mathf.Sin (walkWobble) * wobbleMagnitude, self.transform.position.z);
		}
	}

/*	public void spawnDialogBox(){
		print ("spawn");
		if (dialogCanvas != null) {
			print ("instansiate");
			print ("height"+this.spriteRenderer.sprite.bounds.size.y*this.transform.localScale.y);
			//Object.Instantiate (dialog.initialize (textFileName, new Vector3 (Random.Range (-200, 200), Random.Range (0, 250), -50)));
			dialog=UnityEngine.Object.Instantiate (dialog.initialize (textFileName, new Vector3 (this.transform.position.x,this.transform.position.y+this.spriteRenderer.sprite.bounds.size.y*.7f*this.transform.localScale.y,this.transform.position.z)));
			if (Game.Conditions.visualLeft == condition || Game.Conditions.audioLeft == condition) {
				dialog.transform.localScale = new Vector3 (-dialog.transform.localScale.x, dialog.transform.localScale.y, dialog.transform.localScale.z);
				dialog.GetComponentInChildren<Text> ().transform.localScale = new Vector3 (-dialog.GetComponentInChildren<Text> ().transform.localScale.x, dialog.GetComponentInChildren<Text> ().transform.localScale.y, dialog.GetComponentInChildren<Text> ().transform.localScale.z);
				dialog.transform.position = new Vector3 (dialog.transform.position.x-30,dialog.transform.position.y,dialog.transform.position.z);
			} else {
				dialog.transform.position = new Vector3 (dialog.transform.position.x+30,dialog.transform.position.y,dialog.transform.position.z);
			}
			//dialog=UnityEngine.Object.Instantiate (dialog.initialize (textFileName, new Vector3 (UnityEngine.Random.Range (-200, 200),UnityEngine.Random.Range (0, 250), -50)));
		}
	}*/

}