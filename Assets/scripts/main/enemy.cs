using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
	GameObject self,player;
	int range;
	float speed;
	int condition;
	// Use this for initialization
	void Start () {
		//enemy = GameObject.FindGameObjectWithTag ("enemy");
		condition=Random.Range(0,2);
		speed=0.01f;
		range=100;
		self= this.gameObject;
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void LateUpdate () {
		//print(enemy.name +"  " + player.name);

		if (Vector3.Distance (self.transform.position, player.transform.position) > range) {
			self.transform.position = Vector3.Lerp (self.transform.position, player.transform.position, speed);
		} else {
			print ("to complete this event you need :" +condition);
		}

		//			Destroy (this.gameObject);

		//-= new Vector3(1,0,0);

		//if(   timer-Time.deltaTime)
	
	}
}
