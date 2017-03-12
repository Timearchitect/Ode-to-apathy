using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coverEyes : MonoBehaviour {
	GameObject leftEye,rightEye;
	//public static float alphaL;
	//public static float alphaR=1.0f;
	//private Animation animation;
	private AnimationClip coverAnim;
	private GameObject[] enemies;
	// Use this for initialization
	void Start () {
		try{
			leftEye = GameObject.Find ("leftEye");
			rightEye = GameObject.Find ("rightEye");
			enemies = GameObject.FindGameObjectsWithTag ("enemy");
		}catch{
			UnityEngine.Debug.LogError ("Error in "+this.name +" please check in script: ");
			UnityEditor.EditorApplication.isPlaying = false;
			UnityEditor.EditorApplication.isPaused = true;

		}
	}

	// Update is called once per frame
	void Update () {
		//print(leftEye.GetComponent<Image> ().color.a + "   blackness");
		//print(rightEye.GetComponent<Image> ().color.a + "   blackness");
		if (leftEye.GetComponent<Image> ().color.a > 0.25f || rightEye.GetComponent<Image> ().color.a > 0.25f) { // transparent effect
			foreach (GameObject e in enemies) {
				e.GetComponent<SpriteRenderer> ().color = new Color (e.GetComponent<SpriteRenderer> ().color.r, e.GetComponent<SpriteRenderer> ().color.g, e.GetComponent<SpriteRenderer> ().color.b, 0.3f);			
			}
		} else {
			foreach (GameObject e in enemies) {
				e.GetComponent<SpriteRenderer> ().color = new Color (e.GetComponent<SpriteRenderer> ().color.r, e.GetComponent<SpriteRenderer> ().color.g, e.GetComponent<SpriteRenderer> ().color.b, 1f);			
			}
		}
		//  animation.Stop (coverAnim.name);
		//  if (alpha >= 1)
		//	alpha = 0;
	}

}
