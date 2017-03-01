using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {
	public Transform[] point;
	public float speed=50.0f;
	public float reachDist=20;
	public int currentPoint;
	public static int stopDistance= 150;
	public bool loop=true; 
	private GameObject player;
	public bool pause=false;
	public float dist;
	enemy enemyscript;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		enemyscript = this.GetComponent ("enemy")as enemy;
		enemyscript.satisfied = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!pause || enemyscript.satisfied) {
			move();
		}
		if (Vector3.Distance (player.transform.position, this.transform.position) < stopDistance) {
			if (!pause) {
				pause = true;
				print ("STOP!! " + Time.fixedTime);
			}
		} else {
			pause = false;
		}
	}


	void OnDrawGizmos(){
		foreach (Transform p in point) {
			Gizmos.DrawSphere (p.position,reachDist);
		}
	}
	public bool isPaused(){
		return pause;
	}
	public void Pause(){
		pause = true;
	}
	public void Resume(){
		pause = false;
	}
	public void Pause(bool s){
		pause = s;
	}
	public void move(){
		
		dist = Vector3.Distance (point [currentPoint].position, this.transform.position);
		this.transform.position = Vector3.MoveTowards (transform.position, point [currentPoint].position, Time.deltaTime * speed);
	
		if ( dist <= reachDist) {
			currentPoint++;
			if (loop && currentPoint >= point.Length) {
				reset ();
				print("reset loop/");
			}
		}
	
	}
	public void reset(){
		currentPoint = 0;
		enemyscript.satisfied = false;
		pause = false;
		//float dist = Vector3.Distance (point [currentPoint].position, this.transform.position);
		this.transform.position =point[0].position;
		enemyscript.randomize();
	}
}
