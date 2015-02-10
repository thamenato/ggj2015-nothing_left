using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Porta : MonoBehaviour {

	public string text;
    public AudioClip portaSom;

    public Text actionText;
    public Text actionText_shadow;
	
	// Use this for initialization
	void Start () {
    
    }
	
	void OnTriggerStay(Collider other){
		// if Scale x < 0 the Char is facing to the right
		if (other.name == "Char"){
			actionText_shadow.text = actionText.text = text;
			if(Input.GetKeyDown(KeyCode.Space)){
				audio.clip = portaSom;
				audio.Play();
				Application.LoadLevel("Cen02_Cozinha");
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (other.name == "Char"){
            actionText_shadow.text = actionText.text = "";
		}
	}
}
