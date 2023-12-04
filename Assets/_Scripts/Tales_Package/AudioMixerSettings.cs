using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// Tales Package =9 v0.2 %D 
public class AudioMixerSettings : MonoBehaviour {

	public AudioMixer audioMixer;
	
	public void VolumeChanger(string parameterName, float volume){
		audioMixer.SetFloat(parameterName,volume);
	}

	public void VolumeMaster(float volume){
		audioMixer.SetFloat("MasterVolume",volume);
	}

	public void VolumeMusic(float volume){
		audioMixer.SetFloat("MusicVolume",volume);
	}

	public void VolumeSFX(float volume){
		audioMixer.SetFloat("SfxVolume",volume);
	}

	public void VolumeAudioDescr(float volume){
		audioMixer.SetFloat("AudioDescrVolume",volume);
	}
}
