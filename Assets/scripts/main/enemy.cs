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
	private SpriteRenderer spriteRenderer;

	//private GameObject bgm;
	private SpriteRenderer body,head;
	[SerializeField]
	public Sprite[] sprite;
	//public SpriteRenderer[] sprite;
	public Game.Conditions condition;

	private dialogs dialog;
	public string textFileName;
	public string[] textFile;
	public AudioClip[] soundClip;
	private GameObject leftPath,rightPath;
	private AudioSource cafeL,cafeR,disL,disR;
	private int spriteIndex;
	public bool satisfied=false,generated; //private Vector3 thisPos;
	[HideInInspector]
	public bool firstDialog=true,firstWaveEffect=true;
	private follow followscript; // Use this for initialization
	[HideInInspector]
	public GameObject dialogCanvas;
	[HideInInspector]
	public GameObject soundWave;
	void OnValidate(){

		if (generated && (textFile[0] == "" || textFile[0] == null)) {
			print (this.name + "dialog is generated");
			textFile[0]="Random";
			textFile[1]="Child";
		} else {
			//textFile=new string[2];
		}

		if (generated && soundClip [0] == null) {
			print (this.name + "audio is generated");
			for (int i = 0; i < 2; i++) {
				soundClip [i] = Resources.Load<AudioClip> ("generic_guy" + i);
			}
		} else {
			//soundClip= new AudioClip[1];
		}
	
		if(generated && sprite[0]==null){
			print(this.name +"sprite is generated");
			sprite[0]= Resources.Load<Sprite> ("barn1") as Sprite;
			sprite[1]= Resources.Load<Sprite> ("gubbe1") as Sprite;
			//sprite= Resources.Load<Sprite> ("gubbe3") as Sprite;
			//sprite= Resources.Load<Sprite> ("barn1") as Sprite;
			//}
		}else{
			//sprite =new Sprite[1];
		}
	}

	void Start () {
	try{
		//soundClip[0]=Resources.Load<AudioClip>("generic_guy0");
		//soundClip[1]=Resources.Load<AudioClip>("generic_guy1");
		followscript = this.GetComponent ("follow")as follow;
			print(followscript.name);
		leftPath=GameObject.Find ("leftPath")as GameObject;
			print(leftPath.name);
		rightPath=GameObject.Find ("rightPath")as GameObject;
			print(rightPath.name);
			if(generated){
				condition=(Game.Conditions)UnityEngine.Random.Range(0,4);  // 0 = RightEye, 1 = LeftEye, 2 = RightEars , 3 = LeftEars 
				spriteIndex=UnityEngine.Random.Range(0,4);
			}
		leftEye = GameObject.Find ("leftEye");
			print(leftEye.name);
		rightEye = GameObject.Find ("rightEye");
			print(rightEye.name);
		cafeR = GameObject.Find ("Cafe bgm Right").GetComponent<AudioSource> ();
			print(cafeR.name);
		cafeL = GameObject.Find ("Cafe bgm Left").GetComponent<AudioSource> ();
			print(cafeL.name);
		disR = GameObject.Find ("distraction Right").GetComponent<AudioSource> ();
			print(disR.name);
		disL = GameObject.Find ("distraction Left").GetComponent<AudioSource> ();
			print(disL.name);
		if(soundClip[0]==null){
			print(this.name +"audio is generated");
			for(int i=0; i<soundClip.Length;i++){
				soundClip[i]=Resources.Load<AudioClip>("generic_guy"+i);
				print(i+ " audioclip");
			}
		}else{
		/*	for(int i=0; i<soundClip.Length;i++){
				print(soundClip[i].name);
			}*/
			disL.clip=soundClip[Mathf.RoundToInt(UnityEngine.Random.Range(0,soundClip.Length))];
			disR.clip=soundClip[Mathf.RoundToInt(UnityEngine.Random.Range(0,soundClip.Length))];
		}
		head = GameObject.Find("Head").GetComponent<SpriteRenderer>();
			print(head.name);
			print(Game.disL.name);
			print(Game.disR.name);
			print(Game.cafeL.name);
			print(Game.cafeR.name);
			print(Game.machL.name);
			print(Game.machR.name);
		//speed=0.01f;
		//range=100;
		self= this.gameObject;
			print(self.name);
		spriteRenderer = self.GetComponent("SpriteRenderer") as SpriteRenderer;
			print(spriteRenderer.name);
			print(spriteRenderer.sprite.name);
		//sprite= spriteRenderer.sprite;
		randomize ();
		player = GameObject.FindGameObjectWithTag ("Player");
			print(player.name);
		body = GameObject.Find("Body").GetComponent<SpriteRenderer>();
			print(body.name);
		}catch(Exception ex ){
			Game.check (soundClip[0],"soundClip");
			UnityEngine.Debug.LogError ("Error in "+this.name +" please check row "+ex.ToString ().Split (':') [3]+" in script: ");			
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			UnityEditor.EditorApplication.isPaused = true;
			#endif
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
			//	print (player.transform.rotation.z+" rotation "+ Mathf.PI*0.1f );
		}else{
			head.sprite= Resources.Load<Sprite> ("head") as Sprite;
		}
	
	}
		
	public void randomize(){
			dialogCanvas= (GameObject)Resources.Load("PreFabs/dialogCanvas", typeof(GameObject));
			//	Game.check(dialogCanvas);
			dialog=dialogCanvas.GetComponent<dialogs>();
			//	Game.check(dialog);
			print(dialog +" Generated");

			if (generated) {
				condition = (Game.Conditions)UnityEngine.Random.Range (0, 4);    // 0 = RightEye, 1 = LeftEye, 2 = RightEars , 3 = LeftEars 
				spriteIndex = UnityEngine.Random.Range (0, 4);  

				textFileName = textFile[Mathf.FloorToInt(UnityEngine.Random.Range(0,textFile.Length))];

				if (spriteRenderer == null) {
					print ("null");
				} else {
					/*switch (spriteIndex) {
						case 0:
							spriteRenderer.sprite = Resources.Load<Sprite> ("barn1") as Sprite;
						//	sprite= Resources.Load<Sprite> ("barn1") as Sprite;
							break;
						case 1:
							spriteRenderer.sprite = Resources.Load<Sprite> ("gubbe1") as Sprite;
						//	sprite= Resources.Load<Sprite> ("gubbe1") as Sprite;
							break;
						case 2:
							spriteRenderer.sprite = Resources.Load<Sprite> ("gubbe3") as Sprite;
						//	sprite= Resources.Load<Sprite> ("gubbe3") as Sprite;
							break;
						default :
							spriteRenderer.sprite = Resources.Load<Sprite> ("barn1") as Sprite;
							//sprite= Resources.Load<Sprite> ("barn1") as Sprite;
							break;
					}*/
					spriteRenderer.sprite = sprite[Mathf.FloorToInt(UnityEngine.Random.Range(0,sprite.Length))];

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
					disR.clip=soundClip[Mathf.FloorToInt(UnityEngine.Random.Range(0,soundClip.Length))];
					//print (self.name + " with " + condition + " color: " + self.GetComponent<SpriteRenderer> ().color.ToString ());
					break;
				case Game.Conditions.audioLeft:
					self.GetComponent<SpriteRenderer> ().color = new Color (0f, 0f, 0f); // left ear
					followscript.setPath (leftPath);
					disL.clip=soundClip[Mathf.FloorToInt(UnityEngine.Random.Range(0,soundClip.Length))];
					//print (self.name + " with " + condition +" color: "+ self.GetComponent<SpriteRenderer> ().color.ToString());
					break;
				}
		}


	}
	public void cleared(){
		if (!satisfied)Stats.ignoredObstacle++;
		satisfied = true;
		print (condition+"cleared");
		if( condition == Game.Conditions.visualRight ||  condition == Game.Conditions.visualLeft){
			if (dialog != null || dialogCanvas != null){
				//DestroyImmediate (dialogCanvas, true);
				dialog.destroy ();
				print("enemy destroy DIALOG!!");
				//dialog = null;
				//dialogCanvas = null;
			}
		}
		if (condition == Game.Conditions.audioLeft ) {
			disL.mute = true;
			if (soundWave != null ){
				//DestroyImmediate (dialogCanvas, true);
				Destroy (soundWave);
				print("enemy destroy soundWave!!");
				//dialog = null;
				//dialogCanvas = null;
			}
		}
		if (condition == Game.Conditions.audioRight) {
			disR.mute = true;
			if (soundWave != null){
				//DestroyImmediate (dialogCanvas, true);
				Destroy (soundWave);
				print("enemy destroy soundWave!!");
				//dialog = null;
				//dialogCanvas = null;
			}
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
	public void spawnDistraction(){

		progressBar.highlightApathy() ;
		switch (condition) {
			case Game.Conditions.visualRight:
				spawnDialogBox ();
			break;
			case Game.Conditions.visualLeft:
				spawnDialogBox ();
			break;
		case Game.Conditions.audioRight:
				talk ();
			break;
		case Game.Conditions.audioLeft:
				talk ();
			break;
		}
	}
	public void spawnDialogBox(){
		//print ("spawn");
		if (dialogCanvas != null && firstDialog) {
			firstDialog = false;
			print ("instansiate");
			print ("height"+this.spriteRenderer.sprite.bounds.size.y*this.transform.localScale.y);
			//Object.Instantiate (dialog.initialize (textFileName, new Vector3 (Random.Range (-200, 200), Random.Range (0, 250), -50)));
			dialog=UnityEngine.Object.Instantiate (dialog.initialize (textFileName, new Vector3 (this.transform.position.x,this.transform.position.y+this.spriteRenderer.sprite.bounds.size.y*1.4f*this.transform.localScale.y,this.transform.position.z)));
			if (Game.Conditions.visualLeft == condition || Game.Conditions.audioLeft == condition) {
				dialog.transform.localScale = new Vector3 (-dialog.transform.localScale.x, dialog.transform.localScale.y, dialog.transform.localScale.z);
				dialog.GetComponentInChildren<Text> ().transform.localScale = new Vector3 (-dialog.GetComponentInChildren<Text> ().transform.localScale.x, dialog.GetComponentInChildren<Text> ().transform.localScale.y, dialog.GetComponentInChildren<Text> ().transform.localScale.z);
				dialog.transform.position = new Vector3 (dialog.transform.position.x-30,dialog.transform.position.y,dialog.transform.position.z);
			} else {
				dialog.transform.position = new Vector3 (dialog.transform.position.x+30,dialog.transform.position.y,dialog.transform.position.z);
			}
			//dialog=UnityEngine.Object.Instantiate (dialog.initialize (textFileName, new Vector3 (UnityEngine.Random.Range (-200, 200),UnityEngine.Random.Range (0, 250), -50)));
		}
	}
	public void talk (){
		if (condition == Game.Conditions.audioLeft ) {
			if (firstWaveEffect == true) {
				firstWaveEffect = false;
				soundWave = Instantiate (Resources.Load ("PreFabs/soundEffectPrefab")) as GameObject;
				soundWave.transform.position = new Vector3 (transform.position.x, transform.position.y + spriteRenderer.sprite.bounds.size.y * 0.85f * this.transform.localScale.y, transform.position.z);
			}
			print("talk left");
			disL.clip=soundClip[Mathf.RoundToInt(UnityEngine.Random.Range(0,soundClip.Length))];
			disL.Play ();
			disL.volume = 0.7f;
			disL.mute = false;
		}
		if (condition == Game.Conditions.audioRight) {	
			if (firstWaveEffect == true) {
				firstWaveEffect = false;
				soundWave = Instantiate (Resources.Load ("PreFabs/soundEffectPrefab")) as GameObject;
				soundWave.transform.position = new Vector3 (transform.position.x, transform.position.y + spriteRenderer.sprite.bounds.size.y * 0.85f * this.transform.localScale.y, transform.position.z);
			}
			print("talk right");
			disR.clip=soundClip[Mathf.RoundToInt(UnityEngine.Random.Range(0,soundClip.Length))];
			disR.Play ();
			disR.volume = 0.7f;
			disR.mute = false;
		}
	}
}