using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	GameObject go;
	GameObject player;
	Vector3 offset = new Vector3(0,70,-80);
	Vector3 finishpos;
	float lerpSpeed=0.06f;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		go = this.gameObject;
	}
	// Update is called once per frame
	void LateUpdate () {
		float hVal = Input.GetAxis ("Horizontal"); 
		float vVal = Input.GetAxis ("Vertical"); 
		if (hVal < 0) {
			//print ("left:" + hVal);
			player.transform.position -= new Vector3(1,0,0);
			//go.rigidbody.transform.position;
		}
		if (vVal < 0) {
			//print("down:"+vVal);
			player.transform.position -= new Vector3(0,1,0);
			//go.rigidbody.transform.position.
		}
		if (hVal >0) {
			//print ("right:" + hVal);
			player.transform.position += new Vector3(1,0,0);
		}
		if (vVal > 0) {
			//print("up:"+vVal);
			player.transform.position += new Vector3(0,1,0);
		}
		finishpos = player.transform.position+ offset;
		go.transform.position = Vector3.Lerp (go.transform.position, finishpos, lerpSpeed);

	}
}
