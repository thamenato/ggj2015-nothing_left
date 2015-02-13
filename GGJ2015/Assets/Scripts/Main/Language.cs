using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour {

    public Sprite[] flag_PtBR = new Sprite[2];
    public Sprite[] flag_US = new Sprite[2];

    public Button btnPtBR;
    public Button btnUS;

    public Text[] menuButtons = new Text[3];

    void Awake()
    {
        btnPtBR.image.sprite = flag_PtBR[0];
        btnUS.image.sprite = flag_US[1];
        btnPtBR.onClick.AddListener(languagePtBr);
        btnUS.onClick.AddListener(languageUS);

    }

    void Start()
    {
        changeMenuLanguage();
    }

    private void languagePtBr()
    {
        if (btnPtBR.image.sprite.name == "bra_flag_1")
            Debug.Log("Language already PtBR");
        else
        {
            if (ActionsData.changeLanguage("ptBR"))
            {
                Debug.Log("Language changed to: PtBR");
                btnPtBR.image.sprite = flag_PtBR[1];
                btnUS.image.sprite = flag_US[0];
                Events.refreshEvents();
                changeMenuLanguage();
            }
        }
    }

    private void languageUS()
    {
        if (btnUS.image.sprite.name == "usa_flag_1")
            Debug.Log("Language already US");
        else
        {
            if (ActionsData.changeLanguage("US")) 
            {
                Debug.Log("Language changed to: US");
                btnPtBR.image.sprite = flag_PtBR[0];
                btnUS.image.sprite = flag_US[1];
                Events.refreshEvents();
                changeMenuLanguage();
            }
        }
    }

    void changeMenuLanguage()
    {
        for (int i = 0; i < menuButtons.Length; i++)
            menuButtons[i].text = Events.eventsTextAction[menuButtons[i].name];
    }
}
