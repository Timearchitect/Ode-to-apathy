using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {
	public Transform[] point;
	public float speed=50.0f;
	public float reachDist=20;
	public int currentPoint;
	public int stopDistance= 2500;
	public bool loop=true; 
	private GameObject player;
	private bool pause;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (!pause) {
			float dist = Vector3.Distance (point [currentPoint].position, this.transform.position);

			this.transform.position = Vector3.MoveTowards (transform.position, point [currentPoint].position, Time.deltaTime * speed);

			if ( Vector3.Distance (player.transform.position, this.transform.position) < stopDistance) {
				pause = true;
				print ("STOP!!");
			}
			if (dist <= reachDist) {
				currentPoint++;
				if (currentPoint >= point.Length) {
					currentPoint = 0;
				}
			}
	
		}
		if (Vector3.Distance (player.transform.position, this.transform.position) < stopDistance) {
			pause = true;
			print ("STOP!!");
		} else {
			pause = false;
		}
	}


	void OnDrawGizmos(){
		foreach (Transform p in point) {
			Gizmos.DrawSphere (p.position,reachDist);
		}
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
}
