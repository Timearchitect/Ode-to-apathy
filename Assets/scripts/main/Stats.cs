using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats  {
	//public static float wordSpeed;
	public static int maxWordCount=400,maxDrawProgress=100,maxCodeProgress=100;
	public static float wordCount,drawProgess,codeProgess;
	public static float maxApathy=100;
	public static float apathy=maxApathy;
	public static float averageTypeSpeed;
	public static float typeSpeed = 2;
	public static float mouseRegisterDist= 250f;
	public static float visualCoverMax = .6f;
	public static float fadeRate=0.08f;
	public static float distractedTime;
	public static float penSpeed=0.7f;
	public static float panStereo=0.0f;
	public static float apathyLost;
	public static float distractionPenalty=-0.9f;
	public static float apathyPenalty=-0.2f;
	public static float apathyRegen=0.03f;
	public static int ignoredObstacle;
	public static float totalTime=90f;
	public static int currentLevel=1;
	public static float timeleft=totalTime;
	public static int workMode,pWorkMode;
	public static long modeTimer;
	public static int workDuration = 10;

	public static void difficultyBasedOnLevel(){
		//UnityEngine.Debug.Log ("difficulty based on level: "+Stats.currentLevel);
		switch(currentLevel){
			case 1:
				maxWordCount = 800;
				totalTime =110;
				apathyRegen=0.05f;
				break;
			case 2:
				maxWordCount = 900;
				totalTime =100;
				apathyRegen=0.045f;
				break;
			case 3:
				maxWordCount = 1000;
				totalTime = 90;
				apathyRegen = 0.04f;
				break;
			default:
				maxWordCount = 1000;
				totalTime = 90;
			break;
			}
	}

	public static void reduceHealth(){
		if(apathy>-Stats.apathyPenalty)apathy += Stats.apathyPenalty;
	}
	public static void regenApathy(){
		if (apathy < maxApathy) apathy += apathyRegen;
	}
	public static void shiftMode(){
		drawProgess = 0;
		codeProgess = 0;
		circleTimer.pop ();
		pWorkMode = workMode;
		if (workMode == 0) {
			workMode = 1;
			Game.machL.clip = Resources.Load ("pecil",typeof(AudioClip)) as AudioClip;
			Game.machR.clip = Resources.Load ("pecil",typeof(AudioClip)) as AudioClip;
			UnityEngine.GameObject.FindObjectOfType<circleTimer> ().startDrawing();
		}
		else{
			workMode = 0;
			Game.machL.clip = Resources.Load ("tangentbord",typeof(AudioClip)) as AudioClip;
			Game.machR.clip = Resources.Load ("tangentbord",typeof(AudioClip)) as AudioClip;
			UnityEngine.GameObject.FindObjectOfType<circleTimer> ().startCoding();
		}
	}
	public static void randomMode(){
		if (Random.Range (0, 300) == 1) {
			Stats.shiftMode ();
			UnityEngine.Debug.Log ("SHIFT MODE!!!");
		}
	}
	/*// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
	}*/
}
