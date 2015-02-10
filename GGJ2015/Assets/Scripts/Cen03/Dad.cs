using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dad : MonoBehaviour {
    
    public float satisfacao;
    public float disposicao;
    public string[] text;

    public GameObject[] dialogsPai;

    public Text actionText;
    public Text actionText_shadow;

    public Animator char_animator;

    GameController gameController;

	// Use this for initialization
	void Start () {
        var find_gameController = GameObject.Find("GameController");
        if (find_gameController == null)
            print("GameController not found");
        else
            gameController = find_gameController.GetComponent<GameController>();
    }

    IEnumerator DadReaction1()
    { //pede controle

        Remote.takeRemote = 1;

        char_animator.SetBool("blocked", true);
        Instantiate(dialogsPai[0]);

        yield return new WaitForSeconds(3);

        Destroy(GameObject.FindGameObjectWithTag("dialog"));

        Instantiate(dialogsPai[1]);

        yield return new WaitForSeconds(5);

        Destroy(GameObject.FindGameObjectWithTag("dialog"));


        char_animator.SetBool("blocked", false);
        actionText_shadow.text = actionText.text = "TAKE IT                    IGNORE";

    }

    IEnumerator DadReaction2()
    { //entrega controle

        char_animator.SetBool("blocked", true);

        if (gameController != null) { 
            gameController.diminuiDisposicao(disposicao);
            print("disposicao = " + gameController.getDisposicao());
            gameController.aumentaSatisfacao(satisfacao);
            print("satisfacao = " + gameController.getSatisfacao());
        }
        Instantiate(dialogsPai[2]);

        yield return new WaitForSeconds(3);

        Destroy(GameObject.FindGameObjectWithTag("dialog"));

        char_animator.SetBool("blocked", false);

    }


    void OnTriggerStay(Collider other)
    {
        if (other.name == "Char")
        {
            if (Remote.takeRemote == 0)
            {
                actionText_shadow.text = actionText.text = text[0];
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    actionText_shadow.text = actionText.text = "";
                    StartCoroutine(DadReaction1());
                    //gameObject.renderer.enabled=false;
                }
            }
            if (Remote.takeRemote == 2)
            {
                actionText_shadow.text = actionText.text = text[1]; 
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Remote.takeRemote = 3;
                    actionText_shadow.text = actionText.text = ""; 
                    StartCoroutine(DadReaction2());
                    //gameObject.renderer.enabled=false;
                }
            }
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
