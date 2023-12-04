using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkGabarito : MonoBehaviour {

	public string link;

	public void OpenLink(){

		Application.OpenURL(link);

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
