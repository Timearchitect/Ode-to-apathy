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
	public AudioSource bgmR,cafeR,bgmL,cafeL;
	private UnityEngine.UI.Text t;
	private Animation animation;
	private AnimationClip typing,drawing;
	public AudioSource[] aS;

	Vector3 pastMousePos = new Vector3();
	// Use this for initialization
	void Start () {
		try{
			animation = GameObject.FindGameObjectWithTag ("Player").GetComponent<Animation>();
				print (animation.name +" found");
			typing= animation.GetClip ("Typing");
				print(typing.name);
			drawing= animation.GetClip ("Drawing");
				print(drawing.name);
			debugContent = GameObject.FindGameObjectWithTag("debug");
				//print(debugContent.name);
			bgmR =GameObject.Find("maching Right").GetComponent<AudioSource> ();
				print(bgmR.name);
			cafeR = GameObject.Find("Cafe bgm Right").GetComponent<AudioSource> ();
				print(cafeR.name);
			bgmL =GameObject.Find("maching Left").GetComponent<AudioSource> ();
				print(bgmL.name);
			cafeL = GameObject.Find("Cafe bgm Left").GetComponent<AudioSource> ();
				print(cafeL.name);

			duration = 0.5f;
			leftEyeOverlay = GameObject.Find ("leftEye").GetComponent<Image> ();
			print(leftEyeOverlay.name);
			rightEyeOverlay = GameObject.Find ("rightEye").GetComponent<Image> ();	
			print(rightEyeOverlay.name);
			aS = (AudioSource[])GameObject.FindObjectsOfType (typeof(AudioSource));
			print(aS);
		}catch(Exception ex ){
			UnityEngine.Debug.LogError ("Error in "+this.name +" please check row "+ex.ToString ().Split (':') [3]+" in script: ");			
			UnityEditor.EditorApplication.isPlaying = false;
			UnityEditor.EditorApplication.isPaused = true;

		}
	}
	void Awake () {
		print ("Awake keyBoard!!!    !!!");
		Start ();
	}
	// Update is called once per frame
	void Update () {
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
			if (bgmL.isPlaying) {
				bgmL.Pause ();
			}
			if (bgmR.isPlaying) {
				bgmR.Pause ();
			}
		}
			detectPressedKeyOrButton ();
			detectReleasedKeyOrButton ();

		if (Stats.workMode == 1) { //Mouse Mode
			if (Vector3.Distance (Input.mousePosition, pastMousePos) > 10) {
				Stats.wordCount += Stats.penSpeed;
				Stats.drawProgess += Stats.penSpeed;
				circleTimer.render ();
				pastMousePos = Input.mousePosition;
				animation.Play (drawing.name);
				if(Stats.drawProgess >= Stats.maxDrawProgress){
					Stats.shiftMode ();
				}
			}
		}
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

				if (Input.GetKeyDown (KeyCode.LeftControl)) {
					leftEyeOverlay.color = new Color (0f, 0f, 0f, 0.35f); 
				}

				if (Input.GetKeyDown (KeyCode.RightControl)) {
					rightEyeOverlay.color = new Color (0f, 0f, 0f, 0.35f);
				}

				if (Input.GetKeyDown (KeyCode.LeftShift) && cafeL.bypassEffects ) {
					coverLeftEar();
				}

				if (Input.GetKeyDown (KeyCode.RightShift)&& cafeR.bypassEffects) {
					coverRightEar ();
				}

				//Debug.Log ("KeyCode down: " + kcode+ " count: "+wordCount +"  time:"+timer );
				if (Stats.workMode == 0  && !Input.GetKeyDown (KeyCode.LeftControl)  && !Input.GetKeyDown (KeyCode.RightControl)  && !Input.GetKeyDown (KeyCode.LeftShift) && !Input.GetKeyDown (KeyCode.RightShift)) { // KeyBoard mode
					if (vacant) {
						Stats.wordCount += Stats.typeSpeed;
						Stats.codeProgess += Stats.typeSpeed;
						circleTimer.render ();
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
					if(!bgmR.isPlaying) bgmR.Play();
					if(!bgmL.isPlaying) bgmL.Play();
				}

				//print (this.name);
	
			}
			if (Input.GetKeyUp (KeyCode.LeftControl)) {
				leftEyeOverlay.color = new Color (0f, 0f, 0f, 0.0f); 
			}
			if (Input.GetKeyUp (KeyCode.RightControl)) {
				rightEyeOverlay.color = new Color (0f, 0f, 0f, 0.0f);
			}
			if (Input.GetKeyUp (KeyCode.LeftShift)) {
				openLeftEar();
			}
			if (Input.GetKeyUp (KeyCode.RightShift)) {
				openRightEar ();
			}
		}

	}

	public void coverLeftEar(){
		cafeL.volume = 0.005f;
		bgmL.volume = 0.01f;
		cafeL.bypassEffects = false;
		bgmL.bypassEffects = false;
			/*foreach (AudioSource a in aS) {
				a.GetComponent<AudioSource> ().bypassEffects = false;
			}*/
		//print ("closed");
	}
	public void coverRightEar(){
		cafeR.volume = 0.005f;
		bgmR.volume = 0.01f;
		cafeR.bypassEffects = false;
		bgmR.bypassEffects = false;
		/*foreach (AudioSource a in aS) {
			a.GetComponent<AudioSource> ().bypassEffects = false;
		}*/
		//print ("closed");
	}
	public void openRightEar(){
		cafeR.volume = 0.1f;
		bgmR.volume = 1f;
		cafeR.bypassEffects = true;
		bgmR.bypassEffects = true;
		/*foreach (AudioSource a in aS) {
			a.GetComponent<AudioSource> ().bypassEffects = true;
		}*/
		//print ("open");
	}
	public void openLeftEar(){
		cafeL.volume = 0.1f;
		bgmL.volume = 1f;
		cafeL.bypassEffects = true;
		bgmL.bypassEffects = true;
		/*foreach (AudioSource a in aS) {
			a.GetComponent<AudioSource> ().bypassEffects = true;
		}*/
		//print ("open");
	}
}