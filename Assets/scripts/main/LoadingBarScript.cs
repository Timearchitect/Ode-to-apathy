using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingBarScript : MonoBehaviour {

	AsyncOperation ao;
	public GameObject loadingScreenBG;
	public Slider progBar;
	public Text loadingText;

	public bool isFakeLoadingBar = false;
	public float fakeIncrement = 0f;
	public float fakeTiming = 0f;
	// Use this for initialization
	void Start () {
		loadLevel01 ();
		Game.refresh ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void loadLevel01(){
		print ("build index +1: " + (SceneManager.GetActiveScene ().buildIndex + 1));
		//loadingScreenBG.SetActive (true);
		//progBar.gameObject.SetActive (true);
		loadingText.gameObject.SetActive (true);
		loadingText.text="Loading...";
		Game.setCurrentlevelBasedOnbuildIndex (SceneManager.GetActiveScene ().buildIndex + 1);

		if (!isFakeLoadingBar) {
			StartCoroutine (LoadLevelWithRealProgress());

		} else {
			StartCoroutine(LoadLevelWithFakeProgress());

		}
	}

	IEnumerator LoadLevelWithRealProgress(){
		
		ao = SceneManager.LoadSceneAsync((SceneManager.GetActiveScene ().buildIndex + 1));
		ao.allowSceneActivation = false;

		while(!ao.isDone){
			//progBar.value = ao.progress;

			//done yo
			if(ao.progress == 0.9f){
				//progBar.value = 1f;
				loadingText.text = "Press 'F' to continue" ;
				if(Input.GetKeyDown(KeyCode.F)){
					ao.allowSceneActivation = true;
				}
			}

			yield return null;
		
		}
	}

	IEnumerator LoadLevelWithFakeProgress(){
		//while (progBar.value != 1f) {
			//progBar.value += fakeIncrement;
	//		yield return new WaitForSeconds (fakeTiming);
		
	//	}

		while (progBar.value == 1f) {
		
			loadingText.text = "Done Loading";
			if (Input.GetKeyDown (KeyCode.F)) {
				SceneManager.LoadScene ((SceneManager.GetActiveScene ().buildIndex + 1));
				Game.refresh ();
			}
			yield return null;
		}
	}

	public void whichLevel(){
	

	}
}
