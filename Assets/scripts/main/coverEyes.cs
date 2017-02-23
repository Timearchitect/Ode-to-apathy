using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coverEyes : MonoBehaviour {
	GameObject leftEye,rightEye;
	//public static float alphaL;
	//public static float alphaR=1.0f;
	private Animation animation;
	private AnimationClip coverAnim;
	private GameObject[] enemies;
	// Use this for initialization
	void Start () {
		animation = GameObject.FindGameObjectWithTag ("Player").GetComponent<Animation>();
		//coverAnim= animation.GetClip ("Cover_Ears");
		leftEye = GameObject.Find ("leftEye");
		rightEye = GameObject.Find ("rightEye");
		enemies = GameObject.FindGameObjectsWithTag ("enemy");
	}

	// Update is called once per frame
	void Update () {

		//alpha += 0.01f;
		//   leftEye.GetComponent<Image> ().color = new Color(0,0,0,alphaL);
		//rightEye.GetComponent<Image> ().color = new Color(0,0,0,alphaR);
		print(leftEye.GetComponent<Image> ().color.a + "   blackness");
		print(rightEye.GetComponent<Image> ().color.a + "   blackness");
		if (leftEye.GetComponent<Image> ().color.a > 0.25f || rightEye.GetComponent<Image> ().color.a > 0.25f) {
		//	animation.Play (coverAnim.name);
			foreach (GameObject e in enemies) {
				e.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0.3f);
			}
		} else {
			foreach (GameObject e in enemies) {
				e.GetComponent<SpriteRenderer> ().color = new Color(1f,1f,1f,1f);
			}
		}
			//animation.Stop (coverAnim.name);


		//if (alpha >= 1)
		//	alpha = 0;
	}

}
