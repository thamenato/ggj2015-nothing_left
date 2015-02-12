using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gato : MonoBehaviour {

    // Satisfaction and disposition for this event
    public float satisfacao;
    public float disposicao;

    // Text for action text of this event
    public string text;
    
    // sprites to change during animation
	public Sprite[] gatoSprite;
	public AudioClip[] gatoSom;

    // player
    public GameObject player;

    // Action Text
    public Text actionText;
    public Text actionText_shadow;

	Transform char_transform;
	Animator char_animator;
	bool activated = false;
	GameController gameController;

	// Use this for initialization
	void Start () {
        // get transform and animator from Player
        char_transform = player.GetComponent<Transform>();
        char_animator = player.GetComponent<Animator>();

        // finds the GameController
		var find_gameController = GameObject.Find ("GameController");
		if (find_gameController == null)
			print ("GameController not found");
		else
			gameController = find_gameController.GetComponent<GameController>();	
	}

	void OnTriggerStay(Collider other){
        // if Scale x < 0 the Char is facing to the right and Gato never used before
		if (other.tag == "Player" && char_transform.localScale.x < 0 && activated == false)
        {    
            actionText_shadow.text = actionText.text = text;
			
            // if player interacts with the cat
            if(Input.GetKey(KeyCode.Space))
            {
				activated = true;   // cant interact anymore
				randomReaction();
				char_animator.Play("CarinhoGato");
			}
		}
        else
            actionText_shadow.text = actionText.text = "";
    }


	void randomReaction()
    {
		var val = Random.Range(0, 10);
		if(val <= 5)
			gatoRonrona();
		else
			gatoArranha();
	}

	void gatoRonrona()
    {
		audio.clip = gatoSom[0];
		audio.Play();
	    
        if(gameController != null)
        {
            gameController.aumentaSatisfacao(satisfacao);
            print("satisfacao = " + gameController.getSatisfacao());

            gameController.diminuiDisposicao(disposicao);
            print("disposicao = " + gameController.getDisposicao());
        }
    }

	void gatoArranha()
    {
		audio.clip = gatoSom[1];
		audio.Play();

        if (gameController != null)
        {
            gameController.diminuiSatisfacao(satisfacao);
            print("satisfacao = " + gameController.getSatisfacao());

            gameController.diminuiDisposicao(disposicao);
            print("disposicao = " + gameController.getDisposicao());

        }
        
		StartCoroutine(TrocaSprite());
	}

	IEnumerator TrocaSprite()
    {
		gameObject.GetComponent<SpriteRenderer>().sprite = gatoSprite[0];
		yield return new WaitForSeconds(1.5f);
		gameObject.GetComponent<SpriteRenderer>().sprite = gatoSprite[1];

	}

	void OnTriggerExit(Collider other)
    {
		if (other.tag == "Player")
			actionText_shadow.text = actionText.text = "";
	}
}
