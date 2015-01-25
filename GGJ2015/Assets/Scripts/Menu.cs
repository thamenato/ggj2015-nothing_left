using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	void Update () {
		if(Input.anyKeyDown){
			Application.LoadLevel("Cen01_Quarto");
		}
	}
}
