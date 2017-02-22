using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coverEyes : MonoBehaviour {
	GameObject leftEye,rightEye;
	public static float alphaL;
	public static float alphaR=1.0f;
	// Use this for initialization
	void Start () {
		leftEye = GameObject.Find ("leftEye");
		rightEye = GameObject.Find ("rightEye");
	}

	// Update is called once per frame
	void Update () {
		//alpha += 0.01f;
		//   leftEye.GetComponent<Image> ().color = new Color(0,0,0,alphaL);
		//rightEye.GetComponent<Image> ().color = new Color(0,0,0,alphaR);

		//if (alpha >= 1)
		//	alpha = 0;
	}

}
