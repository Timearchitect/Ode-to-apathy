#pragma strict

public static var timer  : float = 90.0;
var minutes : int =0;
var seconds : int =0;
function Update () {
	timer -= Time.deltaTime;
	 minutes = Mathf.Floor(timer / 60);
	 seconds = Mathf.Ceil(timer % 60);
	if(timer <= 0){
	 timer = 0;
	 seconds=0;
	 minutes=0;
	 print("finished");
	// Game.end();
	 // Förlust
	}
}

function OnGUI(){
//"" + timer.ToString("0")
     var timeStyle : GUIStyle = new GUIStyle("box");
     timeStyle.fontSize = Screen.height*.025f;

 	GUI.Box(new Rect(Screen.width*.5f, Screen.height*.02f, 80, Screen.height*.04f), " "+ minutes.ToString("00") +":"+seconds.ToString("00"),timeStyle);

}
