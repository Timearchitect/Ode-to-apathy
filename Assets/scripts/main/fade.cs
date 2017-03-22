using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fade : MonoBehaviour {
	private Image whiteFade;
	// Use this for initialization
	void Start () {
		whiteFade = this.gameObject.GetComponent<Image> ();
		print ("end scene fade");
	}
	
	// Update is called once per frame
	void Update () {
		if (whiteFade.color.a > 0) {
			whiteFade.color = new Color (1, 1, 1, whiteFade.color.a - 0.01f);
			//print (whiteFade.color.a);
		}
	}
}
