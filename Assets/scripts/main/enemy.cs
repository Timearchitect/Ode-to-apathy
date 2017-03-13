using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour {
	private GameObject self,player;
	private GameObject leftEye,rightEye;

	//int range;
	private float wobbleMagnitude= 0.5f,walkWobble;
	public SpriteRenderer spriteRenderer;
	//private GameObject bgm;
	private SpriteRenderer body,head;
	[SerializeField]
	public GameObject dialogCanvas;
	private dialogs dialog;

	public string textFileName="Dialogues";
	private GameObject leftPath,rightPath;
	private AudioSource cafeL,cafeR;
	[SerializeField]
	public Game.Conditions condition;
	private int spriteIndex;
	public bool satisfied=false,generated=true;
	//private Vector3 thisPos;
	private follow followscript;
	// Use this for initialization
	void Start () {
	try{
	
		followscript = this.GetComponent ("follow")as follow;
			print(followscript.name);
		leftPath=GameObject.Find ("leftPath")as GameObject;
			print(leftPath.name);
		rightPath=GameObject.Find ("rightPath")as GameObject;
			print(rightPath.name);
			condition=(Game.Conditions)UnityEngine.Random.Range(0,4);  // 0 = RightEye, 1 = LeftEye, 2 = RightEars , 3 = LeftEars 
			spriteIndex=UnityEngine.Random.Range(0,4);   
		leftEye = GameObject.Find ("leftEye");
			print(leftEye.name);
		rightEye = GameObject.Find ("rightEye");
			print(rightEye.name);
		cafeR = GameObject.Find ("Cafe bgm Right").GetComponent<AudioSource> ();
			print(cafeR.name);
		cafeL = GameObject.Find ("Cafe bgm Left").GetComponent<AudioSource> ();
			print(cafeL.name);
		head = GameObject.Find("Head").GetComponent<SpriteRenderer>();
			print(head.name);
		//speed=0.01f;
		//range=100;
		self= this.gameObject;
			print(self.name);
		spriteRenderer = self.GetComponent("SpriteRenderer") as SpriteRenderer;
			print(spriteRenderer.name);
		randomize ();
		player = GameObject.FindGameObjectWithTag ("Player");
			print(player.name);

		body = GameObject.Find("Body").GetComponent<SpriteRenderer>();
			print(body.name);
		}catch(Exception ex ){
			UnityEngine.Debug.LogError ("Error in "+this.name +" please check row "+ex.ToString ().Split (':') [3]+" in script: ");			
			UnityEditor.EditorApplication.isPlaying = false;
			UnityEditor.EditorApplication.isPaused = true;

		}
}


	void LateUpdate () {
		/*
		if (Vector3.Distance (self.transform.position, player.transform.position) > range) {
			self.transform.position = Vector3.Lerp (self.transform.position, player.transform.position, speed);
		} else {
			print ("to complete this event you need :" +condition);
		}
		*/
		if (Game.cheatMode && Input.GetMouseButtonDown(1)) {
			satisfied = !satisfied;
			print (this.name +" with "+condition+"  :  "+ satisfied);
		}
			switch(condition){
		case Game.Conditions.visualRight:
					if (this.GetComponent<follow> ().pause  && rightEye.GetComponent<Image> ().color.a > 0.25f) {
					cleared ();
					}
				break;
		case Game.Conditions.visualLeft:
					if (this.GetComponent<follow> ().pause && leftEye.GetComponent<Image> ().color.a > 0.25f) {
					cleared ();
					}
				break;
		case Game.Conditions.audioRight:
					if (this.GetComponent<follow> ().pause  && cafeR.volume < 0.01f) {
					cleared ();
					}
				break;
		case Game.Conditions.audioLeft:
					if (this.GetComponent<follow> ().pause && cafeL.volume < 0.01f) {
						cleared ();
					}
				break;
			}
		wobble ();
	if (Vector3.Distance (player.transform.position, this.transform.position) < follow.stopDistance) {
			/*if (!followscript.pause && dialog != null) {
				spawnDialogBox ();
			}*/
			if (body.transform.rotation.z < Mathf.PI*0.04f &&player.transform.position.x - this.transform.position.x>50) {
				body.transform.Rotate (0,0,0.4f,Space.World);
				head.sprite= Resources.Load<Sprite> ("head_left") as Sprite;
			}
			if (body.transform.rotation.z > -Mathf.PI*0.04f && player.transform.position.x - this.transform.position.x<-50) {
				body.transform.Rotate (0,0,-0.4f,Space.World);
				head.sprite= Resources.Load<Sprite> ("head_right") as Sprite;
			}
			//print (player.transform.rotation.z+" rotation "+ Mathf.PI*0.1f );
		}else{
			head.sprite= Resources.Load<Sprite> ("head") as Sprite;
		}
	
	}
		
	public void randomize(){
			dialogCanvas= (GameObject)Resources.Load("PreFabs/dialogCanvas", typeof(GameObject));
			//Game.check(dialogCanvas);

			dialog=dialogCanvas.GetComponent<dialogs>();
			//Game.check(dialog);
			print(dialog +" Generated");

		if (generated) {
			condition = (Game.Conditions)UnityEngine.Random.Range (0, 4);    // 0 = RightEye, 1 = LeftEye, 2 = RightEars , 3 = LeftEars 
			spriteIndex = UnityEngine.Random.Range (0, 4);  
		
			if (spriteRenderer == null) {
				print ("null");
			} else {
				switch (spriteIndex) {
				case 0:
					spriteRenderer.sprite = Resources.Load<Sprite> ("barn1") as Sprite;
					break;
				case 1:
					spriteRenderer.sprite = Resources.Load<Sprite> ("gubbe1") as Sprite;
					break;
				case 2:
					spriteRenderer.sprite = Resources.Load<Sprite> ("gubbe3") as Sprite;
					break;
				default :
					spriteRenderer.sprite = Resources.Load<Sprite> ("barn1") as Sprite;
					break;
				}
			}

			switch (condition) {
			case Game.Conditions.visualRight:
				self.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f);  // rIGTH EYE
				followscript.setPath (rightPath);
				//print (self.name + " with " + condition +" color: "+ self.GetComponent<SpriteRenderer> ().color.ToString());
				break;
			case Game.Conditions.visualLeft:
				self.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f); // leftEye eye
				followscript.setPath (leftPath);
				//print (self.name + " with " + condition +" color: "+ self.GetComponent<SpriteRenderer> ().color.ToString());
				break;
			case Game.Conditions.audioRight:
				self.GetComponent<SpriteRenderer> ().color = new Color (0f, 0f, 0f); // right ear
				followscript.setPath (rightPath);
				//print (self.name + " with " + condition + " color: " + self.GetComponent<SpriteRenderer> ().color.ToString ());
				break;
			case Game.Conditions.audioLeft:
				self.GetComponent<SpriteRenderer> ().color = new Color (0f, 0f, 0f); // left ear
				followscript.setPath (leftPath);
				//print (self.name + " with " + condition +" color: "+ self.GetComponent<SpriteRenderer> ().color.ToString());
				break;
			}
		}
	}
	public void cleared(){
		if (!satisfied)Stats.ignoredObstacle++;
		satisfied = true;
		if (dialog != null || dialogCanvas != null){
			//DestroyImmediate (dialogCanvas, true);
			dialog.destroy ();
			print("enemy destroy DIALOG!!");
			//dialog = null;
			//dialogCanvas = null;
		}
		//print (this.name + " with " + condition +" color: "+ self.GetComponent<SpriteRenderer> ().color.ToString());
		//print ("IGNORED!! "+Stats.ignoredObstacle);
	}
	public void wobble(){
		if (!Game.pause) {
			walkWobble += 0.25f;
			self.transform.position = new Vector3 (self.transform.position.x, self.transform.position.y + Mathf.Sin (walkWobble) * wobbleMagnitude, self.transform.position.z);
		}
	}
	public void spawnDialogBox(){
		print ("spawn");
		if (dialogCanvas != null) {
			print ("instansiate");
			//Object.Instantiate (dialog.initialize (textFileName, new Vector3 (Random.Range (-200, 200), Random.Range (0, 250), -50)));
			dialog=UnityEngine.Object.Instantiate (dialog.initialize (textFileName, new Vector3 (UnityEngine.Random.Range (-200, 200),UnityEngine.Random.Range (0, 250), -50)));
		}
	}
}