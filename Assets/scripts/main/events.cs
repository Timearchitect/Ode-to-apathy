using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class events : MonoBehaviour {
	public GameObject [] enemies;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void LateUpdate () {
		enemies=GameObject.FindGameObjectsWithTag ("enemy");
		if (enemies!=null && enemies.Length != 0) {
			print (enemies.Length + " enemies on screen");
		}
		if (Input.GetKeyDown ("space")) {
			GameObject remotePlayer =(GameObject)Instantiate(GameObject.FindGameObjectWithTag("enemy"));
			//(GameObject)Instantiate(GameObject.FindGameObjectWithTag("enemy"), new Vector3(0,0,0), Quaternion.identity);
			//remotePlayer.transform.position = new Vector3 (0,0,0);
			//Instantiate(GameObject.FindGameObjectWithTag("enemy"));
			remotePlayer.transform.position = new Vector3(
				remotePlayer.transform.position.x + 20,
				remotePlayer.transform.position.y,
				remotePlayer.transform.position.z
			);
		}
	}
}
