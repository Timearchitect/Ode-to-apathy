using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {
	[SerializeField]
	public GameObject path;
	public Transform[] point;
	public float speed=50.0f;
	public float reachDist=20;
	public int currentPoint;
	public int startIndex=0;
	public int startTime;
	public static int stopDistance= 150;
	public static int stopDistanceCafe= 30;
	public bool loop=true;

	//stopPoints
	private GameObject player;
	private GameObject stopPoint_cafe;
	public bool pause;
	private bool started;
	private float dist;
	private enemy enemyscript;
	private bool dead;

	void Start () {
		try{
			if(startTime>0)started=false;
			player = GameObject.FindGameObjectWithTag ("Player");
				print(player.name);
			//stopPoint_cafe = GameObject.FindGameObjectWithTag ("stopPointCafe");
				//print(stopPoint_cafe.name);
			enemyscript = this.GetComponent ("enemy")as enemy;
				print(enemyscript.name);
			enemyscript.satisfied = false;
		}catch(Exception ex ){
			UnityEngine.Debug.LogError ("Error in "+this.name +" please check row "+ex.ToString ().Split (':') [3]+" in script: ");				
			UnityEditor.EditorApplication.isPlaying = false;
			UnityEditor.EditorApplication.isPaused = true;
		}
	}

	// Update is called once per frame
	void Update () {
		if (!started && startTime <= Time.timeSinceLevelLoad) {
			print ( " scripted enemy GO! now at: " + startTime);
			started = true;
		}
		if (started) {
			if (dead)
				Destroy (this.gameObject);
			else {
				if (!pause || enemyscript.satisfied)
					move ();
				stopPoint_player (); //Check stoppoints
				if (stopPoint_cafe != null)
					stopPoint_cafeCounter ();
			}
		}
	}

	void stopPoint_player(){
		if (Vector3.Distance (player.transform.position, this.transform.position) < stopDistance) {
			if(!enemyscript.satisfied)Stats.reduceHealth ();
			if (!pause) {
				pause = true;
				print ("STOP!! " + Time.fixedTime);
				//enemyscript.spawnDialogBox ();
				enemyscript.spawnDistraction ();
			}
		} else {
			pause = false;
		}

	}

	void stopPoint_cafeCounter(){
		if (Vector3.Distance (stopPoint_cafe.transform.position, this.transform.position) < stopDistanceCafe) {
			if(!enemyscript.satisfied)Stats.reduceHealth ();
			if (!pause) {
				pause = true;
				print ("STOP!! " + Time.fixedTime);
			//	enemyscript.spawnDialogBox ();
			   enemyscript.spawnDistraction ();

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
			if (currentPoint >= point.Length) {
				if(loop)
				reset ();
				else 
				dead = true;
			}
		}
	
	}
	public void reset(){

			enemyscript.randomize ();
			enemyscript.satisfied = false;
			pause = false;
			//float dist = Vector3.Distance (point [currentPoint].position, this.transform.position);
			currentPoint = startIndex;
			this.transform.position = point [startIndex].position;
		
	}
	public void setPath(GameObject temp){
		//print ("setPath");
		path = temp;
		point = path.GetComponentsInChildren <Transform>();

		/*Transform[] comps = path.GetComponentsInChildren<Transform>();
		foreach (Transform comp in comps)
		{
			if ( comp.gameObject.GetInstanceID() != path.GetInstanceID() )
			{
				point.
			}
		}*/

		currentPoint = startIndex;
		//print (point[startIndex].name+" starting point");
		this.transform.position =point[startIndex].position;

	}

}
