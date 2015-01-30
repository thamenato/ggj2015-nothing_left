using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Porta : MonoBehaviour {

	public string Action_Text;
	public AudioClip portaSom;
	Text canvas_actionText;
    Text canvas_actionText_shadow;
    //Transform char_transform;
	
	// Use this for initialization
	void Start () {
		// Seeks for 'actionText' inside Canvas and returns it to local variable actionText
		var find_actionText = GameObject.Find("actionText");
        var find_actionText_shadow = GameObject.Find("actionText_shadow");
        if (find_actionText == null)
			print ("actionText not found");
		else
			canvas_actionText = find_actionText.GetComponent<Text>();
        if (find_actionText_shadow == null)
            print("actionText_shadow not found");
        else
            canvas_actionText_shadow = find_actionText_shadow.GetComponent<Text>();
    }
	
	void OnTriggerStay(Collider other){
		// if Scale x < 0 the Char is facing to the right
		if (other.name == "Char"){
			canvas_actionText_shadow.text = canvas_actionText.text = Action_Text;
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
