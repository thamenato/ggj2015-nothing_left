using UnityEngine;
using System.Collections;

public class DadIgnore : MonoBehaviour {
    
    // Satisfaction and disposition for this event
    public float satisfacao;
    public float disposicao;

    // Dialogs
    public GameObject[] dialogsPai;

    // Player animator
    public Animator playerAnimator;
    
    GameController gameController;

    void Start()
    {
        // finds the GameController
        var find_gameController = GameObject.Find("GameController");
        if (find_gameController == null)
            print("GameController not found");
        else
            gameController = find_gameController.GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Remote.takeRemote == 1)
            StartCoroutine(DadReaction3());
    }

    IEnumerator DadReaction3()
    {   
        // Player ignores Dad
        playerAnimator.SetBool("blocked", true);
        Instantiate(dialogsPai[0]);

        yield return new WaitForSeconds(3);

        Destroy(GameObject.FindGameObjectWithTag("dialog"));

        var val = Random.Range(0, 10);

        if (val > 4)
        {   //negative
            if (gameController != null) { 
                gameController.diminuiSatisfacao(satisfacao);
                print("satisfacao = " + gameController.getSatisfacao());
            } 
            Instantiate(dialogsPai[1]);

            yield return new WaitForSeconds(3);

            Destroy(GameObject.FindGameObjectWithTag("dialog"));
        }

        else
        {   //positive
            if (gameController != null){
                gameController.aumentaSatisfacao(satisfacao);
                print("satisfacao = " + gameController.getSatisfacao());
            }
            Instantiate(dialogsPai[2]);

            yield return new WaitForSeconds(3);

            Destroy(GameObject.FindGameObjectWithTag("dialog"));
        }

        playerAnimator.SetBool("blocked", false);
        Remote.takeRemote = 3;
    }
}
