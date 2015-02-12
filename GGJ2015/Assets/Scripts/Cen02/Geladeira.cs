using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Geladeira : MonoBehaviour {

    // Satisfaction and disposition for this event
    public float satisfacao;
    public float disposicao;

    // Text for action text of this event
    public string text;
    
    // Player
    public GameObject player;
    
    // Fridge sprites and dialogs
    public GameObject[] geladeira;
    public GameObject[] dialogsGeladeira;
    
    // Action Text
    public Text actionText;
    public Text actionText_shadow;

    Animator char_animator;
    bool activated = false;
    GameController gameController;
    
	// Use this for initialization
	void Start () {
        // get animator from Player
        char_animator = player.GetComponent<Animator>();

        // finds the GameController
        var find_gameController = GameObject.Find("GameController");
        if (find_gameController == null)
            print("GameController not found");
        else
            gameController = find_gameController.GetComponent<GameController>();
	}

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && activated == false)
        {
            
            actionText_shadow.text = actionText.text = text;
            
            // if the player interacts with the fridge
            if (Input.GetKey(KeyCode.Space))
            {
                activated = true; // cant interact anymore

                // Random reaction 
                var val = Random.Range(0, 10);
                if (val <= 5)
                    StartCoroutine(noFood());
                else
                    StartCoroutine(withFood());
            }
        }
        else
            actionText_shadow.text = actionText.text = "";
    }

    IEnumerator noFood()
    {
        // show sprite of fridge without food
        geladeira[1].gameObject.renderer.enabled = true;
        
        actionText.text = "";
        
        // Dialogs
        Instantiate(dialogsGeladeira[1]);
        
        if(gameController != null)
        {
            gameController.diminuiDisposicao(disposicao);
            print("disposicao = " + gameController.getDisposicao());

            gameController.diminuiSatisfacao(satisfacao);
            print("satisfacao = " + gameController.getSatisfacao());
        }
        
        char_animator.SetBool("blocked", true);

        //playSound
        yield return new WaitForSeconds(4);

        Destroy(GameObject.FindGameObjectWithTag("dialog"));

        var val = Random.Range(0, 10);
        if (val <= 3)
        {	// positivo
            Instantiate(dialogsGeladeira[2]);

            if (gameController != null)
            {
                gameController.aumentaDisposicao(disposicao);
                print("disposicao = " + gameController.getDisposicao());

                gameController.aumentaSatisfacao(satisfacao);
                print("satisfacao = " + gameController.getSatisfacao());
            }
            
            yield return new WaitForSeconds(6);
            Destroy(GameObject.FindGameObjectWithTag("dialog"));

            Instantiate(dialogsGeladeira[3]);

            yield return new WaitForSeconds(3);
            Destroy(GameObject.FindGameObjectWithTag("dialog"));

        }
        else
        {	// negativo
            Instantiate(dialogsGeladeira[4]);

            if(gameController != null)
            {
                gameController.diminuiSatisfacao(satisfacao);
                print("satisfacao = " + gameController.getSatisfacao());
            }

            yield return new WaitForSeconds(6);

            Destroy(GameObject.FindGameObjectWithTag("dialog"));
        }

        geladeira[1].gameObject.renderer.enabled = false;
        actionText.text = "";
        char_animator.SetBool("blocked", false);
    }



    IEnumerator withFood()
    {
        geladeira[2].gameObject.renderer.enabled = true;
        
        actionText.text = "";
        
        // Dialogs
        Instantiate(dialogsGeladeira[0]);
        
        if(gameController != null)
        {

            gameController.aumentaDisposicao(disposicao);
            print("disposicao = " + gameController.getDisposicao());

            gameController.aumentaSatisfacao(satisfacao);
            print("satisfacao = " + gameController.getSatisfacao());
        }

        char_animator.SetBool("blocked", true);

        // playSound
        
        yield return new WaitForSeconds(3);
        
        geladeira[2].gameObject.renderer.enabled = false;
        actionText.text = "";
        char_animator.SetBool("blocked", false);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            actionText_shadow.text = actionText.text = "";
            Destroy(GameObject.FindGameObjectWithTag("dialog"));
        }
    }
}
