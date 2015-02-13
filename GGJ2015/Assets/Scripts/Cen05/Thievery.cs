using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Thievery : MonoBehaviour {

    // Satisfaction and disposition for this event
    public float satisfacao;
    public float disposicao;

    string text;

    // Action Text
    public Text actionText;
    public Text actionText_shadow;

    // player
    public GameObject player;

    Transform playerTransform;
    Animator playerAnimator;

    GameController gameController;
    
    // Use this for initialization
    void Start()
    {
        text = Events.eventsTextAction[name];
        // finds the GameController
        var find_gameController = GameObject.Find("GameController");
        if (find_gameController == null)
            print("GameController not found");
        else
            gameController = find_gameController.GetComponent<GameController>();

        playerTransform = player.GetComponent<Transform>();
        playerAnimator = player.GetComponent<Animator>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            actionText.text = actionText_shadow.text = text;

            if (Input.GetKey(KeyCode.Space))
            {
                // has to implement
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            actionText.text = actionText_shadow.text = "";
    }
}
