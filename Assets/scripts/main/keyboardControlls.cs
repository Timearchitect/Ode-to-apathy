using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class keyboardControlls : MonoBehaviour {
	public GameObject debugContent ;
	public static int wordCount=0;
	public float timer=0,duration;
	public AudioSource a;
	private UnityEngine.UI.Text t;
	// Use this for initialization
	void Start () {
		debugContent = GameObject.FindGameObjectWithTag("debug");
		t = debugContent.GetComponent<UnityEngine.UI.Text> ();
		a =GameObject.FindGameObjectWithTag ("bgm").GetComponent<AudioSource> ();
		duration = 0.5f;

		//audio.volume = 1;
		//audio.Play ();
	}

	// Update is called once per frame
	void Update () {
		float hVal = Input.GetAxis ("Horizontal"); 
		float vVal = Input.GetAxis ("Vertical"); 

		if (hVal < 0) {
			print ("left:" + hVal);

		}
		if (vVal < 0) {
			print("down:"+vVal);

		}

		if (hVal >0) {
			print ("right:" + hVal);

		}
		if (vVal > 0) {
			print("up:"+vVal);

		}
		detectPressedKeyOrButton ();
		if (timer + duration < Time.time) {
			if (a.isPlaying) {
				a.Pause ();
			}
		}
	}


	public void detectPressedKeyOrButton()
	{
		foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
		{
			if (Input.GetKeyDown (kcode)) {
				//Debug.Log ("KeyCode down: " + kcode+ " count: "+wordCount +"  time:"+timer );
				wordCount++;
			/*	Debug.Log (debugContent.name +"  "+debugContent.GetType() );
				RectTransform r= debugContent.GetComponent<RectTransform>();
				Debug.Log (r.name);*/
				//UnityEngine.UI.Text t = debugContent.GetComponent<UnityEngine.UI.Text> ();
				t.text=t.text.ToString()+kcode;
				t.GraphicUpdateComplete();
				Canvas.ForceUpdateCanvases();

				/*foreach(var component in debugContent.GetComponents<Component>())
				{
					Debug.Log (component.GetType() +" child");
				}*/

				//AudioSource a =(AudioSource)GameObject.FindGameObjectWithTag ("bgm");
				//((GUIContent)debugContent).text="hello world";
				//+((ScrollRect)debugContent).GetType()
				timer = Time.time;
				if(!a.isPlaying) a.Play();

				//print(a.loop);

				/*if (kcode ==  KeyCode.K) {
					print ("toggle lowpass");
					//a.GetComponent<AudioSource> ().bypassEffects
					a.GetComponent<AudioSource>().volume= (a.GetComponent<AudioSource>().bypassEffects)?0.1f:1;
					a.GetComponent<AudioSource>().bypassEffects = !a.GetComponent<AudioSource>().bypassEffects;
					}
					//a.GetComponent<AudioSource> ().GetComponents <AudioLowPassFilter>().
				}*/
			}
		}
	}
}