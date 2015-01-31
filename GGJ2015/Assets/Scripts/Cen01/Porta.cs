using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Porta : MonoBehaviour {

	public string text;
    public GameObject actionTextObject;
    public AudioClip portaSom;

    Text[] actionText;
    Text canvas_actionText;
    Text canvas_actionText_shadow;
	
	// Use this for initialization
	void Start () {

        actionText = actionTextObject.GetComponentsInChildren<Text>();
        canvas_actionText = actionText[0];
        canvas_actionText_shadow = actionText[1];
    }
	
	void OnTriggerStay(Collider other){
		// if Scale x < 0 the Char is facing to the right
		if (other.name == "Char"){
			canvas_actionText_shadow.text = canvas_actionText.text = text;
			if(Input.GetKeyDown(KeyCode.Space)){
				audio.clip = portaSom;
				audio.Play();
				Application.LoadLevel("Cen02_Cozinha");
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (other.name == "Char"){
            canvas_actionText_shadow.text = canvas_actionText.text = "";
		}
	}
}
