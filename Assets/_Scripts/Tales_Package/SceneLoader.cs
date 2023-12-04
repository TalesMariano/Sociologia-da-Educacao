using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MyLoadScene(int numLoadScene){
		SceneManager.LoadScene(numLoadScene);
	}

	public void MyLoadScene(string nameLoadScene){
		SceneManager.LoadScene(nameLoadScene);
	}

	public void ReloadScene(){
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}

}
