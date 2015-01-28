using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
	
	GameObject mainMenu;
	GameObject creditsMenu;


	public void Start(){
		var start = GameObject.Find ("start_btn").GetComponent<Button>();
		var credits = GameObject.Find ("credits_btn").GetComponent<Button>();
		var back = GameObject.Find ("back_btn").GetComponent<Button>();

		start.onClick.AddListener(startGame);
		credits.onClick.AddListener(showCredits);
		back.onClick.AddListener(backMainMenu);

		mainMenu = GameObject.Find ("mainMenu");
		creditsMenu = GameObject.Find("creditsMenu");

		creditsMenu.SetActive(false);
	}
	
	public void startGame(){
		Application.LoadLevel("Cen01_Quarto");
	}

	public void showCredits(){
		mainMenu.SetActive(false);
		creditsMenu.SetActive(true);
	}
	public void backMainMenu(){
		creditsMenu.SetActive(false);
		mainMenu.SetActive(true);
	}

}
