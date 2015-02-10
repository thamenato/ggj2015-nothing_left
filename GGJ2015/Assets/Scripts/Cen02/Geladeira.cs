using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Geladeira : MonoBehaviour {

    public GameObject player;
    public GameObject[] geladeira;
    public GameObject[] dialogsGeladeira;
    public float disposicao;
    public float satisfacao;
    public string text;
    
    public Text actionText;
    public Text actionText_shadow;

    Animator char_animator;
    bool activated = false;
    GameController gameController;
    
	// Use this for initialization
	void Start () {
        //char_transform = player.GetComponent<Transform>();
        char_animator = player.GetComponent<Animator>();

        var find_gameController = GameObject.Find("GameController");
        if (find_gameController == null)
            print("GameController not found");
        else
            gameController = find_gameController.GetComponent<GameController>();
	}

    void OnTriggerStay(Collider other)
    {
        // if Scale x < 0 the Char is facing to the right and Gato never used before
        if (other.name == "Char" && activated == false)
        {
            actionText_shadow.text = actionText.text = text;
            if (Input.GetKey(KeyCode.Space))
            {
                activated = true;
                var val = Random.Range(0, 10);
                if (val <= 5)
                    StartCoroutine(noFood());
                else
                    StartCoroutine(withFood());
            }
        }
        else
        {
            actionText_shadow.text = actionText.text = "";
        }
    }

    IEnumerator noFood()
    {
        geladeira[1].gameObject.renderer.enabled = true;
        // Dialogs
        actionText.text = "";

        Instantiate(dialogsGeladeira[1]);
        gameController.diminuiDisposicao(disposicao);
        print("disposicao = " + gameController.getDisposicao());

        gameController.diminuiSatisfacao(satisfacao);
        print("satisfacao = " + gameController.getSatisfacao());

        char_animator.SetBool("blocked", true);

        //playSound
        yield return new WaitForSeconds(4);

        Destroy(GameObject.FindGameObjectWithTag("dialog"));

        var val = Random.Range(0, 10);
        if (val <= 3)
        {	// positivo
            Instantiate(dialogsGeladeira[2]);
            gameController.aumentaDisposicao(disposicao);
            print("disposicao = " + gameController.getDisposicao());

            gameController.aumentaSatisfacao(satisfacao);
            print("satisfacao = " + gameController.getSatisfacao());

            yield return new WaitForSeconds(6);
            Destroy(GameObject.FindGameObjectWithTag("dialog"));

            Instantiate(dialogsGeladeira[3]);

            yield return new WaitForSeconds(3);
            Destroy(GameObject.FindGameObjectWithTag("dialog"));

        }
        else
        {	// negativo
            Instantiate(dialogsGeladeira[4]);
            gameController.diminuiSatisfacao(satisfacao);
            print("satisfacao = " + gameController.getSatisfacao());

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
        // Dialogs
        actionText.text = "";

        Instantiate(dialogsGeladeira[0]);
        gameController.aumentaDisposicao(disposicao);
        print("disposicao = " + gameController.getDisposicao());

        gameController.aumentaSatisfacao(satisfacao);
        print("satisfacao = " + gameController.getSatisfacao());

        char_animator.SetBool("blocked", true);

        // playSound
        yield return new WaitForSeconds(3);
        geladeira[2].gameObject.renderer.enabled = false;
        actionText.text = "";
        char_animator.SetBool("blocked", false);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Char")
        {
            actionText_shadow.text = actionText.text = "";
            Destroy(GameObject.FindGameObjectWithTag("dialog"));
        }
    }
}
