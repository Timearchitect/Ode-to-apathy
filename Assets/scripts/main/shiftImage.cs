using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shiftImage : MonoBehaviour {
	[SerializeField]
	public Sprite[] macImage= new Sprite[2] ,winImage= new Sprite[2] ;
	public float Shiftduration=5,startTime=15;
	private float timer;
	private int index=1;
	private bool transition,Out;

	void Start () {
	}

	void Update () {
		if(  startTime<Time.timeSinceLevelLoad){
			if (timer + Shiftduration < Time.timeSinceLevelLoad ) {
				timer = Time.timeSinceLevelLoad;
				index++;
				transition = true;
			}
			if(transition){
				if(Out) fadeOut();
				else fadeIn();
			}
		}
	}

	private void fadeOut(){
		if (this.gameObject.GetComponent<Image> ().color.a > 0.05f) {
			print ("out " + this.gameObject.GetComponent<Image> ().color.a+ Out);
			this.gameObject.GetComponent<Image> ().color = new Color (1, 1, 1, this.gameObject.GetComponent<Image> ().color.a - 0.02f);
		} else {
			Out = false;
			swapImage ();
		}
	}
	private void fadeIn(){
		if (this.gameObject.GetComponent<Image> ().color.a < 0.95f) {
			this.gameObject.GetComponent<Image> ().color = new Color (1, 1, 1, this.gameObject.GetComponent<Image> ().color.a + 0.02f);
			print ("in "+this.gameObject.GetComponent<Image> ().color.a+ Out);
		} else {
			transition = false;
			Out = true;
		}
	}

	private void swapImage(){
		if(SystemInfo.operatingSystemFamily==OperatingSystemFamily.Windows){
			this.gameObject.GetComponent<Image>().sprite=winImage[index%winImage.Length];
		}
		if(SystemInfo.operatingSystemFamily==OperatingSystemFamily.MacOSX){
			this.gameObject.GetComponent<Image>().sprite=macImage[index%macImage.Length];
		}

	}
}
