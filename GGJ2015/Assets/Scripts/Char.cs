using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Char : MonoBehaviour {
	public GameObject CameraFollow;
	public float charSpeed=5f;
    public Text capeta;

	protected Animator animator;
	private string animationName;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		CameraFollow.transform.position = new Vector3(transform.position.x,CameraFollow.transform.position.y, CameraFollow.transform.position.z);

		animator.SetBool("Walking", false );

		if (!animator.GetBool("blocked")){
	
			if(Input.GetKey(KeyCode.LeftArrow) 
		   			&& transform.position.x>=-7 )
			{
				transform.localScale = new Vector3(1, 1, 1);
				transform.position = new Vector3(transform.position.x-(charSpeed*Time.deltaTime),transform.position.y,transform.position.z);
				animator.SetBool("Walking", true );
			}
			if(Input.GetKey(KeyCode.RightArrow) 
		   			&& transform.position.x<=7)
			{
				transform.localScale = new Vector3(-1, 1, 1);
				transform.position = new Vector3(transform.position.x+(charSpeed*Time.deltaTime),transform.position.y,transform.position.z);
				animator.SetBool("Walking", true );
			}
		}

		if(Input.GetKey(KeyCode.Space)){						
		
		}
	}

	void OnTriggerEnter(Collider other) 
    {
		/*switch(other.name){
		
		case "Collider_Geladeira":
			capeta.text = "Open Fridge";
			break;
		case "Collider_Saida":
			capeta.text = "Go to the Living Room";
			break;

		case "Collider_Pai":
			capeta.text = "Talk to Dad";
			break;
		case "Cen3_00_Fundo":
			capeta.text = "Leave home";
			break;
		case "Cen3_01_Controle":
			capeta.text = "Take the remote control";
			break;


		}*/
    }

    void OnTriggerExit(Collider other)
    {
		//capeta.text = "";
        /*switch (other.name)
        {
            case "Collider_Armario":
                capeta.text = "";
                break;
			case "Collider_Pai":
				capeta.text = "";
				break;
			case "Cen3_00_Fundo":
				capeta.text = "";
				break;
			case "Cen3_01_Controle":
				capeta.text = "";
				break;
        }*/
	
    }

	void blockWalk(){
		animator.SetBool("blocked", true);
	}
	void releaseWalk(){
		animator.SetBool("blocked", false);
	}

}
