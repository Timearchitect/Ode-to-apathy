using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class circleTimer : MonoBehaviour {
	GameObject go;
	Canvas can;

	//private float [][] point;
	private Vector3[] vertex = new Vector3[360];
	private int range=30;
	LineRenderer lineRenderer;
	// Use this for initialization
	void Start () {
		lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.startColor = (new Color(1,0,0,1));
		lineRenderer.endColor = (new Color(1,0.5f,0.5f,1));
		lineRenderer.startWidth = (10);
		lineRenderer.endWidth = (10);
		lineRenderer.numPositions = 360;
		//lineRenderer.SetVertexCount(360);
		//can = this.gameObject as Canvas;
		for(int i=0; i<360 ; i+=1){
			vertex [i] = new Vector3 (Mathf.Cos(Mathf.Deg2Rad*(i+90)) * range,Mathf.Sin(Mathf.Deg2Rad*(i+90)) * range+200,0);
			//if(180<i)lineRenderer.SetPosition (i ,vertex[i]);
		}
		//lineRenderer.SetPositions(vertex);
		//this.transform.position=GameObject.Find ("Player").transform.position;
		//lineRenderer.transform.position = GameObject.Find ("Player").transform.position;
		//lineRenderer.transform.position = new Vector3 (lineRenderer.transform.position.x,lineRenderer.transform.position.y+1000,lineRenderer.transform.position.z);
	}

	// Update is called once per frame
	void Update () {
		lineRenderer.numPositions = Mathf.CeilToInt(Stats.apathy*3.6f);
		for(int i=0; i<Mathf.CeilToInt(Stats.apathy*3.6f) ; i+=1){
			lineRenderer.SetPosition (i ,vertex[i]);
		}
		//Canvas.ForceUpdateCanvases ();
	}
}
