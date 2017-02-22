using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {
	public Transform[] point;
	public float speed=50.0f;
	public float reachDist=20;
	public int currentPoint;
	public bool loop=true; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance (point [currentPoint].position, this.transform.position);

		this.transform.position = Vector3.MoveTowards(transform.position,point[currentPoint].position,Time.deltaTime*speed);

		if (dist <= reachDist) {
			currentPoint++;
			if (currentPoint >= point.Length) {
				currentPoint = 0;
			}
		}
	

	}


	void OnDrawGizmos(){
		foreach (Transform p in point) {
			Gizmos.DrawSphere (p.position,reachDist);
		}
	}
}
