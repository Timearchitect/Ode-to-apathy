using System.Collections;
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
		print (this+"level "+Stats.currentLevel+" this!!!");
		Game.refresh ();
		Stats.currentLevel=4; // to overview scene
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void loadLevel01(){
		print ("inne level "+Stats.currentLevel);
		loadingScreenBG.SetActive (true);
		progBar.gameObject.SetActive (true);
		loadingText.gameObject.SetActive (true);
		loadingText.text="Loading...";

		if (!isFakeLoadingBar) {
			print ("inne StartCoroutine");

			StartCoroutine (LoadLevelWithRealProgress());

		} else {
			print ("In fakeloadingbar");
			StartCoroutine(LoadLevelWithFakeProgress());

		}
	}

	IEnumerator LoadLevelWithRealProgress(){
		print ("load");
		//yield return new WaitForSeconds (1);   // ehh... väntar förevigt från overview


		ao = SceneManager.LoadSceneAsync(Stats.currentLevel);
		ao.allowSceneActivation = false;

		while(!ao.isDone){
			progBar.value = ao.progress;

			//done yo
			if(ao.progress == 0.9f){
				progBar.value = 1f;

				loadingText.text = "Press 'F'to begin";
				if(Input.GetKeyDown(KeyCode.F)){
					ao.allowSceneActivation = true;
				}
			}
			Debug.Log(ao.progress);
			yield return null;
		

		}
	}

	IEnumerator LoadLevelWithFakeProgress(){
		print ("fake");

		yield return new WaitForSeconds (1);

		while (progBar.value != 1f) {
			print ("increase");
			progBar.value += fakeIncrement;
			yield return new WaitForSeconds (fakeTiming);
		
		}

		while (progBar.value == 1f) {
		
			loadingText.text = "Done Loading";
			if (Input.GetKeyDown (KeyCode.F)) {
				Application.UnloadLevel (Stats.currentLevel-1);
				SceneManager.LoadScene (Stats.currentLevel);
			}
			yield return null;
		}
	}


}
