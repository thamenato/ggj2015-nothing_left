using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gato : MonoBehaviour {

	public Sprite[] gatoSprite;

	public string Action_Text;
	Text canvas_actionText;
	Transform char_transform;
	Animator char_animator;
	bool activated = false;

	// Use this for initialization
	void Start () {
		// Seeks for 'actionText' inside Canvas and returns it to local variable actionText
		var find_actionText = GameObject.Find("actionText");
		if (find_actionText == null)
			print ("actionText not found");
		else
			canvas_actionText = find_actionText.GetComponent<Text>();

		var find_Char = GameObject.Find ("Char");
		if (find_Char == null)
			print ("Char not found");
		else {
			char_transform = find_Char.GetComponent<Transform>();
			char_animator = find_Char.GetComponent<Animator>();
		}
	}

	void OnTriggerStay(Collider other){
		// if Scale x < 0 the Char is facing to the right and Gato never used before
		if (other.name == "Char" && char_transform.localScale.x < 0 && activated == false){
			canvas_actionText.text = Action_Text;
			if(Input.GetKeyDown(KeyCode.Space)){
				activated = true;
				char_animator.Play("CarinhoGato");
			}
		}
		else
			canvas_actionText.text = "";
	}

	void OnTriggerExit(Collider other){
		if (other.name == "Char"){
			canvas_actionText.text = "";
		}
	}
}
