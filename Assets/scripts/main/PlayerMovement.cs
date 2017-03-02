using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour {
	GameObject go;
	GameObject player;
	private SpriteRenderer head;
	//Component playerHead;
	Vector3 offset = new Vector3(0,90,-220); // camera offset
	Vector3 finishpos;
	float lerpSpeed=0.06f;
	private float hVal,vVal;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		//playerHead = player.GetComponent("Body").GetComponent("Head")as Component;

		go = this.gameObject;
		head = GameObject.Find("Head").GetComponent<SpriteRenderer>();
		/*foreach (SpriteRenderer s in sprites) {
			print ( s);
		}*/
	}
	// Update is called once per frame
	void LateUpdate () {
		hVal = Input.GetAxis ("Horizontal"); 
		vVal = Input.GetAxis ("Vertical"); 

		if (hVal < 0) {
			//print ("left:" + hVal);
			player.transform.position -= new Vector3(1,0,0);
			head.sprite= Resources.Load<Sprite> ("head_left") as Sprite;
		}
		if (vVal < 0) {
			//print("down:"+vVal);
			player.transform.position -= new Vector3(0,1,0);
			head.sprite= Resources.Load<Sprite> ("head") as Sprite;
		}
		if (hVal >0) {
			//print ("right:" + hVal);
			player.transform.position += new Vector3(1,0,0);
			head.sprite= Resources.Load<Sprite> ("head_right") as Sprite;
		}
		if (vVal > 0) {
			//print("up:"+vVal);
			player.transform.position += new Vector3(0,1,0);
			head.sprite= Resources.Load<Sprite> ("head") as Sprite;
		}
		finishpos = player.transform.position+ offset;
		go.transform.position = Vector3.Lerp (go.transform.position, finishpos, lerpSpeed);

	}


}
