using UnityEngine;
using System.Collections;

public class Blender : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other)
    {
        if (other.name == "Char")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                audio.pitch = Random.Range(0.8f, 1.2f);
                audio.Play();
            }
        }
    }

    
}
