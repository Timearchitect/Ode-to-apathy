#pragma strict

var timer  : float = 90.0;

function Update () {
	timer -= Time.deltaTime;

	if(timer <= 0){
	 timer = 0;
	 // Förlust
	}
}

function OnGUI(){
 	GUI.Box(new Rect(10, 10, 50, 20), "" + timer.ToString("0"));
 	
}
