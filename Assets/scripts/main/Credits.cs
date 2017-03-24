using UnityEngine;

public class Credits : MonoBehaviour
{
	private float offset;
	public float speed = -40.0f;
	public GUIStyle style;
	private Rect viewArea;

	private void Start()
	{
		Time.timeScale = 1;
		style.font = (Font)Resources.Load("helvetica-normal-58c53b4136502");
		style.alignment = TextAnchor.MiddleCenter;
		style.fontSize =(int)(Screen.width*0.03f);
		offset = Screen.height*0.7f;
		viewArea = new Rect ( 0,0,Screen.width, Screen.height);
		//this.offset = this.viewArea.width*.5f;
	}

	private void Update()
	{
		this.offset -= Time.deltaTime * this.speed;
	}

	private void OnGUI()
	{

		GUI.BeginGroup(this.viewArea);
		//viewArea.center = new Vector2 (Screen.width*0.6f,0);
		var position = new Rect(Screen.width*.1f,offset , Screen.width, Screen.height);
		/*var text = @"Ode to Apathy - the best game ever, brought to you by:
				
		Alrik He
		Graziella Sundblad
		Jakob Håkonsson
		Mattias Wendt 
		Victor Lind


		";
		*/
		var text = @"Ode to Apathy , brought to you by:

Alrik He
Graziella Sundblad
Jakob Håkonsson
Mattias Wendt 
Victor Lind


press [Enter] to replay.
		";
		GUI.Label(position, text, style);
	
		GUI.EndGroup();
	}
}