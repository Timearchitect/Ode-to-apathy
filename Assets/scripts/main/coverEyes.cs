using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class coverEyes : MonoBehaviour {
	private GameObject leftEye,rightEye,camera;
	private Image leftGradient,rightGradient;
	//public static float alphaL;
	//public static float alphaR=1.0f;
	//private Animation animation;
	public AudioSource cafeL,bgmL,disL,cafeR,bgmR,disR;
	public static Image whiteFade; 
	private AnimationClip coverAnim;
	private GameObject[] enemies;
	private static BlurOptimized filter;
	private float audioFadeAmount= 0.05f;
	public static bool fadeIn,fadeOut;
	//private Camera camera;
	private Color transp = new Color (1,1,1,.4f);  
	// Use this for initialization
	void Start () {
		try{

			cafeL = GameObject.Find ("Cafe bgm Left").GetComponent<AudioSource> ();
			bgmL = GameObject.Find ("maching Left").GetComponent<AudioSource> ();
			disL = GameObject.Find ("distraction Left").GetComponent<AudioSource> ();
			cafeR = GameObject.Find ("Cafe bgm Left").GetComponent<AudioSource> ();
			bgmR = GameObject.Find ("maching Left").GetComponent<AudioSource> ();
			disR = GameObject.Find ("distraction Left").GetComponent<AudioSource> ();

			whiteFade = GameObject.Find ("whiteFade").GetComponent<Image> ();
			print(whiteFade.name);
			leftEye = GameObject.Find ("leftEye");
			print(leftEye.name);
			rightEye = GameObject.Find ("rightEye");
			print(rightEye.name);
			leftGradient=leftEye.GetComponent<Image> ();
			rightGradient=rightEye.GetComponent<Image> ();
			enemies = GameObject.FindGameObjectsWithTag ("enemy");
			print(enemies);
			camera= GameObject.Find("Camera");
			print(camera.name);				
			filter=camera.GetComponent<BlurOptimized>();
			print(enemies);
			coverEyes.FadeIn ();
		}catch(Exception ex ){
			UnityEngine.Debug.LogError ("Error in "+this.name +" please check row "+ex.ToString ().Split (':') [3]+" in script: ");			
			UnityEditor.EditorApplication.isPlaying = false;
			UnityEditor.EditorApplication.isPaused = true;
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (1)) {
			FadeOut ();
		}
		if (Input.GetMouseButtonDown (0)) {
			FadeIn ();
		}
		//print(leftEye.GetComponent<Image> ().color.a + "   blackness");
		//print(rightEye.GetComponent<Image> ().color.a + "   blackness");
		//if (leftEye.GetComponent<Image> ().color.a > 0.25f || rightEye.GetComponent<Image> ().color.a > 0.25f) { // transparent effect
		if (leftGradient.color.a > 0.25f || rightGradient.color.a > 0.25f) { // transparent effect
			foreach (GameObject e in enemies) {
				//if(e!=null)e.GetComponent<SpriteRenderer> ().color = new Color (e.GetComponent<SpriteRenderer> ().color.r, e.GetComponent<SpriteRenderer> ().color.g, e.GetComponent<SpriteRenderer> ().color.b, 0.3f);			
				if(e!=null)e.GetComponent<SpriteRenderer> ().color = transp;
			}
			//Game.pause = true;
		} else {
			foreach (GameObject e in enemies) {
				//if(e!=null)e.GetComponent<SpriteRenderer> ().color = new Color (e.GetComponent<SpriteRenderer> ().color.r, e.GetComponent<SpriteRenderer> ().color.g, e.GetComponent<SpriteRenderer> ().color.b, 1f);			
				if(e!=null)e.GetComponent<SpriteRenderer> ().color = Color.white;
			}
		}
		if (fadeIn) {
			whiteFade.color = new Color (1,1,1,whiteFade.color.a -0.03f);
			if (filter.blurSize <= 0) {
				fadeIn = false;
				filter.enabled = false;
			}
			else filter.enabled = true;
			cafeL.volume = cafeL.volume+audioFadeAmount;
			bgmL.volume = bgmL.volume+audioFadeAmount;
			disL.volume  = disL.volume +audioFadeAmount;
			cafeR.volume = cafeR.volume+audioFadeAmount;
			bgmR.volume  = bgmR.volume+audioFadeAmount;
			disR.volume = disR.volume+audioFadeAmount;
			filter.blurSize -= 0.2f;
			filter.blurIterations = Mathf.RoundToInt(filter.blurSize*0.5f);
		}
		if (fadeOut) {
			whiteFade.color = new Color (1,1,1,whiteFade.color.a +0.03f);
			if (whiteFade.color.a >= 1) {
				fadeOut = false;
				filter.enabled = false;
				Game.pause = true;
			}
			else 
				filter.enabled = true;
			
			filter.blurSize += 0.4f;
			filter.blurIterations = Mathf.RoundToInt(filter.blurSize*.5f);
			cafeL.volume = cafeL.volume-audioFadeAmount;
			bgmL.volume = bgmL.volume-audioFadeAmount;
			disL.volume  = disL.volume -audioFadeAmount;
			cafeR.volume = cafeR.volume-audioFadeAmount;
			bgmR.volume  = bgmR.volume-audioFadeAmount;
			disR.volume = disR.volume-audioFadeAmount;
		}
		//  animation.Stop (coverAnim.name);
		//  if (alpha >= 1)
		//	alpha = 0;
	}
	public static void FadeIn(){
		if (!fadeIn) {
			fadeOut = false;
			fadeIn = true;
			whiteFade.color = new Color (1, 1, 1, 1);
			filter.enabled = true;
			filter.blurSize = 8;
			filter.blurIterations = 4;
		}
	} 
	public static void FadeOut(){
		if (!fadeOut) {
			fadeOut = true;
			fadeIn = false;
			whiteFade.color = new Color (1, 1, 1, 0);
			//filter.enabled =false;
			filter.blurSize = 0;
			filter.blurIterations = 1;
		}
	} 
}
