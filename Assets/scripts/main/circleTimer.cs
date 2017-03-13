using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class circleTimer : MonoBehaviour {
	GameObject go;
	Canvas can;
	private Sprite codingIcon,drawingIcon; 
	private Vector3[] vertex = new Vector3[360],vertexPen = new Vector3[360];
	private int range=30,xoffset=70,yoffset=200;
	LineRenderer lineRenderer;
	SpriteRenderer icon;
	private static float strokeWidth=10;
	Vector3 keyboardPos,penPos;

	void Start () {
		try{
			lineRenderer = gameObject.AddComponent<LineRenderer>();
				print(lineRenderer.name);
			icon = GetComponent<SpriteRenderer> ();
				print(icon.name);
			codingIcon= Resources.Load<Sprite> ("codingicon") as Sprite;
				print(codingIcon.name);
			drawingIcon= Resources.Load<Sprite> ("drawingicon") as Sprite;
				print(drawingIcon.name);
			lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
				print(lineRenderer.material.name);		
			lineRenderer.startColor = (new Color(1,0,0,1));
			lineRenderer.endColor = (new Color(1,0.5f,0.5f,1));
			lineRenderer.startWidth = 10;
			lineRenderer.endWidth = 10;
			lineRenderer.numPositions = 360;
		
			icon.sprite=codingIcon;
			keyboardPos = new Vector3(0,yoffset,GameObject.Find ("Player").transform.position.z);
			penPos = new Vector3(xoffset,yoffset,GameObject.Find ("Player").transform.position.z);
			this.transform.position = keyboardPos;

			for(int i=0; i<360 ; i+=1){
				vertex [i] = new Vector3 (Mathf.Cos(Mathf.Deg2Rad*(i+90)) * range,Mathf.Sin(Mathf.Deg2Rad*(i+90)) * range+yoffset,0);
			}
			for(int i=0; i<360 ; i+=1){
				vertexPen [i] = new Vector3 (Mathf.Cos(Mathf.Deg2Rad*(i+90)) * range+xoffset,Mathf.Sin(Mathf.Deg2Rad*(i+90)) * range+yoffset,0);
			}
		}catch(Exception ex ){
			UnityEngine.Debug.LogError ("Error in "+this.name +" please check row "+ex.ToString ().Split (':') [3]+" in script: ");
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
					icon.sprite = codingIcon;
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
						icon.sprite = drawingIcon;
					}
					lineRenderer.numPositions = Mathf.CeilToInt (360 - Stats.drawProgess * 3.6f);
					for (int i = 0; i < Mathf.CeilToInt (360 - Stats.drawProgess * 3.6f); i += 1) {
						lineRenderer.SetPosition (i, vertexPen [i]);
					}
				}
			}
			retract ();
		}
	}
	public static void pop(){
		strokeWidth=30;
	}
	public  void retract(){
		if (strokeWidth >= 10) {
			strokeWidth *= .95f;
			lineRenderer.startWidth = strokeWidth;
			lineRenderer.endWidth = strokeWidth;
		}
	}
	public static void render(){

	
	}
}


