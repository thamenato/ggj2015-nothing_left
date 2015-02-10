using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cozinha : MonoBehaviour {

    public string text;
    
    public Text actionText;
    public Text actionText_shadow;

	// Use this for initialization
	void Start () {
    }
	
	void OnTriggerStay(Collider other){
        if (other.name == "Char"){
            actionText_shadow.text = actionText.text = text;
            if(Input.GetKeyDown(KeyCode.Space))
                Application.LoadLevel("Cen03_Sala");
		}
	}

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Char")
        {
            actionText_shadow.text = actionText.text = "";
        }
    }

}
