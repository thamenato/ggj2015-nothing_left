using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public float disposicao = 1f;
	public float satisfacao = 0f;

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

	public void diminuiSatisfacao(float val){
		this.satisfacao -= val;
	}

	public void diminuiDisposicao(float val){
		this.disposicao -= val;
	}

	public void aumentaSatisfacao(float val){
		this.satisfacao += val;
	}
	
	public void aumentaDisposicao(float val){
		this.disposicao += val;
	}

	public float getSatisfacao(){
		return this.satisfacao;
	}

	public float getDisposicao(){
		return this.disposicao;
	}

}
