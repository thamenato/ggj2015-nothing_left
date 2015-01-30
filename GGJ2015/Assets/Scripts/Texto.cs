using UnityEngine;
using System.Collections;

public class Texto : MonoBehaviour {

    int currentPosition = 0;
    float Delay = 0.1f;
    string Text = "";
    string[] additionalLines;

	// Use this for initialization
	IEnumerator Start () {
	    foreach(string s in additionalLines){
            Text += "\n" + s;
        }
        while (true)
        {
            if (currentPosition < Text.Length)
                guiText.text += Text[currentPosition++];
            yield return new WaitForSeconds(Delay);
        }
	}
	

    void WriteText(string aText)
    {
        guiText.text = "";
        currentPosition = 0;
        Text = aText;
    }

}
