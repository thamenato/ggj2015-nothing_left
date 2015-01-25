using UnityEngine;
using System.Collections;

public class PowerBar : MonoBehaviour {

	public GameObject barra;
	public float disposicao;
	private GameObject camera;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		camera = GameObject.FindWithTag("MainCamera");

		transform.position = new Vector3(camera.transform.position.x + 2, transform.position.y, transform.position.z);

		if(disposicao >= 0)
			barra.transform.localScale = new Vector3(disposicao, 1, 1);

		disposicao -= Time.deltaTime * 0.01f;

	}
}
