using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class audioApathy : MonoBehaviour {

	public int level;
	public GameObject go;
	public AudioSource apathyAudio;
	public AudioClip apathyClip;

	// Use this for initialization
	void Start () {
		level = Stats.currentLevel;
	//	go = GameObject.FindGameObjectWithTag ("endCard");
		apathyAudio = GetComponent<AudioSource> ();

		apathyClip = Resources.Load ("apathy_ending_"+level,typeof(AudioClip)) as AudioClip;


		apathyAudio.clip = apathyClip;
		apathyAudio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
