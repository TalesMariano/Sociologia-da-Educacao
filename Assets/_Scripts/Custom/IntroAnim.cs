using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntroAnim : MonoBehaviour {

	int numEvent = 0;

	public UnityEvent[] events;

	public UnityEvent finalEvent;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Submit")||Input.GetMouseButtonDown(0)){
			if(events.Length >numEvent){
				events[numEvent].Invoke();
				numEvent ++;
			}else{
				finalEvent.Invoke();
			}
		}
	}

	public void Final(){
		finalEvent.Invoke();
	}
}
