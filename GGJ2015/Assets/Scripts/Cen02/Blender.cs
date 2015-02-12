using UnityEngine;
using System.Collections;

public class Blender : MonoBehaviour {
    
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                audio.pitch = Random.Range(0.8f, 1.2f);
                audio.Play();
            }
        }
    }

    
}
