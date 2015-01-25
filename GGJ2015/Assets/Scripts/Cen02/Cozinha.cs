using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cozinha : MonoBehaviour {


	public GameObject[] Geladeira;
	public GameObject[] dialogsGeladeira;

	public string Action_Text;
	Text canvas_actionText;
	Transform char_transform;
	Animator char_animator;
	bool activated = false;

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
		if(gameObject.name=="Collider_Geladeira")
			// if Scale x < 0 the Char is facing to the right and Gato never used before
			if (other.name == "Char" && activated == false){
				canvas_actionText.text = "Open Fridge";
				if(Input.GetKeyDown(KeyCode.Space)){
					activated = true;
					var val = Random.Range(0, 10);
					if(val <= 5)
						StartCoroutine(noFood());
					else
						StartCoroutine(withFood());
				}
			}
		if(gameObject.name=="Collider_Saida")
			if (other.name == "Char"){
				canvas_actionText.text = "Go to the Living Room";
				if(Input.GetKeyDown(KeyCode.Space))
					Application.LoadLevel("Cen03_Sala");
			}

	}


	IEnumerator noFood(){
		Geladeira[1].gameObject.renderer.enabled=true;
		// Dialogs
		canvas_actionText.text="";

		Instantiate(dialogsGeladeira[1]);
		
		char_animator.SetBool("blocked", true);
		
		//playSound
		yield return new WaitForSeconds(4);

		Destroy(GameObject.FindGameObjectWithTag("dialog"));

		var val = Random.Range(0, 10);
		if(val <= 3){	// positivo
			Instantiate(dialogsGeladeira[2]);

			yield return new WaitForSeconds(6);
			Destroy(GameObject.FindGameObjectWithTag("dialog"));

			Instantiate(dialogsGeladeira[3]);
		
			yield return new WaitForSeconds(3);
			Destroy(GameObject.FindGameObjectWithTag("dialog"));

		}
		else{	// negativo
			Instantiate(dialogsGeladeira[4]);
			yield return new WaitForSeconds(6);

			Destroy(GameObject.FindGameObjectWithTag("dialog"));

		}

		Geladeira[1].gameObject.renderer.enabled=false;
		canvas_actionText.text="";
		char_animator.SetBool("blocked", false);

	}



	IEnumerator withFood(){
		Geladeira[2].gameObject.renderer.enabled=true;
		// Dialogs
		canvas_actionText.text = "";

		Instantiate(dialogsGeladeira[0]);

		char_animator.SetBool("blocked", true);

		// playSound
		yield return new WaitForSeconds(3);
		Geladeira[2].gameObject.renderer.enabled=false;
		canvas_actionText.text="";
		char_animator.SetBool("blocked", false);
	}
	
	void OnTriggerExit(Collider other){
		if (other.name == "Char"){
			canvas_actionText.text = "";
			Destroy(GameObject.FindGameObjectWithTag("dialog"));
		}
	}
}
