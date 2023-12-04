using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasAnchor : MonoBehaviour {

	public bool isActive = true;

	RectTransform canvasRect;
	
	RectTransform myRect;

	 float rctHeigt;
	 float rctWidth;
	 float height;
	 float width;


	Vector3[] corners = new Vector3[4];


	// Use this for initialization

	[ContextMenu("Do Start")]
	void Start () {
		
		canvasRect = GetComponentInParent<Marker>().GetComponent<RectTransform>();// GetComponentInParent<Canvas>().GetComponent<RectTransform>();

		myRect = GetComponent<RectTransform>();

		canvasRect.GetWorldCorners(corners);

		UpdValues();

	}
	
	// Update is called once per frame
	void Update () {
		if(isActive)
			BringBack();
	}

	void UpdValues(){
		/*
		rctHeigt = canvasRect.rect.height * canvasRect.localScale.y;
		rctWidth = canvasRect.rect.width * canvasRect.localScale.x;	

		height = myRect.rect.height* canvasRect.localScale.y * myRect.localScale.y ;
		width  = myRect.rect.width* canvasRect.localScale.x * myRect.localScale.x ;*/
		rctHeigt = canvasRect.rect.height;// * rctCanvas.lossyScale.y;
		rctWidth = canvasRect.rect.width ;//* rctCanvas.lossyScale.x;	

		height = GetComponent<RectTransform>().rect.height* GetComponent<RectTransform>().lossyScale.y;
		width  = GetComponent<RectTransform>().rect.width* GetComponent<RectTransform>().lossyScale.x;
	}

	public void BringBack(){
		
		UpdValues();

		//Vector3 myPosition = transform.position

		
		canvasRect.GetWorldCorners(corners);

		float xMin = corners[0].x+width/2;//0+width/2;
		float xMax = corners[2].x-width/2;//rctWidth-width/2;
		float yMin = corners[0].y+height/2;
		float yMax = corners[2].y-height/2;

		//Debug.Log("transform y= " + transform.position.y + ", min = " + xMin + ", max = "+ xMax);


		if(transform.position.y>yMax)
			transform.position =new Vector3(transform.position.x, yMax,transform.position.z);

		if(transform.position.y<yMin)
			transform.position =new Vector3(transform.position.x, yMin,transform.position.z);

		if(transform.position.x>xMax)
			transform.position =new Vector3( xMax,transform.position.y,transform.position.z);

			if(transform.position.x<xMin)
			transform.position =new Vector3(xMin,transform.position.y,transform.position.z);
	}
}
