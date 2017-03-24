using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class reviewPop : MonoBehaviour {
	public Transform endTransform;
	Image img;
	[SerializeField]
	public long startTime;
	// Use this for initialization
	void Start () {
		img = this.GetComponent<Image> ();
		print (img.name);
		img.fillAmount=0;
		//endTransform.position =  new Vector3 (this.gameObject.transform.position.x,this.gameObject.transform.position.y,this.gameObject.transform.position.z);
		this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x,this.gameObject.transform.position.y,this.gameObject.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		//print ((this.gameObject.transform.position.x-endTransform.position.x));
		//if(Time.timeSinceLevelLoad>startTime && this.gameObject.transform.position.x<Screen.width*.5f)this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x+20,this.gameObject.transform.position.y,this.gameObject.transform.position.z);
		if(Time.timeSinceLevelLoad>startTime) img.fillAmount+=0.01f;
		print (img.fillAmount);
	
	
	}
}
