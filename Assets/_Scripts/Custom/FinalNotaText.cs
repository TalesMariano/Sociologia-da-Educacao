using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalNotaText : MonoBehaviour {

	public enum Sociologos{
		Durkheim,
		Foucault,
		Boudieu,
		Weber
	}
	public Sociologos sociologos;

	public bool endScreen = false;
	public Text eitaText;

	void Start () {
		DoNota();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DoNota(){
		if(sociologos == Sociologos.Weber){
			eitaText.text = (Global.notaWeber + "/4");
		}else if (sociologos == Sociologos.Boudieu){
			eitaText.text = (Global.notaBoudieu + "/4");
		}else if (sociologos == Sociologos.Foucault){
			eitaText.text = (Global.notaFoucault + "/3");
		}else if (sociologos == Sociologos.Durkheim){
			eitaText.text = (Global.notaDurkheim + "/4");
		}

	}
}
