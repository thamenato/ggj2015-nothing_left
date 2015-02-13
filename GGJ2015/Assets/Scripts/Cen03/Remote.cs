using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Remote : MonoBehaviour {

    // Text for action text of this event
    string text;

    // Action Text
    public Text actionText;
    public Text actionText_shadow;
    
    /* Take Remote
     * 0 - remote on the table
     * 1 - can be picked
     * 2 - picked
     * 3 - ignored
    */
    static public int takeRemote = 0;

    void Start()
    {
        text = Events.eventsTextAction[name];
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && takeRemote == 1)
        {
            actionText_shadow.text = actionText.text = text;
            
            if (Input.GetKey(KeyCode.Space))
            {
                takeRemote = 2;
                renderer.enabled = false;
                collider.enabled = false;
                actionText_shadow.text = actionText.text = "";
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            actionText_shadow.text = actionText.text = "";
    }
}
