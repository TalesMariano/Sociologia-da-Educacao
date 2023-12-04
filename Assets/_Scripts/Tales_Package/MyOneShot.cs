using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyOneShot : MonoBehaviour {

	AudioSource asource;
	public float pitchVariation = 0.1f;

	void Start () {
		asource = GetComponent<AudioSource>();
	}
	
	public void OneShot(AudioClip audioClip){
		asource.pitch = Random.Range(1-pitchVariation, 1+pitchVariation);
		asource.PlayOneShot(audioClip);

	}
}
