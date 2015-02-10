using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sala : MonoBehaviour {

	public Sprite[] avoSprite;
	public float satisfacao;
	public float disposicao;

	public GameObject[] dialogsPai;
	private bool blockSpace;
	
	public string Action_Text;
	Text canvas_actionText;
	Transform char_transform;
	Animator char_animator;
	static public int pegaControle = 0;  //0 controle no movel ; 1 controle pode ser pego;  2 controle pego; 3 controle ignorado;
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

			
			case "Cen03_06_Ignore":
				if(other.name == "Char" && pegaControle == 1 && !blockSpace){
					//StartCoroutine(DadReaction3());
					blockSpace = true;
				}
				break;
		}

	}
	

	
	void OnTriggerExit(Collider other){
		if (other.name == "Char"){
			canvas_actionText.text = "";
			blockSpace = false;
		}
	}

}
