#pragma strict
//script inserido nos textos do jogo
//simula alguem digitando
//peguei da internet

var currentPosition : int = 0;
var Delay : float = 0.1;  // 10 characters per sec.
var Text : String = "";
var additionalLines : String[];
 
function WriteText(aText : String) {
    guiText.text = "";
    currentPosition = 0;
    Text = aText;
}
 
function Start(){
	
    	for ( var S : String in additionalLines )
        	Text += "\n" + S;
    	while (true){
        	if (currentPosition < Text.Length)
            	guiText.text += Text[currentPosition++];
        	yield WaitForSeconds (Delay);
    				}

}

@script RequireComponent(GUIText)