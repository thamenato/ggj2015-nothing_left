using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Remote : MonoBehaviour {

    public string text;

    public Text actionText;
    public Text actionText_shadow;

    static public int takeRemote = 0;
    /*
     * 0 - remote on the table
     * 1 - can be picked
     * 2 - picked
     * 3 - ignored
    */

    void OnTriggerStay(Collider other)
    {
        if (other.name == "Char" && takeRemote == 1)
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
        if (other.name == "Char")
        {
            actionText_shadow.text = actionText.text = "";
        }
    }
}
