using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gato : MonoBehaviour {

	public Sprite[] gatoSprite;
	public float satisfacao;
	public float disposicao;
	public string text;
    public AudioClip[] gatoSom;
    public GameObject player;

    public Text actionText;
    public Text actionText_shadow;

	Transform char_transform;
	Animator char_animator;
	bool activated = false;
	GameController gameController;

	// Use this for initialization
	void Start () {

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
            actionText_shadow.text = actionText.text = text;
			if(Input.GetKey(KeyCode.Space)){
				activated = true;
				randomReaction();
				char_animator.Play("CarinhoGato");
			}
		}
        else {
            actionText_shadow.text = actionText.text = "";
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
			actionText_shadow.text = actionText.text = "";
		}
	}
}
