using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class toCredits : MonoBehaviour {
	public float startTime=25;
//	private SceneManager ao;
	private static AsyncOperation ao;

	void Start () {

		StartCoroutine (LoadLevelWithRealProgress());


	}


	void Update () {
		if(Input.GetAxis ("Escape")>0){
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#endif
			Application.Quit ();
		}
		if (startTime < Time.timeSinceLevelLoad) {
			Application.LoadLevel (SceneManager.sceneCountInBuildSettings-1);

		}

	}




	IEnumerator LoadLevelWithRealProgress(){
			ao = SceneManager.LoadSceneAsync (SceneManager.sceneCountInBuildSettings-1);
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
				//	if (Input.GetAxis ("Retry") > 0) {
					if (startTime < Time.timeSinceLevelLoad) {
						print ("pressed ENTER or Return!!");
						ao.allowSceneActivation = true;
						SceneManager.LoadScene (SceneManager.sceneCountInBuildSettings-1);
					}
					if(Input.GetAxis ("Retry")>0) {
						print ("pressed ENTER or Return!!");
						ao.allowSceneActivation = true;
						SceneManager.LoadScene (SceneManager.sceneCountInBuildSettings-1);
					}

	
				//}
			}
			yield return null;
		}
	}

}
