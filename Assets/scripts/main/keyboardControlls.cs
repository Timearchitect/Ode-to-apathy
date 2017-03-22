using UnityEngine;
using UnityEngine.UI;

using System;
using System.Collections;
using System.Collections.Generic;

public class keyboardControlls : MonoBehaviour {
	public GameObject debugContent;
	public Image leftEyeOverlay,rightEyeOverlay;
	//public static float wordCount=0f;
	public float timer=0,duration;
	private bool vacant=true;
	private bool lv,rv,la,ra;
	public AudioSource workR,cafeR,workL,cafeL,disL,disR;
	private UnityEngine.UI.Text t;
	private Animation animation;
	private AnimationClip typing,drawing;
	public AudioSource[] aS;
	//private keyboardControlls visualLKey ='2',visualRKey='9',audioRKey='1', audioLKey='0';
	private KeyCode visualLKey,visualRKey,audioRKey, audioLKey;
	Vector3 pastMousePos = new Vector3();
	// Use this for initialization
	void Start () {
		try{
			if(SystemInfo.operatingSystemFamily==OperatingSystemFamily.Windows){
				visualLKey=KeyCode.LeftControl;
				visualRKey=KeyCode.RightControl;
				audioLKey=KeyCode.LeftShift;
				audioRKey=KeyCode.RightShift;
			}
			if(SystemInfo.operatingSystemFamily==OperatingSystemFamily.MacOSX){
				visualLKey=KeyCode.LeftCommand;
				visualRKey=KeyCode.RightCommand;
				audioLKey=KeyCode.LeftAlt;
				audioRKey=KeyCode.RightAlt;

			}
			print(SystemInfo.operatingSystemFamily);
			animation = GameObject.FindGameObjectWithTag ("Player").GetComponent<Animation>();
				print (animation.name +" found");
			typing= animation.GetClip ("Typing");
				print(typing.name);
			drawing= animation.GetClip ("Drawing");
				print(drawing.name);
			debugContent = GameObject.FindGameObjectWithTag("debug");
				//print(debugContent.name);
			workR =GameObject.Find("maching Right").GetComponent<AudioSource> ();
				print(workR.name);
			cafeR = GameObject.Find("Cafe bgm Right").GetComponent<AudioSource> ();
				print(cafeR.name);
			workL =GameObject.Find("maching Left").GetComponent<AudioSource> ();
				print(workL.name);
			cafeL = GameObject.Find("Cafe bgm Left").GetComponent<AudioSource> ();
				print(cafeL.name);
			disR = GameObject.Find("distraction Right").GetComponent<AudioSource> ();
				print(disR.name);
			disL = GameObject.Find("distraction Left").GetComponent<AudioSource> ();
				print(disL.name);

			duration = 0.5f;
			leftEyeOverlay = GameObject.Find ("leftEye").GetComponent<Image> ();
			print(leftEyeOverlay.name);
			rightEyeOverlay = GameObject.Find ("rightEye").GetComponent<Image> ();	
			print(rightEyeOverlay.name);
			aS = (AudioSource[])GameObject.FindObjectsOfType (typeof(AudioSource));
			print(aS);
		}catch(Exception ex ){
			UnityEngine.Debug.LogError ("Error in "+this.name +" please check row "+ex.ToString ().Split (':') [3]+" in script: ");			
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			UnityEditor.EditorApplication.isPaused = true;
			#endif
		}
	}
/*	void Awake () {
		print ("Awake keyBoard!!!    !!!");
		Start ();
	}*/
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F12)) {
			print ("CHEATMODE ENABLED!!!!!!!!!!!!!!!!!!!!!!!!!!!1");
			Game.enableCheatMode();
		}
	/*	float hVal = Input.GetAxis ("Horizontal"); 
		float vVal = Input.GetAxis ("Vertical"); 

		if (hVal < 0) {
			print ("left:" + hVal);
		}
		if (vVal < 0) {
			print("down:"+vVal);
		}
		if (hVal >0) {
			print ("right:" + hVal);
		}
		if (vVal > 0) {
			print("up:"+vVal);
		}
*/
		if (timer + duration < Time.time) {
			if (workL.isPlaying) {
				workL.Pause ();
			}
			if (workR.isPlaying) {
				workR.Pause ();
			}
		}
		if(!Game.pause){
			detectPressedKeyOrButton ();
			detectReleasedKeyOrButton ();
			detectMouseMovement ();
			//if (Stats.workMode != Stats.pWorkMode) {
			//shift
			//}

			if(lv)increaseBlinds(leftEyeOverlay);
			else decreaseBlinds(leftEyeOverlay);
			if(rv)increaseBlinds(rightEyeOverlay);
			else decreaseBlinds(rightEyeOverlay);

			if (Input.GetKeyDown (visualLKey)) { 
				lv=true;
				//leftEyeOverlay.color = new Color (0f, 0f, 0f, leftEyeOverlay.color.a+.02f); 
				//leftEyeOverlay.color = new Color (0f, 0f, 0f, 0.35f); 
				//increaseBlinds(leftEyeOverlay);
			}

			if (Input.GetKeyDown (visualRKey)) {
				rv=true;
				//rightEyeOverlay.color = new Color (0f, 0f, 0f, rightEyeOverlay.color.a+.02f); 
				//rightEyeOverlay.color = new Color (0f, 0f, 0f, 0.35f);
				//increaseBlinds(rightEyeOverlay);
			}

		/*if (Input.GetKeyDown (KeyCode.LeftShift) && cafeL.bypassEffects ) {
			coverLeftEar();
		}

		if (Input.GetKeyDown (KeyCode.RightShift)&& cafeR.bypassEffects) {
			coverRightEar ();
		}*/
			if (Input.GetKeyUp (visualLKey)) {			
				lv = false;
			//leftEyeOverlay.color = new Color (0f, 0f, 0f, leftEyeOverlay.color.a-.02f); 
			//decreaseBlinds(leftEyeOverlay);
			}
			if (Input.GetKeyUp (visualRKey)) {
				rv = false;
			//rightEyeOverlay.color = new Color (0f, 0f, 0f, rightEyeOverlay.color.a-.02f);
		//	decreaseBlinds(rightEyeOverlay);
			}
		}
		/*if (Input.GetKeyUp (KeyCode.LeftShift)) {
			openLeftEar();
		}
		if (Input.GetKeyUp (KeyCode.RightShift)) {
			openRightEar ();
		}*/
		//pastMousePos = Input.mousePosition;
	}

	public void detectReleasedKeyOrButton(){
		vacant = true;
		/*foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode))) {
			if (Input.GetKeyDown (kcode)) {
				vacant = false;
				print (kcode);
			}
		}*/
	}

	public void detectPressedKeyOrButton(){
		
		foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode))){

			if (Input.GetKeyDown (kcode)) {
				/*if (Input.GetKeyDown (KeyCode.LeftControl)) {
					//if(leftEyeOverlay.color.a<0.35f)leftEyeOverlay.color = new Color (0f, 0f, 0f, leftEyeOverlay.color.a+.02f); 
					leftEyeOverlay.color = new Color (0f, 0f, 0f, 0.35f); 
				}
				if (Input.GetKeyDown (KeyCode.RightControl)) {
					//if(rightEyeOverlay.color.a<0.35f)rightEyeOverlay.color = new Color (0f, 0f, 0f, rightEyeOverlay.color.a+.02f); 
					rightEyeOverlay.color = new Color (0f, 0f, 0f, 0.35f);
				}*/

				if (Input.GetKeyDown (audioLKey) && cafeL.bypassEffects ) {
					coverLeftEar();
				}

				if (Input.GetKeyDown (audioRKey)&& cafeR.bypassEffects) {
					coverRightEar ();
				}
		
				//Debug.Log ("KeyCode down: " + kcode+ " count: "+wordCount +"  time:"+timer );
				if (Stats.workMode == 0  && !Input.GetKeyDown (audioLKey)  && !Input.GetKeyDown (audioRKey)  && !Input.GetKeyDown (visualLKey) && !Input.GetKeyDown (visualLKey)) { // KeyBoard mode
					if (vacant) {
						Stats.wordCount += Stats.typeSpeed;
						Stats.codeProgess += Stats.typeSpeed;
						circleTimer.render ();
						progressBar.highlight ();
						if (Stats.codeProgess >= Stats.maxCodeProgress) {
							Stats.shiftMode ();
						}
						//	t.text = t.text.ToString () + kcode;
//						t.GraphicUpdateComplete ();
						//Canvas.ForceUpdateCanvases ();
						vacant = false;
					}
					if (animation.IsPlaying (drawing.name))animation.Stop (drawing.name);
					animation.Play (typing.name);
					timer = Time.time;
					if(!workR.isPlaying) workR.Play();
					if(!workL.isPlaying) workL.Play();
				}
				//print (this.name);
			}
			/*if (Input.GetKeyUp (KeyCode.LeftControl)) {
				leftEyeOverlay.color = new Color (0f, 0f, 0f, 0.0f); 
				//if(leftEyeOverlay.color.a>.02f)leftEyeOverlay.color = new Color (0f, 0f, 0f, leftEyeOverlay.color.a-.02f); 
			}
			if (Input.GetKeyUp (KeyCode.RightControl)) {
				rightEyeOverlay.color = new Color (0f, 0f, 0f, 0.0f);
				//if(rightEyeOverlay.color.a>.02f)rightEyeOverlay.color = new Color (0f, 0f, 0f, rightEyeOverlay.color.a-.02f);
			}*/
			if (Input.GetKeyUp (audioLKey)) {
				openLeftEar();
			}
			if (Input.GetKeyUp (audioRKey)) {
				openRightEar ();
			}
		}

	}
	public void detectMouseMovement(){
		if (Stats.workMode == 1) { //Mouse Mode
			if (Vector3.Distance (Input.mousePosition, pastMousePos) > Stats.mouseRegisterDist) {
				Stats.wordCount += Stats.penSpeed;
				Stats.drawProgess += Stats.penSpeed;
				circleTimer.render ();
				progressBar.highlight ();
				pastMousePos = Input.mousePosition;
				animation.Play (drawing.name);
				timer = Time.time;
				if(!workR.isPlaying) workR.Play(); 
				if(!workL.isPlaying) workL.Play();
				if(Stats.drawProgess >= Stats.maxDrawProgress){
					Stats.shiftMode ();
				}
			}
		}
	}

	public void increaseBlinds(Image img){
		if(img.color.a<Stats.visualCoverMax)img.color = new Color (0,0,0, img.color.a+Stats.fadeRate);
	}
	public void decreaseBlinds(Image img){
		if(img.color.a>0)img.color = new Color (0,0,0, img.color.a-Stats.fadeRate);
	}
		
	public void coverLeftEar(){
		cafeL.volume = 0.005f;
		workL.volume = 0.01f;
		disL.volume = 0.01f;
		cafeL.bypassEffects = false;
		workL.bypassEffects = false;
		disL.bypassEffects = false;
			/*foreach (AudioSource a in aS) {
				a.GetComponent<AudioSource> ().bypassEffects = false;
			}*/
		//print ("closed");
	}
	public void coverRightEar(){
		cafeR.volume = 0.005f;
		workR.volume = 0.01f;
		disR.volume = 0.01f;
		cafeR.bypassEffects = false;
		workR.bypassEffects = false;
		disR.bypassEffects = false;
		/*foreach (AudioSource a in aS) {
			a.GetComponent<AudioSource> ().bypassEffects = false;
		}*/
		//print ("closed");
	}
	public void openRightEar(){
		cafeR.volume = 0.1f;
		workR.volume = 1f;
		disR.volume = 1f;
		cafeR.bypassEffects = true;
		workR.bypassEffects = true;
		disR.bypassEffects = true;
		/*foreach (AudioSource a in aS) {
			a.GetComponent<AudioSource> ().bypassEffects = true;
		}*/
		//print ("open");
	}
	public void openLeftEar(){
		cafeL.volume = 0.1f;
		workL.volume = 1f;
		disL.volume = 1f;
		cafeL.bypassEffects = true;
		workL.bypassEffects = true;
		disL.bypassEffects = true;
		/*foreach (AudioSource a in aS) {
			a.GetComponent<AudioSource> ().bypassEffects = true;
		}*/
		//print ("open");
	}
}