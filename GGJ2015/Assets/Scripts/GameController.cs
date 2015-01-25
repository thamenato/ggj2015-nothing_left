using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public float disposicao;
	public float satisfacao;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake(){
		DontDestroyOnLoad(this);
		//DontDestroyOnLoad(audio);
	}



}
