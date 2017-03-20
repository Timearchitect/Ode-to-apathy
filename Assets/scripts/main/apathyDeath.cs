using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apathyDeath : MonoBehaviour {
	public int level;
	public AudioSource apathyAudio;

	// Use this for initialization
	void Start () {
		level = Stats.currentLevel;
		apathyAudio = GetComponent<AudioSource> ();
		AudioClip apathyClip = Resources.Load ("apathy_ending_"+level,typeof(AudioClip)) as AudioClip;
		apathyAudio.clip = apathyClip;
		apathyAudio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
