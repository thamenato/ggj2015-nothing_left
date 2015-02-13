using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Events : MonoBehaviour {

    public static Dictionary<string, string> eventsTextAction;

    public GameObject _actionsText;

    void Awake()
    {
        if (!GameObject.FindObjectOfType<ActionsData>())
        {
            Instantiate(_actionsText);
        }

        refreshEvents();
    }

    public static void refreshEvents()
    {
        if(eventsTextAction != null)
            eventsTextAction.Clear();
        eventsTextAction = ActionsData.getSceneEventsActionText(Application.loadedLevelName);
        if (eventsTextAction != null)
            Debug.Log("ActionText Events: " + eventsTextAction.Keys.Count + " loaded");
    }

}
