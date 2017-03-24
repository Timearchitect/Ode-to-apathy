﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resetGame : MonoBehaviour {
	private static AsyncOperation ao;
	// Use this for initialization
	void Start () {
		//ao = SceneManager.LoadSceneAsync(0);
		Game.setCurrentlevelBasedOnbuildIndex (1);
		//ao.allowSceneActivation = false;
		StartCoroutine (LoadLevelWithRealProgress());
	}
	
	void Update () {
		if(Input.GetAxis ("Escape")>0){
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#endif
			Application.Quit ();
		}
		//if(Input.GetAxis ("Retry")>0){
			//aos = SceneManager.LoadSceneAsync(0);
			//aos.allowSceneActivation = true;
		//}
	}

/*	IEnumerator LoadLevelWithRealProgress(){

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
	}*/

	IEnumerator LoadLevelWithRealProgress(){
		ao = SceneManager.LoadSceneAsync (0);
		//ao =Application.LoadLevelAsync ("scenes/loading1");
		//ao = SceneManager.LoadSceneAsync(SceneManager.GetSceneAt(0).ToString());
		ao.allowSceneActivation = false;
		print("loadReal");
		while(!ao.isDone){
			//progBar.value = ao.progress;
			print("yo "+ao.progress);
			//done yo
			if(ao.progress == 0||ao.progress == 0.9f){
				//progBar.value = 1f;
				//print("finish!!");
				if(Input.GetAxis ("Retry")>0) {
					//SceneManager.LoadScene (0);
					print("pressed ENTER or Return!!");
					ao.allowSceneActivation = true;
					SceneManager.LoadScene (0);
				}
			}
			yield return null;
		}
		/*
			ao.allowSceneActivation = false;
			print("loadReal");
			while(!ao.isDone && ao.progress <0.9f){
				print("reset "+ao.progress);
				yield return null;
			}
			print("finish!!");

			if(Input.GetAxis ("Retry") > 0 ){
				SceneManager.LoadScene (0);
				ao.allowSceneActivation = true;
			}
		*/
	}

		/*IEnumerator LoadLevelWithFakeProgress(){
		//while (progBar.value != 1f) {
		//progBar.value += fakeIncrement;
		//		yield return new WaitForSeconds (fakeTiming);

		//	}

			while (ao.progress == 1f) {
				if (Input.GetKeyDown (KeyCode.F)) {
					SceneManager.LoadScene ((SceneManager.GetActiveScene ().buildIndex + 1));
					Game.refresh ();
				}
				yield return null;
			}
		}
		*/

}
