using UnityEngine;
using System.Collections;

public class Texto : MonoBehaviour {

    int currentPosition = 0;
    float Delay = 0.1f;
    string Text = "Você sabe, não?";
    public string[] additionalLines;

	public string[] otherTexts;

	int i = 0;

	void Awake() {
		otherTexts[0] = "você aí";
		otherTexts[1] = "é, você mesmo!";
		otherTexts[2] = "seu imbecil";
		otherTexts[3] = "eita, porra, confundi o cara.";
		otherTexts[4] = "malz ae";
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(FirstStep());
	}
	
	/*
    void WriteText(string aText)
    {
        guiText.text = "";
        currentPosition = 0;
        Text = aText;
    }*/

	void Update () {

		if (Input.GetKeyDown("up")){
			i++;
			TrocaTexto();
		}

	}

	IEnumerator FirstStep () {
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

	void TrocaTexto() {
		guiText.text = "";
		currentPosition = 0;

		Text = otherTexts[i];

		StartCoroutine(FirstStep());
	}

}
