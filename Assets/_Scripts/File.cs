using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class File : MonoBehaviour, IDropHandler {
 

	public GameObject windowPrefab;
	public Window myWindow;
	public Sprite sprIcon;

	Image icon;

	public bool open = false;
	public bool Open{
		get{return open;}
		set{open = value;}
	}

	public bool folder = false;
	public bool intective = true;

	public bool movable = true;

	public string fileName = "File.EXE";
	Text txtName;


	CanvasGroup canvasGroup;
	Selectable selectable;


	//public Animator anim;

	void Start () {
		
		canvasGroup = GetComponent<CanvasGroup>();
		selectable 	=GetComponent<Selectable>();
		//icon = transform.Find("Icon").GetComponent<Image>();
		UpdIconName();
		CreatePrefab();

		//anim = GetComponent<Animator>();
	}

	[ContextMenu("Update Icon & name")]
	public void UpdIconName(){
		if(sprIcon != null){
			icon = transform.Find("Icon").GetComponent<Image>();
			icon.sprite = sprIcon;
		}
		txtName 	= GetComponentInChildren<Text>();
		UpdName();
	}

	[ContextMenu("Update My Window")]
	public void UpdMyWindow(){
		myWindow.myFile = this;
		Debug.Log(myWindow.myFile);
	}


	void CreatePrefab(){
		if(myWindow == null && windowPrefab != null){

			GameObject go = Instantiate(windowPrefab, GetComponentInParent<Marker>().transform);
			myWindow = go.GetComponent<Window>();
			myWindow.myFile = this;

		}
	}
	
	// Update is called once per frame
	void Update () {
		//anim.SetBool("Open", open);


		




		// aberto
		if(open){

		
			canvasGroup.alpha = 0.5f;
			if(GetComponent<Draggable>()!=null)//test bug
				GetComponent<Draggable>().enabled = false;
			selectable.interactable = false;
		
		}else{
			canvasGroup.alpha = 1f;
			if(GetComponent<Draggable>()!=null)//test bug
				GetComponent<Draggable>().enabled = true;
			selectable.interactable = true;
		}

	}

	void UpdName(){txtName.text = fileName;}


	public void DoOpen(){
		if(!open)
			myWindow.Open();


	}

	public void OnDrop(PointerEventData eventData) {
		

		 Draggable d = eventData.pointerDrag.GetComponent<Draggable>();

		File f = eventData.pointerDrag.GetComponent<File>();

		//Debug.Log("f eh " + f);
		//Debug.Log("f pasta eh " + f.folder );

		if(f != null && folder && f.movable && !f.open) {
			Debug.Log (eventData.pointerDrag.name + " was dropped on " + gameObject.name);

			d.parentToReturnTo = this.transform;

			//f.transform.parent = myWindow.transform;
			StartCoroutine( f.Shrink(myWindow.dropZone)); // encolher e depois colocar na nova pasta
		}
	}

	IEnumerator Shrink(Transform newParent){
		float duration = 0.5f;

		float tTime = duration; // acerta o timer do ienumerator

		Vector3 startPosition = transform.position; // ajusta posição iniciao do lerp

		//GoTopCanvas();

		while(tTime>0){ // repete até o timer acabar
			transform.localScale = Vector3.one * tTime/duration; 
			canvasGroup.alpha =  tTime/duration;
			//transform.position = Vector3.Lerp(startPosition, target.position, 1-tTime);//also position lerp here

			tTime -= Time.deltaTime;
			yield return null;// new WaitForEndOfFrame();
		}
		transform.SetParent(newParent);
		transform.localScale = Vector3.one ; 
		canvasGroup.alpha =  1;

	}

	public void DoSelect(){
		selectable.Select();
	}

	public void WindowParent(){
		Debug.Log("WindowParent");
		myWindow.transform.SetParent(transform);
	}

	void OnDrawGizmosSelected() {
        if (myWindow != null) {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, myWindow.transform.position);
        }
    }
}
