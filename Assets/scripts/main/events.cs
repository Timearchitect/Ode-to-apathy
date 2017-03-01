using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class events : MonoBehaviour {
	public GameObject [] enemies;
	private GameObject remotePlayer;
	public follow followScript;
	// Use this for initialization
	void Start () {
		enemies=GameObject.FindGameObjectsWithTag ("enemy");
	}
	
	// Update is called once per frame
	void LateUpdate () {

		if (Input.GetKeyDown ("space")) {
			remotePlayer =(GameObject)Instantiate(GameObject.FindGameObjectWithTag("enemy"));
	
			followScript = remotePlayer.GetComponent<follow>() ;
			followScript.Pause ();
			//(GameObject)Instantiate(GameObject.FindGameObjectWithTag("enemy"), new Vector3(0,0,0), Quaternion.identity);
			//remotePlayer.transform.position = new Vector3 (0,0,0);
			//Instantiate(GameObject.FindGameObjectWithTag("enemy"));
			remotePlayer.transform.position = new Vector3(
				remotePlayer.transform.position.x + 20,
				remotePlayer.transform.position.y,
				remotePlayer.transform.position.z
			);
			if (enemies!=null && enemies.Length != 0) {
				print (enemies.Length + " enemies on screen");
			}
		}
	}
}
