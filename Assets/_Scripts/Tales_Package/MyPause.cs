using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPause : MonoBehaviour {

	public bool isPaused = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		


	}

	public void Pause(){
		Time.timeScale = 0;
	}

	public void UnPause(){
		Time.timeScale = 1;
	}

	public void BoolPause(bool b){
		if(b)
			Pause();
		else
			UnPause();
	}
}
