using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Tales Package
[RequireComponent(typeof(Button))]
[ExecuteInEditMode]
public class ButtonNamer : MonoBehaviour {

	void Start () {
		ChangeButtonName();
	}

	void ChangeButtonName(){
		//print("Mudou Nome");
		gameObject.name = ("Button " + GetComponentInChildren<Text>().text);
	}
}
