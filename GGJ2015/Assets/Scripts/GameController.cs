using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public float disposicao = 1f;
	public float satisfacao = 0f;

	public GameObject barraDisposicao;

	public AudioClip[] bgMusic;

	// Use this for initialization
	void Start () {
		audio.clip = bgMusic[0];
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake(){
		DontDestroyOnLoad(this);
	}

	public void changeBgMusic(int index){
		audio.clip = bgMusic[index];
		audio.Play();
	}

	public void diminuiSatisfacao(float val){
		satisfacao -= val;
	}

	public void diminuiDisposicao(float val){
		disposicao -= val;
	}

	public void aumentaSatisfacao(float val){
		satisfacao += val;
	}
	
	public void aumentaDisposicao(float val){
		disposicao += val;
	}

	public float getSatisfacao(){
		return satisfacao;
	}

	public float getDisposicao(){
		return disposicao;
	}

	public void showBarraDisposicao(){
		DontDestroyOnLoad(Instantiate(barraDisposicao, barraDisposicao.transform.position, Quaternion.identity));		                 
	}

}
