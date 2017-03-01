using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class result : MonoBehaviour {
	GameObject review ;
	//GUIText reviewText;
	// Use this for initialization
	void Start () {
		//reviewText = GameObject.FindWithTag("reviewText").GetComponent<GUIText>() as GUIText;
		review = GameObject.Find("ReviewPanel");
		//reviewText = GUIText.FindGameObjectWithTag("reviewText");
		//reviewText = GetComponent <Text>();
		//set2 = Instantiate(new GameObject(), guiLocation(2), Quaternion.identity) as GameObject;
		//Instantiate(new GameObject(), guiLocation(1), Quaternion.identity) as Text;
		//reviewText =new GUIText();
		//reviewText.transform.position=review.guiLocation(1);
		//review.AddComponent<GUIText>;
		//review.guiText.guiText= "HELLO WORLD!!";
		//reviewText.text="sdsdfsdfdsfsdf";
		//print (review.name+"!!!!!!!!!!!!!!!!!!!!!");
		if (review != null) {
			//	print (review.guiText);
		    //	if(review.GetComponent<Text>() != null) print ("NOT NULL text");
	      	//	else print (" NULL text");
			foreach (Component e in review.GetComponents<Component>()) {
				print (e.name +"  "+ e.ToString());
			}
			//reviewText.text="sdfashdfjsdhfakjdfhjskdfhasjkdfas";
			//review.GetComponent <Text> ().text = "  Dummy Text  ";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
