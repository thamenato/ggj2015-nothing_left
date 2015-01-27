using UnityEngine;
using System.Collections;

public class PowerBar : MonoBehaviour {

	public GameObject barra;
	//public float disposicao;
	private GameObject camera;
	public float reducao;
	private GameController gameController;

	//bool working = false;

	// Use this for initialization
	void Start () {
		var findGC = GameObject.Find("GameController");

		if(findGC == null)
			print ("game controller not found");
		else
			gameController = findGC.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		camera = GameObject.FindWithTag("MainCamera");

		transform.position = new Vector3(camera.transform.position.x + 2, transform.position.y, transform.position.z);

		if(gameController.getDisposicao() >= 0)
			barra.transform.localScale = new Vector3(gameController.getDisposicao(), 1, 1);

		//gameController.diminuiDisposicao(Time.deltaTime * reducao);

	}
}
