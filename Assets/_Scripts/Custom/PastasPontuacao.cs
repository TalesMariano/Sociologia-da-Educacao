using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastasPontuacao : MonoBehaviour {

	File myFile;

	string scoreName;

	public enum Sociologos{
		Durkheim,
		Foucault,
		Boudieu,
		Weber
	}
	public Sociologos sociologos;

	void Start(){
		//if(myFile != null)
			myFile = GetComponent<File>();
	}



	public int GetScore(string tagName){
		int score = privateGetScore(tagName);
		return score;
	}

	[ContextMenu("Get Score")]
	public int GetScore(){
		int score = privateGetScore(scoreName);
		print (score);
		return score;
	}

	[ContextMenu("Get Score2")]
	public void GetScore2(){
		int score = privateGetScore(sociologos.ToString());

		if(sociologos == Sociologos.Weber){
			Global.notaWeber = score;
		}else if (sociologos == Sociologos.Boudieu){
			Global.notaBoudieu = score;
		}else if (sociologos == Sociologos.Foucault){
			Global.notaFoucault = score;
		}else if (sociologos == Sociologos.Durkheim){
			Global.notaDurkheim = score;
		}

		Debug.Log(sociologos.ToString() + " fez " + score + " pontos.");
		Global.nota += score;
		//return score;
	}



	int privateGetScore(string tagName){
		int score = 0;

		Transform[] allChildren = myFile.myWindow.dropZone.transform.GetComponentsInChildren<Transform>();
		foreach (Transform child in allChildren) {
			// do whatever with child transform here
			if(child.tag == tagName){
				score ++;
			}
		}
		return score;
	}

	
}
