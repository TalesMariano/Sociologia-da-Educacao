using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartEvents : MonoBehaviour {
	public UnityEvent awakeEvents;

	public UnityEvent startEvents;

	void Awake()
	{
		awakeEvents.Invoke();
	}

	void Start () {
		startEvents.Invoke();
	}

}
