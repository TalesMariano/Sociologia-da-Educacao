using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasAnchor))]
public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler {

	public RectTransform rctCanvas;

	CanvasAnchor canvasAnchor;

	public Transform parentToReturnTo = null;


	public float rctHeigt;
	public float rctWidth;

	Vector2 mosePos;
	Vector2 lokiPos;

	Vector2 difPos;

	//MyDimentios

	float height = 200;
	float width = 125;

	void Start(){
		rctCanvas = GetComponentInParent<Marker>().GetComponent<RectTransform>();
		canvasAnchor = GetComponent<CanvasAnchor>();
	}

	void Update() {
		rctHeigt = rctCanvas.rect.height;// * rctCanvas.lossyScale.y;
		rctWidth = rctCanvas.rect.width ;//* rctCanvas.lossyScale.x;	

		height = GetComponent<RectTransform>().rect.height;//* GetComponent<RectTransform>().lossyScale.y;
		width  = GetComponent<RectTransform>().rect.width;//* GetComponent<RectTransform>().lossyScale.x;
	}

	public void OnBeginDrag(PointerEventData eventData) {
		Debug.Log ("OnBeginDrag");
		//mosePos = eventData.position;
		mosePos = eventData.position;
		lokiPos = transform.position;
		difPos =   lokiPos -mosePos;

		parentToReturnTo = this.transform.parent;
		this.transform.SetParent( this.transform.parent.parent );
		this.transform.SetParent( rctCanvas );

		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	public void OnPointerClick(PointerEventData eventData) {
		Debug.Log ("On point clcic");
		mosePos = eventData.position;
		lokiPos = transform.position;
		difPos =   lokiPos -mosePos;
	}


	public void OnDrag(PointerEventData eventData) {
		Debug.Log ("OnDrag");

		

		this.transform.position = eventData.position+difPos;

		canvasAnchor.BringBack();
	}
	
	public void OnEndDrag(PointerEventData eventData) {
		Debug.Log ("OnEndDrag");

		//Debug.Log("transform y= " + transform.position.y + ", min = " + height/2 + ", max = "+ (rctHeigt-height/2));

		

			this.transform.SetParent( parentToReturnTo );
		GetComponent<CanvasGroup>().blocksRaycasts = true;

		//BringBack();

		
	}
	
	public void BringBack(){
		float xMin = 0+width/2;
		float xMax = rctWidth-width/2;
		float yMin = height/2;
		float yMax = rctHeigt-height/2;

		Debug.Log("transform x= " + transform.localPosition.x + ", min = " + xMin + ", max = "+ xMax);


		if(transform.localPosition.y>rctHeigt-height/2)
			transform.localPosition =new Vector3(transform.localPosition.x, rctHeigt-height/2,transform.localPosition.z);

		if(transform.localPosition.y<0+height/2)
			transform.localPosition =new Vector3(transform.localPosition.x, 0+height/2,transform.localPosition.z);

		if(transform.localPosition.x>xMax)
			transform.localPosition =new Vector3( xMax,transform.localPosition.y,transform.localPosition.z);

			if(transform.localPosition.x<xMin)
			transform.localPosition =new Vector3(xMin,transform.localPosition.y,transform.localPosition.z);
	}




}
