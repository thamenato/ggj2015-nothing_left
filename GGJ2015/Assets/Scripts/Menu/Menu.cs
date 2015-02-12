using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
	
	public GameObject mainMenu;
	public GameObject creditsMenu;

    public Button start;
    public Button credits;
    public Button back;
    public Button soundtrack;

	public void Start(){

		start.onClick.AddListener(startGame);
		credits.onClick.AddListener(showCredits);
		back.onClick.AddListener(backMainMenu);
        soundtrack.onClick.AddListener(soundtrackButton);
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

    public void soundtrackButton()
    {
        Application.ExternalEval("window.open('http://freemusicarchive.org/music/Kai_Engel/','_blank')");
    }

}
