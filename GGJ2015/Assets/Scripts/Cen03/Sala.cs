using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sala : MonoBehaviour {

	public Sprite[] avoSprite;
	
	public string Action_Text;
	Text canvas_actionText;
	Transform char_transform;
	Animator char_animator;
	static public int pegaControle = 0;  //0 controle no movel ; 1 controle pode ser pego;  2 controle pego;
	GameController gameController;
	
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
		var find_gameController = GameObject.Find ("GameController");
		if (find_gameController == null)
			print ("GameController not found");
		else
			gameController = find_gameController.GetComponent<GameController>();	
	}
	
	void OnTriggerStay(Collider other){

		switch(gameObject.name){
			case "Cen03_00_Fundo": //Saida da sala
				if (other.name == "Char"){
					canvas_actionText.text = "Go Outside";
					if(Input.GetKeyDown(KeyCode.Space))
						Application.LoadLevel("Cen05_Parque");
				}
				break;
			case "Cen03_01_Controle": //Saida da sala
		
				if (other.name == "Char" && pegaControle == 1){
					canvas_actionText.text = "Take the Remote Control";
					if(Input.GetKeyDown(KeyCode.Space)){
						pegaControle = 2;
						gameObject.renderer.enabled=false;
						gameObject.collider.enabled=false;
					}
				}
				break;
			case "Cen03_02a_Pai": //Saida da sala
				if (other.name == "Char" && pegaControle == 0){
					canvas_actionText.text = "Talk with Dad";
					if(Input.GetKeyDown(KeyCode.Space)){
						pegaControle = 1;
						canvas_actionText.text = "";

						//gameObject.renderer.enabled=false;
					}
				}
				if (other.name == "Char" && pegaControle == 2){
					canvas_actionText.text = "Give Remote Control";
					if(Input.GetKeyDown(KeyCode.Space)){
						pegaControle = 3;
						canvas_actionText.text = "";

						//gameObject.renderer.enabled=false;
					}
				}
				break;
		}

	}
	

	
	void OnTriggerExit(Collider other){
		if (other.name == "Char"){
			canvas_actionText.text = "";
		}
	}
}
