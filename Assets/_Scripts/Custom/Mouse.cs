using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {

	CanvasAnchor canvasAnchor;
	public AudioSource audioSource;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		canvasAnchor =  GetComponent<CanvasAnchor>();
	}
	
	// Update is called once per frame
	void Update () {
		 transform.position = Input.mousePosition;  //Camera.main.ScreenToWorldPoint(Input.mousePosition);
		 //transform.position = new Vector3(transform.position.x,transform.position.y, 0);
		 if(canvasAnchor.enabled == true)
		 	canvasAnchor.BringBack();

		if(Input.GetMouseButtonDown(0)){
			audioSource.Play();
		}
	}
}
