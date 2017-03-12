using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour {
	GameObject go;
	GameObject player;
	private SpriteRenderer head;
	private SpriteRenderer body;
	//Component playerHead;
	Vector3 offset = new Vector3(0,90,-220); // camera offset
	Vector3 finishpos;
	float angle;
	float lerpSpeed=0.06f;
	private float hVal,vVal;

	// Use this for initialization
	void Start () {
		try{
			player = GameObject.FindGameObjectWithTag("Player");
				print(player.name);
			go = this.gameObject;
				print(go.name);
			head = GameObject.Find("Head").GetComponent<SpriteRenderer>();
				print(head.name);
			body = GameObject.Find("Body").GetComponent<SpriteRenderer>();
				print(body.name);
		}catch(Exception ex ){
			UnityEngine.Debug.LogError ("Error in "+this.name +" please check row "+ex.ToString ().Split (':') [3]+" in script: ");			
			UnityEditor.EditorApplication.isPlaying = false;
			UnityEditor.EditorApplication.isPaused = true;

		}
	}
	// Update is called once per frame
	void LateUpdate () {
		if (Game.cheatMode) {
			hVal = Input.GetAxis ("Horizontal"); 
			vVal = Input.GetAxis ("Vertical"); 
			if (hVal < 0) {
				//print ("left:" + hVal);
				player.transform.position -= new Vector3 (1, 0, 0);
				head.sprite = Resources.Load<Sprite> ("head_left") as Sprite;
				angle += 1f;
			}
			if (vVal < 0) {
				//print("down:"+vVal);
				player.transform.position -= new Vector3 (0, 1, 0);
				head.sprite = Resources.Load<Sprite> ("head") as Sprite;
			}
			if (hVal > 0) {
				//print ("right:" + hVal);
				player.transform.position += new Vector3 (1, 0, 0);
				head.sprite = Resources.Load<Sprite> ("head_right") as Sprite;
				angle -= 1f;

			}
			if (vVal > 0) {
				//print("up:"+vVal);
				player.transform.position += new Vector3 (0, 1, 0);
				head.sprite = Resources.Load<Sprite> ("head") as Sprite;
			}

		}
		finishpos = player.transform.position + offset;
		go.transform.position = Vector3.Lerp (go.transform.position, finishpos, lerpSpeed);
		rotateBack ();

	}
	void rotateBack(){
	
		body.transform.rotation =Quaternion.RotateTowards(body.transform.rotation, player.transform.rotation, 0.3f);

	}

}
