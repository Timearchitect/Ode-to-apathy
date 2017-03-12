using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {
	[SerializeField]
	public GameObject path;
	public Transform[] point;
	public float speed=50.0f;
	public float reachDist=20;
	public int currentPoint;
	public int startIndex=1;
	public int startTime;
	public static int stopDistance= 150;
	public static int stopDistanceCafe= 30;
	public bool loop=true;

	//stopPoints
	private GameObject player;
	private GameObject stopPoint_cafe;
	public bool pause=false;
	public float dist;
	enemy enemyscript;
	// Use this for initialization
	void Start () {
		try{
			player = GameObject.FindGameObjectWithTag ("Player");
			stopPoint_cafe = GameObject.FindGameObjectWithTag ("stopPointCafe");
			enemyscript = this.GetComponent ("enemy")as enemy;
			enemyscript.satisfied = false;
		}catch{
			UnityEngine.Debug.LogError ("Error in "+this.name +" please check in script: ");
			UnityEditor.EditorApplication.isPlaying = false;
			UnityEditor.EditorApplication.isPaused = true;

		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!pause || enemyscript.satisfied) {
			move();
		}
	//Check stoppoints
		stopPoint_player ();

		if (stopPoint_cafe != null) {
			stopPoint_cafeCounter ();
		}
	}

	void stopPoint_player(){
		if (Vector3.Distance (player.transform.position, this.transform.position) < stopDistance) {
			if(!enemyscript.satisfied)Stats.reduceHealth ();
			if (!pause) {
				pause = true;
				print ("STOP!! " + Time.fixedTime);
				enemyscript.spawnDialogBox ();
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
				enemyscript.spawnDialogBox ();

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
				//print("reset loop/");
			}
		}
	
	}
	public void reset(){
		enemyscript.randomize();
		enemyscript.satisfied = false;
		pause = false;
		//float dist = Vector3.Distance (point [currentPoint].position, this.transform.position);
		currentPoint = startIndex;
		this.transform.position =point[startIndex].position;

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
