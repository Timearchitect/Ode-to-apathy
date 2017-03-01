using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour {
	private GameObject self,player;
	private GameObject leftEye,rightEye;
	//int range;
	private float wobbleMagnitude= 0.5f,walkWobble;
	public SpriteRenderer spriteRenderer;
	private GameObject bgm;
	private AudioSource cafe;
	private int condition,spriteIndex;
	public bool satisfied;
	private Vector3 t;
	// Use this for initialization
	void Start () {
		//enemy = GameObject.FindGameObjectWithTag ("enemy");
		condition=Random.Range(0,4);    // 0 = RightEye, 1 = LeftEye, 2 = RightEars , 3 = LeftEars 
		spriteIndex=Random.Range(0,4);   
		leftEye = GameObject.Find ("leftEye");
		rightEye = GameObject.Find ("rightEye");
		//Random.Range(0,3);

		cafe = GameObject.FindGameObjectWithTag ("cafe").GetComponent<AudioSource> ();
		//speed=0.01f;
		//range=100;
		self= this.gameObject;

		spriteRenderer = self.GetComponent("SpriteRenderer") as SpriteRenderer;
		if (spriteRenderer == null) {
			print ("null");
		} else {
			switch (condition) {
			case 0:
				spriteRenderer.sprite= Resources.Load<Sprite> ("barn1") as Sprite;
				break;
			case 1:
				spriteRenderer.sprite= Resources.Load<Sprite> ("gubbe1") as Sprite;
				break;
			case 2:
				spriteRenderer.sprite= Resources.Load<Sprite> ("gubbe3") as Sprite;
				break;
			default :
				spriteRenderer.sprite= Resources.Load<Sprite> ("barn1") as Sprite;
				break;
			}
		}

		//sprite.sprite = Resources.Load<Sprite> ("textures/barn1") as Sprite


		//print (Resources.LoadAll <Sprite> ());
		t= self.transform.position;
		player = GameObject.FindGameObjectWithTag ("Player");
		bgm = GameObject.FindGameObjectWithTag ("bgm");

		switch (condition) {
			case 0:
				self.GetComponent<SpriteRenderer> ().color = new Color (1f, 0.5f, 1f);
				print (self.name + " with " + condition +" color: "+ self.GetComponent<SpriteRenderer> ().color.ToString());
				break;
			case 1:
				self.GetComponent<SpriteRenderer> ().color = new Color (0.5f, 1f, 1f);
				print (self.name + " with " + condition +" color: "+ self.GetComponent<SpriteRenderer> ().color.ToString());
				break;
			case 2:
				self.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f);
				print (self.name + " with " + condition +" color: "+ self.GetComponent<SpriteRenderer> ().color.ToString());
				break;
			case 3:
				self.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f);
				print (self.name + " with " + condition +" color: "+ self.GetComponent<SpriteRenderer> ().color.ToString());
				break;
		}
		//print (this.name + " with " + condition +" color: "+ self.GetComponent<SpriteRenderer> ().color.ToString());
	}


	void LateUpdate () {
		/*
		if (Vector3.Distance (self.transform.position, player.transform.position) > range) {
			self.transform.position = Vector3.Lerp (self.transform.position, player.transform.position, speed);
		} else {
			print ("to complete this event you need :" +condition);
		}
		*/
		
		if (Input.GetMouseButtonDown(1)) {
			satisfied = !satisfied;
			print (this.name +" with "+condition+"  :  "+ satisfied);
		}

		//if (follow.pause) {
		print (GameObject.FindGameObjectWithTag ("cafe").GetComponent<AudioSource> ().volume);

		switch(condition){
			case 0:
			if (condition==0 && rightEye.GetComponent<Image> ().color.a > 0.25f) {
					satisfied = true;
					print (this.name + " with " + condition +" color: "+ self.GetComponent<SpriteRenderer> ().color.ToString());
					Stats.ignoredObstacle++;
				}
			break;
			case 1:
			if (condition==1 && leftEye.GetComponent<Image> ().color.a > 0.25f) {
					satisfied = true;
					print (this.name + " with " + condition +" color: "+ self.GetComponent<SpriteRenderer> ().color.ToString());
					Stats.ignoredObstacle++;
				}
			break;
			case 2:
			if (condition==2 && cafe.volume < 0.01f) {
					satisfied = true;
					print (this.name + " with " + condition +" color: "+ self.GetComponent<SpriteRenderer> ().color.ToString());
					Stats.ignoredObstacle++;
				}
			break;
			case 3:
			if (condition==3 && cafe.volume < 0.01f) {
					satisfied = true;
					print (this.name + " with " + condition +" color: "+ self.GetComponent<SpriteRenderer> ().color.ToString());
					Stats.ignoredObstacle++;
				}
			break;
		}
		//}
		//print (self.name +" : "+t);
		walkWobble += 0.25f;
		self.transform.position= new Vector3(self.transform.position.x,self.transform.position.y+Mathf.Sin(walkWobble) * wobbleMagnitude ,self.transform.position.z);
	}
}