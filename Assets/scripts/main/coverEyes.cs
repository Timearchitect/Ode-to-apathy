﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coverEyes : MonoBehaviour {
	private GameObject leftEye,rightEye;
	private Image leftGradient,rightGradient;
	//public static float alphaL;
	//public static float alphaR=1.0f;
	//private Animation animation;
	private AnimationClip coverAnim;
	private GameObject[] enemies;
	private Color transp = new Color (1,1,1,.4f);  
	// Use this for initialization
	void Start () {
		try{
			leftEye = GameObject.Find ("leftEye");
				print(leftEye.name);
			rightEye = GameObject.Find ("rightEye");
				print(rightEye.name);
			leftGradient=leftEye.GetComponent<Image> ();
			rightGradient=rightEye.GetComponent<Image> ();
			enemies = GameObject.FindGameObjectsWithTag ("enemy");
				print(enemies);
		}catch(Exception ex ){
			UnityEngine.Debug.LogError ("Error in "+this.name +" please check row "+ex.ToString ().Split (':') [3]+" in script: ");			
			UnityEditor.EditorApplication.isPlaying = false;
			UnityEditor.EditorApplication.isPaused = true;
		}
	}

	// Update is called once per frame
	void Update () {
		//print(leftEye.GetComponent<Image> ().color.a + "   blackness");
		//print(rightEye.GetComponent<Image> ().color.a + "   blackness");
		//if (leftEye.GetComponent<Image> ().color.a > 0.25f || rightEye.GetComponent<Image> ().color.a > 0.25f) { // transparent effect
		if (leftGradient.color.a > 0.25f || rightGradient.color.a > 0.25f) { // transparent effect
			foreach (GameObject e in enemies) {
				//if(e!=null)e.GetComponent<SpriteRenderer> ().color = new Color (e.GetComponent<SpriteRenderer> ().color.r, e.GetComponent<SpriteRenderer> ().color.g, e.GetComponent<SpriteRenderer> ().color.b, 0.3f);			
				if(e!=null)e.GetComponent<SpriteRenderer> ().color = transp;
			}
		} else {
			foreach (GameObject e in enemies) {
				//if(e!=null)e.GetComponent<SpriteRenderer> ().color = new Color (e.GetComponent<SpriteRenderer> ().color.r, e.GetComponent<SpriteRenderer> ().color.g, e.GetComponent<SpriteRenderer> ().color.b, 1f);			
				if(e!=null)e.GetComponent<SpriteRenderer> ().color = Color.white;
			}
		}
		//  animation.Stop (coverAnim.name);
		//  if (alpha >= 1)
		//	alpha = 0;
	}

}
