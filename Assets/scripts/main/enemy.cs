using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
	GameObject self,player;
	//int range;
	float wobbleMagnitude= 0.5f,walkWobble;
	int condition;
	private Vector3 t; 
	// Use this for initialization
	void Start () {
		//enemy = GameObject.FindGameObjectWithTag ("enemy");
		condition=Random.Range(0,2);
		//speed=0.01f;
		//range=100;
		self= this.gameObject;
		t= self.transform.position;
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void LateUpdate () {

		/*
		if (Vector3.Distance (self.transform.position, player.transform.position) > range) {
			self.transform.position = Vector3.Lerp (self.transform.position, player.transform.position, speed);
		} else {
			print ("to complete this event you need :" +condition);
		}
		*/
		print (self.name +" : "+t);
		walkWobble += 0.25f;
		self.transform.position= new Vector3(self.transform.position.x,self.transform.position.y+Mathf.Sin(walkWobble) * wobbleMagnitude ,self.transform.position.z);
	
	}
}
