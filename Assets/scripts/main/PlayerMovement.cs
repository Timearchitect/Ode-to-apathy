using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	GameObject go;
	GameObject player;
	// Use this for initialization
	void Start () {
		go = GameObject.FindGameObjectWithTag("Player");
	}
	// Update is called once per frame
	void Update () {
		float hVal = Input.GetAxis ("Horizontal"); 
		float vVal = Input.GetAxis ("Vertical"); 
		if (hVal < 0) {
			//print ("left:" + hVal);
			go.transform.position -= new Vector3(1,0,0);

			//go.rigidbody.transform.position;
		}
		if (vVal < 0) {
			//print("down:"+vVal);
			go.transform.position -= new Vector3(0,1,0);

			//go.rigidbody.transform.position.
		}
		if (hVal >0) {
			//print ("right:" + hVal);
			go.transform.position += new Vector3(1,0,0);

		}
		if (vVal > 0) {
			//print("up:"+vVal);
			go.transform.position += new Vector3(0,1,0);
		
		}
	}
}
