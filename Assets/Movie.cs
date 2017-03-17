using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class Movie : MonoBehaviour {
	public MovieTexture movie;
	private AudioSource audio;
	int quality;

	void Start () {
		quality = QualitySettings.vSyncCount;
		QualitySettings.vSyncCount = 0;
		GetComponent<RawImage> ().texture = movie as MovieTexture;
		audio = GetComponent<AudioSource> ();
		audio.clip = movie.audioClip;
		movie.Play ();
		audio.Play ();
	}

	// Update is called once per frame
	void Update () {
		if (!movie.isPlaying) {
			QualitySettings.vSyncCount = quality;
			this.gameObject.SetActive (false);
		}
		/*if (Input.GetKeyDown (KeyCode.Space) && movie.isPlaying)
			movie.Pause ();
		else if (Input.GetKeyDown (KeyCode.Space) && !movie.isPlaying)
			movie.Play ();*/
	}

}
