using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class circleTimer : MonoBehaviour {
	GameObject go;
	Canvas can;

	private Vector3[] vertex = new Vector3[360],vertexPen = new Vector3[360];
	private int range=30,xoffset=70,yoffset=200;
	LineRenderer lineRenderer;
	SpriteRenderer icon2;
	Vector3 keyboardPos,penPos;

	void Start () {
		try{
			lineRenderer = gameObject.AddComponent<LineRenderer>();
			icon2 = GetComponent<SpriteRenderer> ();

			lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
			lineRenderer.startColor = (new Color(1,0,0,1));
			lineRenderer.endColor = (new Color(1,0.5f,0.5f,1));
			lineRenderer.startWidth = (10);
			lineRenderer.endWidth = (10);
			lineRenderer.numPositions = 360;

			icon2.sprite=Resources.Load<Sprite>("codingicon") as Sprite;
			keyboardPos = new Vector3(0,yoffset,GameObject.Find ("Player").transform.position.z);
			penPos = new Vector3(xoffset,yoffset,GameObject.Find ("Player").transform.position.z);
			this.transform.position = keyboardPos;

			for(int i=0; i<360 ; i+=1){
				vertex [i] = new Vector3 (Mathf.Cos(Mathf.Deg2Rad*(i+90)) * range,Mathf.Sin(Mathf.Deg2Rad*(i+90)) * range+yoffset,0);
			}
			for(int i=0; i<360 ; i+=1){
				vertexPen [i] = new Vector3 (Mathf.Cos(Mathf.Deg2Rad*(i+90)) * range+xoffset,Mathf.Sin(Mathf.Deg2Rad*(i+90)) * range+yoffset,0);
			}
		}catch{
			UnityEngine.Debug.LogError ("Error in "+this.name +" please check in script: ");
			UnityEditor.EditorApplication.isPlaying = false;
			UnityEditor.EditorApplication.isPaused = true;

		}
	}

	// Update is called once per frame
	void Update () {
		if (!Game.pause) {
			if (Stats.workMode == 0) {
				if (Stats.pWorkMode != Stats.workMode) {
					this.transform.position = keyboardPos;
					icon2.sprite = Resources.Load<Sprite> ("codingicon") as Sprite;
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
						this.transform.position = penPos;
						icon2.sprite = Resources.Load<Sprite> ("drawingicon") as Sprite;
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


