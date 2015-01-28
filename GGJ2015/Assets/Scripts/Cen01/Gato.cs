using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gato : MonoBehaviour {

	public Sprite[] gatoSprite;
	public float satisfacao;
	public float disposicao;
	public string Action_Text;
	public AudioClip[] gatoSom;

	Text canvas_actionText;
	Transform char_transform;
	Animator char_animator;
	bool activated = false;
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
		// if Scale x < 0 the Char is facing to the right and Gato never used before
		if (other.name == "Char" && char_transform.localScale.x < 0 && activated == false){
			canvas_actionText.text = Action_Text;
			if(Input.GetKeyDown(KeyCode.Space)){
				activated = true;
				randomReaction();
				char_animator.Play("CarinhoGato");
			}
		}
		else
			canvas_actionText.text = "";
	}

	void randomReaction(){
		var val = Random.Range(0, 10);
		if(val <= 5)
			gatoRonrona();
		else
			gatoArranha();
	}

	void gatoRonrona(){
		audio.clip = gatoSom[0];
		audio.Play();
		gameController.aumentaSatisfacao(satisfacao);
		print("satisfacao = " + gameController.getSatisfacao());

		gameController.diminuiDisposicao(disposicao);
		print("disposicao = " + gameController.getDisposicao());

	}

	void gatoArranha(){
		audio.clip = gatoSom[1];
		audio.Play();
		gameController.diminuiSatisfacao(satisfacao);
		print("satisfacao = " + gameController.getSatisfacao());

		gameController.diminuiDisposicao(disposicao);
		print("disposicao = " + gameController.getDisposicao());

		StartCoroutine(TrocaSprite());
	}

	IEnumerator TrocaSprite(){
		gameObject.GetComponent<SpriteRenderer>().sprite = gatoSprite[0];
		//playSound
		yield return new WaitForSeconds(1.5f);
		gameObject.GetComponent<SpriteRenderer>().sprite = gatoSprite[1];

	}

	void OnTriggerExit(Collider other){
		if (other.name == "Char"){
			canvas_actionText.text = "";
		}
	}
}
