using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Char : MonoBehaviour {
	public GameObject CameraFollow;
	public float charSpeed=5f;

	protected Animator animator;
	private string animationName;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

		animator.SetBool("Walking", false );

		if (!animator.GetBool("blocked")){

            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && transform.position.x>=-7 )
			{
				transform.localScale = new Vector3(1, 1, 1);
                transform.position = new Vector3(transform.position.x-(charSpeed*Time.deltaTime),transform.position.y,transform.position.z);
                animator.SetBool("Walking", true );
			}
			if((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && transform.position.x<=7)
			{
				transform.localScale = new Vector3(-1, 1, 1);
				transform.position = new Vector3(transform.position.x+(charSpeed*Time.deltaTime),transform.position.y,transform.position.z);
				animator.SetBool("Walking", true );
			}
		}

	}

	void blockWalk(){
		animator.SetBool("blocked", true);
	}
	void releaseWalk(){
		animator.SetBool("blocked", false);
	}

}
