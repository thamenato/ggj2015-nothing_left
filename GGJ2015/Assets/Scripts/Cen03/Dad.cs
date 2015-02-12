using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dad : MonoBehaviour {

    // Satisfaction and disposition for this event
    public float satisfacao;
    public float disposicao;

    // Text for action text of this event
    public string[] text;

    // Action Text
    public Text actionText;
    public Text actionText_shadow;

    // Dialogs
    public GameObject[] dialogsPai;

    // Player animator
    public Animator playerAnimator;

    GameController gameController;

	// Use this for initialization
	void Start () {
        // finds the GameController
        var find_gameController = GameObject.Find("GameController");
        if (find_gameController == null)
            print("GameController not found");
        else
            gameController = find_gameController.GetComponent<GameController>();
    }

    IEnumerator DadReaction1()
    {   
        //ask for remote
        Remote.takeRemote = 1;  // can be picked

        playerAnimator.SetBool("blocked", true);
        Instantiate(dialogsPai[0]);

        yield return new WaitForSeconds(3);

        Destroy(GameObject.FindGameObjectWithTag("dialog"));

        Instantiate(dialogsPai[1]);

        yield return new WaitForSeconds(5);

        Destroy(GameObject.FindGameObjectWithTag("dialog"));

        playerAnimator.SetBool("blocked", false);
        actionText_shadow.text = actionText.text = "TAKE IT                    IGNORE";
    }

    IEnumerator DadReaction2()
    { 
        //gives remote
        playerAnimator.SetBool("blocked", true);

        if (gameController != null) { 
            gameController.diminuiDisposicao(disposicao);
            print("disposicao = " + gameController.getDisposicao());
            gameController.aumentaSatisfacao(satisfacao);
            print("satisfacao = " + gameController.getSatisfacao());
        }

        Instantiate(dialogsPai[2]);

        yield return new WaitForSeconds(3);

        Destroy(GameObject.FindGameObjectWithTag("dialog"));

        playerAnimator.SetBool("blocked", false);
    }


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Remote.takeRemote == 0) // remote on the table
            {
                actionText_shadow.text = actionText.text = text[0];
                
                if (Input.GetKey(KeyCode.Space))
                {
                    actionText_shadow.text = actionText.text = "";
                    StartCoroutine(DadReaction1());
                    //gameObject.renderer.enabled=false;
                }
            }
            if (Remote.takeRemote == 2) // remote picked
            {
                actionText_shadow.text = actionText.text = text[1]; 
                if (Input.GetKey(KeyCode.Space))
                {
                    Remote.takeRemote = 3;  // remote ignored
                    actionText_shadow.text = actionText.text = ""; 
                    StartCoroutine(DadReaction2());
                    //gameObject.renderer.enabled=false;
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            actionText_shadow.text = actionText.text = "";
    }
}
