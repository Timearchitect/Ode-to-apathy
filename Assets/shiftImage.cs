using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shiftImage : MonoBehaviour {
	[SerializeField]
	public Sprite[] macImage= new Sprite[2] ,winImage= new Sprite[2] ;
	public float Shiftduration=5;
	private float timer;
	private int index;
	void Start () {
		
	}

	void Update () {
		if (timer + Shiftduration < Time.timeSinceLevelLoad) {
			timer = Time.timeSinceLevelLoad;
			index++;
			if(SystemInfo.operatingSystemFamily==OperatingSystemFamily.Windows){
				this.gameObject.GetComponent<Image>().sprite=winImage[index%winImage.Length];
			}
			if(SystemInfo.operatingSystemFamily==OperatingSystemFamily.MacOSX){
				this.gameObject.GetComponent<Image>().sprite=macImage[index%macImage.Length];
			}

		}
	}
}
