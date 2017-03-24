using UnityEngine;

public class Credits : MonoBehaviour
{
	private float offset;
	public float speed = 50.0f;
	public GUIStyle style;
	public Rect viewArea;

	private void Start()
	{
		this.offset = this.viewArea.height;
	}

	private void Update()
	{
		this.offset -= Time.deltaTime * this.speed;
	}

	private void OnGUI()
	{
		GUI.BeginGroup(this.viewArea);

		var position = new Rect(0, this.offset, this.viewArea.width, this.viewArea.height);
		var text = @"Ode to Apathy - the best game ever, brought to you by:
		
Alrik He
Graziella Sundblad
Jakob Håkonsson
Mattias Wendt 
Victor Lind


";

		GUI.Label(position, text, this.style);

		GUI.EndGroup();
	}
}