using UnityEngine;
using System.Collections;

public class Cen01_script : MonoBehaviour {
	
	GameController gameController;
	Animator animator;

	// Use this for initialization
	void Start () {
		var find_gameController = GameObject.Find ("GameController");
		if (find_gameController == null)
			print ("GameController not found");
		else{
			gameController = find_gameController.GetComponent<GameController>();
		}

		var find_charAnimator = GameObject.Find ("Char");
		if(find_charAnimator == null)
			print ("Char not found");
		else
			animator = find_charAnimator.GetComponent<Animator>();

		gameController.showBarraDisposicao();
		animator.SetBool("blocked", true);
		animator.Play("Deitado");
		gameController.changeBgMusic(1);

	}

}
