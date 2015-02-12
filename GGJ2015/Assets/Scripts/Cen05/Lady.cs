using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Lady : MonoBehaviour {

    // Satisfaction and disposition for this event
    public float satisfacao;
    public float disposicao;

    public string text;

    // Action Text
    public Text actionText;
    public Text actionText_shadow;

    public float walksAwaySpeed = 1f;
    // player
    public GameObject player;

    Transform playerTransform;
    Animator playerAnimator;

    GameController gameController;
    bool walksAway = false;

    // Use this for initialization
    void Start()
    {
        // finds the GameController
        var find_gameController = GameObject.Find("GameController");
        if (find_gameController == null)
            print("GameController not found");
        else
            gameController = find_gameController.GetComponent<GameController>();

        playerTransform = player.GetComponent<Transform>();
        playerAnimator = player.GetComponent<Animator>();
    }

    void Update()
    {
        if (walksAway)
            transform.position = Vector3.Lerp(transform.position, new Vector3(10, transform.position.y, transform.position.z), walksAwaySpeed * Time.deltaTime);
        
        // outside scene boundaries
        if (transform.position.x > 8)
        {
            playerAnimator.SetBool("blocked", false);
            Destroy(gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            actionText.text = actionText_shadow.text = text;

            if (Input.GetKey(KeyCode.Space))
            {
                // she runs away from him
                GetComponent<Animator>().Play("WalkingMoca");
                walksAway = true;
                playerAnimator.SetBool("blocked", true);
                GetComponent<BoxCollider>().enabled = false;
                actionText.text = actionText_shadow.text = "";
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            actionText.text = actionText_shadow.text = "";
    }
}
