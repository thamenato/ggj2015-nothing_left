using UnityEngine;
using System.Collections;

public class Char : MonoBehaviour {
	
	float charSpeed=5f;

	protected Animator animator;
	// Use this for initialization
	void Start () {
		animator=GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetBool("Walking", false );

			if(Input.GetKey(KeyCode.LeftArrow) && transform.position.x>=-7){
			transform.localScale = new Vector3(1, 1, 1);
				transform.position = new Vector3(transform.position.x-(charSpeed*Time.deltaTime),0,0);
				animator.SetBool("Walking", true );
			}
			if(Input.GetKey(KeyCode.RightArrow) && transform.position.x<=7){
				transform.localScale = new Vector3(-1, 1, 1);
				transform.position = new Vector3(transform.position.x+(charSpeed*Time.deltaTime),0,0);
				animator.SetBool("Walking", true );
			}

			if(Input.GetKey(KeyCode.Space)){						
		}
	}

	void OnTriggerEnter(Collider other) {
		switch(other.name){
		case "Collider_Armario":
			break;
		}



	}
}
