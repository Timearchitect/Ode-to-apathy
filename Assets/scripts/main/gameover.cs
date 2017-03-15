using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameover : MonoBehaviour {
	public int level;
	public GameObject go;
	public Image img;
	void Start () {
		//img = GameObject.FindObjectOfType<Image> ();
		level = Stats.currentLevel;
		go = GameObject.FindGameObjectWithTag ("endCard");
		img = go.GetComponent<Image> ();
		print ( go.name+" : "+level+"!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
		img.sprite = Resources.Load ("BadReviewlvl"+level,typeof(Sprite)) as Sprite;
	}
	
	void Update () {
		
	}
}
