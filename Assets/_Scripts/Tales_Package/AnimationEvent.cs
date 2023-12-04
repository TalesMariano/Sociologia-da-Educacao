using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


// Tales Package %D
public class AnimationEvent : MonoBehaviour {

	public UnityEvent myEvent;

	public void CallEvent(){
		myEvent.Invoke();
	}

}
