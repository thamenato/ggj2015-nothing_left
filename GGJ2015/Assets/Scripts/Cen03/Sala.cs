using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sala : MonoBehaviour {

	public Sprite[] avoSprite;
	public float satisfacao;
	public float disposicao;

	public GameObject[] dialogsPai;
	private bool blockSpace;
	
	public string Action_Text;
	Text canvas_actionText;
	Transform char_transform;
	Animator char_animator;
	static public int pegaControle = 0;  //0 controle no movel ; 1 controle pode ser pego;  2 controle pego; 3 controle ignorado;
	GameController gameController;
	
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
		var find_gameController = GameObject.Find ("GameController");
		if (find_gameController == null)
			print ("GameController not found");
		else
			gameController = find_gameController.GetComponent<GameController>();	
	}
	
	void OnTriggerStay(Collider other){

		switch(gameObject.name){
			case "Cen03_00_Fundo": //Saida da sala
				if (other.name == "Char"){
					canvas_actionText.text = "Go Outside";
					if(Input.GetKeyDown(KeyCode.Space))
						Application.LoadLevel("Cen05_Parque");
				}
				break;
			case "Cen03_01_Controle": //Saida da sala
		
				if (other.name == "Char" && pegaControle == 1 && !blockSpace){
					canvas_actionText.text = "Take the Remote Control";
					if(Input.GetKeyDown(KeyCode.Space)){
						pegaControle = 2;
						blockSpace = true;
						gameObject.renderer.enabled=false;
						gameObject.collider.enabled=false;
						canvas_actionText.text = "";
					}
				}
				break;
			case "Cen03_02a_Pai": //Saida da sala
				if (other.name == "Char" && pegaControle == 0 && !blockSpace){
					canvas_actionText.text = "Talk with Dad";
					if(Input.GetKeyDown(KeyCode.Space)){
						canvas_actionText.text = "";
						pegaControle = 1;
						blockSpace = true;
						StartCoroutine(DadReaction1());
						//gameObject.renderer.enabled=false;
					}
				}
				if (other.name == "Char" && pegaControle == 2){
					canvas_actionText.text = "Give Remote Control";
					if(Input.GetKeyDown(KeyCode.Space)){
						pegaControle = 3;
						canvas_actionText.text = "";

						//gameObject.renderer.enabled=false;
					}
				}
				break;
			case "Cen03_06_Ignore":
				if(other.name == "Char" && pegaControle == 1 && !blockSpace){
					StartCoroutine(DadReaction3());
					blockSpace = true;
				}
				break;
		}

	}
	

	
	void OnTriggerExit(Collider other){
		if (other.name == "Char"){
			canvas_actionText.text = "";
			blockSpace = false;
		}
	}

	IEnumerator DadReaction1(){ //pede controle

		char_animator.SetBool("blocked", true);
		Instantiate (dialogsPai[0]);

		yield return new WaitForSeconds(3); 

		Destroy(GameObject.FindGameObjectWithTag("dialog"));

		Instantiate (dialogsPai[1]);
		
		yield return new WaitForSeconds(5); 
		
		Destroy(GameObject.FindGameObjectWithTag("dialog"));


		char_animator.SetBool("blocked", false);
		canvas_actionText.text = "TAKE IT                    IGNORE";

	}

	IEnumerator DadReaction3(){ //jogador ignora o pedido
		
		char_animator.SetBool("blocked", true);
		Instantiate (dialogsPai[3]);
		
		yield return new WaitForSeconds(3); 
		
		Destroy(GameObject.FindGameObjectWithTag("dialog"));

		var val = Random.Range(0, 10);

		if(val > 4){ //negativo
			Instantiate (dialogsPai[4]);

			yield return new WaitForSeconds(3); 
		
			Destroy(GameObject.FindGameObjectWithTag("dialog"));
		}

		else { //positivo
			Instantiate (dialogsPai[5]);
			
			yield return new WaitForSeconds(3); 
			
			Destroy(GameObject.FindGameObjectWithTag("dialog"));
		}

		char_animator.SetBool("blocked", false);
		pegaControle = 3;
		
	}
}
