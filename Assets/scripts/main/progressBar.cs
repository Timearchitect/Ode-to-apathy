using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
public class progressBar : MonoBehaviour {
	public GameObject go,apathyBar,camera;
	private GameObject bar,aBar;
	public ColorCorrectionCurves desaturation;
	float val = 0.0f;
	static float percentBlend,sizeLerp=3,asizeLerp=2;
	private Slider progress,apathy;
	private UnityEngine.UI.Image fill,bfill;
	private RectTransform rt ,art;

	void Start () {
		try{
			Stats.difficultyBasedOnLevel();
			camera= GameObject.Find("Camera");
				print(camera.name);			
			desaturation = camera.GetComponent<ColorCorrectionCurves> ();
				print(desaturation.name);
			bar = GameObject.Find("Slider") ;
			go= GameObject.FindGameObjectWithTag("progressBar");
				print(go.name);
			progress = go.GetComponent<Slider>();
				print(progress.name);
			apathyBar= GameObject.FindGameObjectWithTag("apathyBar");
				print(apathyBar.name);
			apathy = apathyBar.GetComponent<Slider>();
				print(apathy.name);
				print(apathy.value);
		//	print(bar.GetComponentInChildren<GameObject>("Fill Area")+" !!!dsfysadkufsadfjsadfashdfjadfkshfas");
			fill = bar.GetComponentsInChildren<UnityEngine.UI.Image>()[1];
			bfill = bar.GetComponentsInChildren<UnityEngine.UI.Image>()[0];
			//fill.color=  Color.blue;
			//fill.color=  Color.Lerp(Color.red, Color.green, 0.5f);
	
			print(bar+"!!!!!!!! mybar");
			rt = bar.GetComponent<RectTransform>();
			rt.sizeDelta=new Vector2(Screen.width*1f,60);
			rt.transform.position= new Vector3(Screen.width*0.5f,Screen.height*.98f,0);

			art = apathyBar.GetComponent<RectTransform>();
			art.sizeDelta=new Vector2(Screen.width*.2f,40);
			//art.transform.position= new Vector3(Screen.width*.8f,Screen.height*.05f,0);
			art.transform.position= new Vector3(Screen.width*.95f,Screen.height*.35f,0);
			//new Vector2(300,300),new Vector2(Screen.width,Screen.height*.1f)

		}catch(Exception ex ){
			UnityEngine.Debug.LogError ("Error in "+this.name +" please check row "+ex.ToString ().Split (':') [3]+" in script: ");			
			UnityEditor.EditorApplication.isPlaying = false;
			UnityEditor.EditorApplication.isPaused = true;
		}
	}
	
	void Update () {
		
		fill.color=  Color.Lerp(Color.white, Color.green, percentBlend);
		percentBlend *= 0.92f;
		sizeLerp*= 0.9f;
		asizeLerp*= 0.85f;
		//if (Input.GetMouseButtonDown (0))highlightApathy ();
		rt.sizeDelta=new Vector2(Screen.width*1f*(1+sizeLerp),60*(1+sizeLerp));
		art.sizeDelta=new Vector2((float)(Screen.height*.4f+(Math.Sin(asizeLerp)*30)+60),(float)(45+(Math.Sin(asizeLerp)*30)+60));
		//art.sizeDelta=new Vector2((float)(30+(Math.Sin(asizeLerp)*40)),(float)(Screen.height*.2f+(Math.Sin(asizeLerp)*40)));

		Stats.timeleft=Stats.totalTime-Time.timeSinceLevelLoad;
		//print (Stats.totalTime +" total   :   sinceLVLSTART "+Time.timeSinceLevelLoad);
		if (Stats.timeleft <= 0) {
			//Game.end ();
			if(!coverEyes.fadeOut)coverEyes.FadeOut();
			if(Game.pause)Game.gameover ();
		}

		if (Stats.wordCount != 0) {
			val = ( (float)Stats.wordCount / Stats.maxWordCount);
			//Debug.Log (Stats.maxWordCount+ " of " + Stats.wordCount +" %"+val);
			if (val >= 1) {
				//print ("LEVEL CLEAR!!!");   
				if(coverEyes.whiteFade.color.a>=0.9f)Game.win=true;
				if(!coverEyes.fadeOut && !Game.win)coverEyes.FadeOut();
				if( Game.win)Game.end();
			}
			progress.value = val;
		}
		if (Stats.apathy != 0) {
			val = ( (float)Stats.apathy / Stats.maxApathy);
			//Debug.Log (Stats.maxApathy+ " of " + Stats.apathy +" %"+val);
			if (val <= 0.01f) {
				print ("LEVEL CLEAR!!!");   
				//Game.end();
				if(!coverEyes.fadeOut)coverEyes.FadeOut();
				if(Game.pause)Game.apathyDeath ();
			}
			apathy.value = val;
			desaturation.saturation = 0.6f-val*0.6f;
		}
		Stats.regenApathy ();
	}
	public static void highlight(){
				percentBlend = 0.3f;
	}
	public static void highlightApathy(){
		asizeLerp =(float) Math.PI;

	}

}
