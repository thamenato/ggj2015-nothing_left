using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gato : MonoBehaviour {

	public Sprite[] gatoSprite;
	public float satisfacao;
	public float disposicao;
	public string text;
    public GameObject actionTextObject;
    public AudioClip[] gatoSom;
    public GameObject player;

    Text canvas_actionText;
    Text canvas_actionText_shadow;

	Transform char_transform;
	Animator char_animator;
	bool activated = false;
	GameController gameController;

    Text[] actionText;

	// Use this for initialization
	void Start () {

        actionText = actionTextObject.GetComponentsInChildren<Text>();
        canvas_actionText = actionText[0];
        canvas_actionText_shadow = actionText[1];

        char_transform = player.GetComponent<Transform>();
        char_animator = player.GetComponent<Animator>();

		var find_gameController = GameObject.Find ("GameController");
		if (find_gameController == null)
			print ("GameController not found");
		else
			gameController = find_gameController.GetComponent<GameController>();	
	}

	void OnTriggerStay(Collider other){
		// if Scale x < 0 the Char is facing to the right and Gato never used before
		if (other.name == "Char" && char_transform.localScale.x < 0 && activated == false){
			canvas_actionText_shadow.text = canvas_actionText.text = text;
			if(Input.GetKey(KeyCode.Space)){
				activated = true;
				randomReaction();
				char_animator.Play("CarinhoGato");
			}
		}
        else {
            canvas_actionText_shadow.text = canvas_actionText.text = "";
        }
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
			canvas_actionText_shadow.text = canvas_actionText.text = "";
		}
	}
}
