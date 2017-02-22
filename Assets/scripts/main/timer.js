#pragma strict

static var timer  : float = 90.0;
var minutes : int =0;
var seconds : int =0;
function Update () {
	timer -= Time.deltaTime;
	 minutes = Mathf.Floor(timer / 60);
	 seconds = Mathf.Ceil(timer % 60);
	if(timer <= 0){
	 timer = 0;
	 // Förlust
	}
}

function OnGUI(){
//"" + timer.ToString("0")

 	GUI.Box(new Rect(10, 10, 50, 20), " "+ minutes.ToString("00") +":"+seconds.ToString("00"));

}
