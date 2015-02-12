using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public float disposicao = 1f;
	public float satisfacao = 0f;
    public float dropOfDisposition = 0.1f;

	public AudioClip[] bgMusic;

    public static int maxDays;
    public static bool startDay = true;
    public static int day = 0;
    public static bool started = false;

	// Use this for initialization
	void Start () {
		audio.clip = bgMusic[0];
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if(started)
            diminuiDisposicao(dropOfDisposition * Time.deltaTime);
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
        if (satisfacao < 0)
            satisfacao = 0;
	}

	public void diminuiDisposicao(float val){
        disposicao -= val;
        if (disposicao < 0)
            disposicao = 0;
    }

	public void aumentaSatisfacao(float val){
        satisfacao += val;
        if (satisfacao > 100)
            satisfacao = 100;
    }
	
	public void aumentaDisposicao(float val){
        disposicao += val;
        if (disposicao > 100)
            disposicao = 100;
	}

	public float getSatisfacao(){
		return satisfacao;
	}

	public float getDisposicao(){
		return disposicao;
	}

}
