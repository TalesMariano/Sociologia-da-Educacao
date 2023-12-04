using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLoader : MonoBehaviour {

	int numFinalBom = 2;
	int numFinalMedio = 3;
	int numFinalRuim = 4;

	float bomFinal = 0.8f;
	float medioFinal = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadFinal(){
		float notaPct = (float)Global.nota/(float)Global.totalFiles;

		if(notaPct>bomFinal ){
			Debug.Log("Carregou Final Bom");
			MyLoadScene(numFinalBom);
		}else if (notaPct>medioFinal){
			Debug.Log("Carregou Final Medio");
			MyLoadScene(numFinalMedio);
		}else{
			Debug.Log("Carregou Final Ruim");
			MyLoadScene(numFinalRuim);
		}


	}

	void Broadcast(){
		BroadcastMessage("WindowParent");
	}


	public void MyLoadScene(int numLoadScene){
		SceneManager.LoadScene(numLoadScene);
	}
}
