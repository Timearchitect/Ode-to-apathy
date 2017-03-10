using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class circleTimer : MonoBehaviour {
	GameObject go;
	Canvas can;

	//private float [][] point;
	private Vector3[] vertex = new Vector3[360];
	private Vector3[] vertexPen = new Vector3[360];
	private int range=30;
	private int xoffset=70,yoffset=200;
	LineRenderer lineRenderer;
	Image icon;
	Vector3 keyboardPos,penPos;

	void Start () {
		lineRenderer = gameObject.AddComponent<LineRenderer>();
		//icon = gameObject.AddComponent<Image>();
		icon=GetComponent<Image>();
		//icon=GetComponent<SpriteRenderer>();
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.startColor = (new Color(1,0,0,1));
		lineRenderer.endColor = (new Color(1,0.5f,0.5f,1));
		lineRenderer.startWidth = (10);
		lineRenderer.endWidth = (10);
		lineRenderer.numPositions = 360;

		icon.sprite=Resources.Load<Sprite>("codingicon") as Sprite;
		keyboardPos = new Vector3(Screen.width*.5f,Screen.height*.5f,GameObject.Find ("Player").transform.position.z);
		penPos = new Vector3(Screen.width*.61f,Screen.height*.5f,GameObject.Find ("Player").transform.position.z);

		for(int i=0; i<360 ; i+=1){
			vertex [i] = new Vector3 (Mathf.Cos(Mathf.Deg2Rad*(i+90)) * range,Mathf.Sin(Mathf.Deg2Rad*(i+90)) * range+yoffset,0);
			//if(180<i)lineRenderer.SetPosition (i ,vertex[i]);
		}
		for(int i=0; i<360 ; i+=1){
			vertexPen [i] = new Vector3 (Mathf.Cos(Mathf.Deg2Rad*(i+90)) * range+xoffset,Mathf.Sin(Mathf.Deg2Rad*(i+90)) * range+yoffset,0);
			//if(180<i)lineRenderer.SetPosition (i ,vertex[i]);
		}
		transform.position = keyboardPos;

		//lineRenderer.SetPositions(vertex);
		//this.transform.position=GameObject.Find ("Player").transform.position;
		//lineRenderer.transform.position = GameObject.Find ("Player").transform.position;
		//lineRenderer.transform.position = new Vector3 (lineRenderer.transform.position.x,lineRenderer.transform.position.y+1000,lineRenderer.transform.position.z);
	}

	// Update is called once per frame
	void Update () {
		if (!Game.pause) {
			if (Stats.workMode == 0) {
				if (Stats.pWorkMode != Stats.workMode) {
					transform.position = keyboardPos;
					icon.sprite = Resources.Load<Sprite> ("codingicon") as Sprite;
				}
				if (Stats.codeProgess <= 100) {
					lineRenderer.numPositions = Mathf.CeilToInt (360 - Stats.codeProgess * 3.6f);
					for (int i = 0; i < Mathf.CeilToInt (360 - Stats.codeProgess * 3.6f); i += 1) {
						lineRenderer.SetPosition (i, vertex [i]);
					}
				}
			} else {
				if (Stats.drawProgess <= 100) {
					if (Stats.pWorkMode != Stats.workMode) {
						transform.position = penPos;
						icon.sprite = Resources.Load<Sprite> ("drawingicon") as Sprite;
					}
					lineRenderer.numPositions = Mathf.CeilToInt (360 - Stats.drawProgess * 3.6f);
					for (int i = 0; i < Mathf.CeilToInt (360 - Stats.drawProgess * 3.6f); i += 1) {
						lineRenderer.SetPosition (i, vertexPen [i]);
					}
				}
			}
		}
	}

	public static void render(){

	
	}
}


