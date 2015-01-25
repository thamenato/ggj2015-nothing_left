using UnityEngine;
using System.Collections;

public class Cen01_script : MonoBehaviour {
	
	GameController gameController;

	// Use this for initialization
	void Start () {
		var find_gameController = GameObject.Find ("GameController");
		if (find_gameController == null)
			print ("GameController not found");
		else
			gameController = find_gameController.GetComponent<GameController>();	
	
		gameController.showBarraDisposicao();
	}

}
