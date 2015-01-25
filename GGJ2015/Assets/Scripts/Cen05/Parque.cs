using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Parque : MonoBehaviour {
	
	
	public GameObject[] Churros;
	
	public string Action_Text;
	Text canvas_actionText;
	Transform char_transform;
	Animator char_animator;
	bool activated = false;
	Animator animator;

	bool LadyWalksAway=false;
	public GameObject Lady;

	// Use this for initialization
	void Start () {
		// Seeks for 'actionText' inside Canvas and returns it to local variable actionText
		var find_actionText = GameObject.Find("actionText");
		if (find_actionText == null)
			print ("actionText not found");
		else
			canvas_actionText = find_actionText.GetComponent<Text>();
		
		var find_Char = GameObject.Find ("Char");
		if (find_Char == null)
			print ("Char not found");
		else {
			char_transform = find_Char.GetComponent<Transform>();
			char_animator = find_Char.GetComponent<Animator>();
		}
	}
	
	void OnTriggerStay(Collider other){
		if(gameObject.name=="Collider_Churros")
			// if Scale x < 0 the Char is facing to the right and Gato never used before
			if (other.name == "Char"  && char_transform.localScale.x < 0 && activated == false){
				canvas_actionText.text = "Talk to Churros Seller";
				if(Input.GetKeyDown(KeyCode.Space)){
					activated = true;
					StartCoroutine(TrocaSprite());
				}
			}
		if(gameObject.name=="Collider_Saida")
			if (other.name == "Char"){
				canvas_actionText.text = "Go back home";
				if(Input.GetKeyDown(KeyCode.Space))
					Application.LoadLevel("Cen01_Quarto");
			}
		if(gameObject.name=="Collider_Assalto")
			if (other.name == "Char"){
				canvas_actionText.text = "Help Old Woman";
				if(Input.GetKeyDown(KeyCode.Space))
				{}
			}
		if(gameObject.name=="Collider_Moca")
			if (other.name == "Char" && !LadyWalksAway){
				canvas_actionText.text = "Talk to Pretty Woman";
				if(Input.GetKeyDown(KeyCode.Space)){
					canvas_actionText.text = "She Left Me =/";
					animator = GameObject.Find("Moca").GetComponent<Animator>();
					animator.Play("WalkingMoca");
					LadyWalksAway=true;
					char_animator.SetBool("blocked", true);

				}
			}
		
	}

	void Update(){
		if(gameObject.name=="Collider_Moca"){
			if(LadyWalksAway){
				Lady.transform.position = Vector3.Lerp(Lady.transform.position, new Vector3(10,Lady.transform.position.y, Lady.transform.position.z), 1f*Time.deltaTime);
			}

			if(Lady.transform.position.x>7){
				char_animator.SetBool("blocked", false);
				Lady.gameObject.renderer.enabled=false;
			}
		}

	}


	IEnumerator TrocaSprite(){
		Churros[0].gameObject.renderer.enabled=false;
		Churros[1].gameObject.renderer.enabled=true;
		canvas_actionText.text="No churros for me =(";
		char_animator.SetBool("blocked", true);
		
		//playSound
		yield return new WaitForSeconds(2);
		Churros[0].gameObject.renderer.enabled=true;
		Churros[1].gameObject.renderer.enabled=false;
		canvas_actionText.text="";
		char_animator.SetBool("blocked", false);
		activated = false;
		
	}
	
	void OnTriggerExit(Collider other){
		if (other.name == "Char"){
			canvas_actionText.text = "";
		}
	}
}
