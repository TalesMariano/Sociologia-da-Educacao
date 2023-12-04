using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {

	public static int nota = 0;
	public static int totalFiles = 15;

	public static int notaDurkheim = 0;
	public static int notaFoucault = 0;
	public static int notaBoudieu = 0;
	public static int notaWeber = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Reset(){
		nota = 0;
		notaBoudieu = 0;
		notaDurkheim = 0;
		notaWeber = 0;
		notaFoucault = 0;
	}
}
