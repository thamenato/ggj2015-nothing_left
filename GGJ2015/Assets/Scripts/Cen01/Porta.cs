using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Porta : MonoBehaviour {

	public AudioClip portaSom;

    // canvas Text
    public Text actionText;
    public Text actionText_shadow;

    public string nextScene;
    
    string text; // text for action text
    
    void Start()
    {
        text = Events.eventsTextAction[name];
    }

	void OnTriggerStay(Collider other)
    {
		if (other.tag == "Player")
        {  
			// if player stands on collider, shows the text for this action
            actionText_shadow.text = actionText.text = text;
			
            // if player press space - do action
            if(Input.GetKeyDown(KeyCode.Space)){
				audio.clip = portaSom;
				audio.Play();
				Application.LoadLevel(nextScene);
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player"){
            // player not standing on collider anymore
            actionText_shadow.text = actionText.text = "";
		}
	}
}
