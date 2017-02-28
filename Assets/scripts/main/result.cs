using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class result : MonoBehaviour {
	GameObject review ;

	// Use this for initialization
	void Start () {
		review = GameObject.Find("ReviewPanel");
		print (review.name+"!!!!!!!!!!!!!!!!!!!!!");

		if (review != null) {
			//print (review.guiText);
			if (review.GetComponent<UnityEngine.UI.Text> ().text != null) print ("NOT NULL text");
			else print (" NULL text");
			foreach (Component e in review.GetComponents<Component>()) {
				print (e.name +"  "+ e.ToString());
			}

			//review.GetComponent <Text> ().text = "  Dummy Text  ";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
