using UnityEngine;
using System.Collections;

public class Cen01_script : MonoBehaviour {
	
	public GameObject player;

    GameController gameController;
    Animator animator;

	// Use this for initialization
	void Start () {
		var find_gameController = GameObject.Find ("GameController");
		if (find_gameController == null)
			print ("GameController not found");
		else{
			gameController = find_gameController.GetComponent<GameController>();
            gameController.showBarraDisposicao();
            gameController.changeBgMusic(1);
		}

        animator = player.GetComponent<Animator>();

        // if it's the beggining of the day increments it and animate him waking up
        if (GameController.startDay) { 
            GameController.startDay = false;
            animator.SetBool("blocked", true);
            animator.Play("Deitado");
            GameController.day++;
        }

		
	}

}
