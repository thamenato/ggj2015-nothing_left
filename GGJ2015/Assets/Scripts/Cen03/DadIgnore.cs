using UnityEngine;
using System.Collections;

public class DadIgnore : MonoBehaviour {
    
    public float satisfacao;
    public float disposicao;

    public GameObject[] dialogsPai;

    public Animator char_animator;
    
    GameController gameController;

    void Start()
    {
        var find_gameController = GameObject.Find("GameController");
        if (find_gameController == null)
            print("GameController not found");
        else
            gameController = find_gameController.GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Char" && Remote.takeRemote == 1)
            StartCoroutine(DadReaction3());
    }

    IEnumerator DadReaction3()
    { //jogador ignora o pedido

        char_animator.SetBool("blocked", true);
        Instantiate(dialogsPai[0]);

        yield return new WaitForSeconds(3);

        Destroy(GameObject.FindGameObjectWithTag("dialog"));

        var val = Random.Range(0, 10);

        if (val > 4)
        { //negativo
            if (gameController != null) { 
                gameController.diminuiSatisfacao(satisfacao);
                print("satisfacao = " + gameController.getSatisfacao());
            } 
            Instantiate(dialogsPai[1]);

            yield return new WaitForSeconds(3);

            Destroy(GameObject.FindGameObjectWithTag("dialog"));
        }

        else
        { //positivo
            if (gameController != null){
                gameController.aumentaSatisfacao(satisfacao);
                print("satisfacao = " + gameController.getSatisfacao());
            }
            Instantiate(dialogsPai[2]);

            yield return new WaitForSeconds(3);

            Destroy(GameObject.FindGameObjectWithTag("dialog"));
        }

        char_animator.SetBool("blocked", false);
        Remote.takeRemote = 3;

    }
}
