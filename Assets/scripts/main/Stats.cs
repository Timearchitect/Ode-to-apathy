using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Stats  {
	//public static float wordSpeed;
	public static float wordCount;
	public static float maxApathy=100;
	public static float apathy=maxApathy;
	public static float averageTypeSpeed;
	public static int maxWordCount=1100;
	public static float typeSpeed = 2;
	public static float distractedTime;
	public static float penSpeed=0.85f;
	public static float panStereo=0.0f;
	public static float apathyLost;
	public static float distractionPenalty=-0.9f;
	public static float apathyPenalty=-0.2f;
	public static float apathyRegen=0.01f;
	public static int ignoredObstacle;
	public static float totalTime=90f;
	public static float timeleft=totalTime;
	public static int workMode;
	public static long modeTimer;
	public static int workDuration = 10;


	public static void reduceHealth(){
		if(apathy>-Stats.apathyPenalty)apathy += Stats.apathyPenalty;
	}
	public static void regenApathy(){
		if (apathy < maxApathy) 
			apathy += apathyRegen;
	}

	public static void shiftMode(){
		if (workMode == 0)
			workMode = 1;
		else
			workMode = 0;
	}

	/*// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}*/
}
