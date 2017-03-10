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
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void loadLevel01(){
		print ("inne loadLevel01");
		loadingScreenBG.SetActive (true);
		progBar.gameObject.SetActive (true);
		loadingText.gameObject.SetActive (true);
		loadingText.text="Loading...";

		if (!isFakeLoadingBar) {
		
			StartCoroutine (LoadLevelWithRealProgress());

		} else {
			print ("In fakeloadingbar");
			StartCoroutine(LoadLevelWithFakeProgress());

		}
	}

	IEnumerator LoadLevelWithRealProgress(){
		yield return new WaitForSeconds (1);

		ao = SceneManager.LoadSceneAsync(1);
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

		yield return new WaitForSeconds (1);

		while (progBar.value != 1f) {
			progBar.value += fakeIncrement;
			yield return new WaitForSeconds (fakeTiming);
		
		}

		while (progBar.value == 1f) {
		
			loadingText.text = "Done Loading";
			if (Input.GetKeyDown (KeyCode.F)) {
				SceneManager.LoadScene (1);
			}
			yield return null;
		}
	}
}
