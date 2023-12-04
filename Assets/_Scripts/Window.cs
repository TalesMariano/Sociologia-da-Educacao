using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window : MonoBehaviour {

	public Sprite sprIcon;
	Image icon;

	public File myFile;
	public bool open = false;
	public Transform dropZone;


	CanvasGroup canvasGroup;
	CanvasAnchor canvasAnchor;

	Text txtName;

	float transitionDuration = 0.5f;


	void Start () {
		canvasGroup = GetComponent<CanvasGroup>();
		canvasAnchor = GetComponent<CanvasAnchor>();
		//dropZone = GameObject.Find("/Drop Zone").transform;//transform.Find("Drop Zone");

		txtName = transform.Find("Title").GetComponent<Text>();

		FileSettings();//pega valores e sprite do arquivo de icone

		UpdIconName();//icon = transform.Find("Icon").GetComponent<Image>();


		if(!open)
			EndClose();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FileSettings(){
		if(myFile != null){
			if(sprIcon == null){
				sprIcon = myFile.sprIcon;
			}

		}
	}

	[ContextMenu("Update Icon & name")]
	public void UpdIconName(){

		if(sprIcon != null){
			icon = transform.Find("Icon").GetComponent<Image>();
			icon.sprite = sprIcon;
		}

		//Update title
		if(myFile != null){
			txtName.text = myFile.fileName;
		}

	}

	public void Open(){
		myFile.open = true;

		StartCoroutine(LerpOpen(myFile.transform, transitionDuration));
	}

	void MyOpen(){
		open = true;

		canvasGroup.alpha = 1;
		canvasGroup.interactable = true;

	}

	public void Close(){
		myFile.Open = false;

		

		StartCoroutine(LerpClose(myFile.transform, transitionDuration));
	}

	void EndClose(){
		open = false;

		transform.localScale = Vector3.zero;
		canvasGroup.alpha = 0f;

		canvasGroup.interactable = false;

		

	}

	[ContextMenu("Test Lerp")]
 	public void AnimClosing(){//(Transform target, float duration){
		
		 Debug.Log("Anim Closing"); 

		//StartCoroutine(LerpClose(transform,0.8f));//(target,duration));

		StartCoroutine(testLerp(myFile.transform));
		StartCoroutine(LerpClose(transform,1f));//(target,duration));



	}



	IEnumerator LerpOpen(Transform target, float duration){

		float tTime = 0;

		GoTopCanvas();

		ScrollRect scrol = GetComponentInChildren<ScrollRect>();

		transform.position = myFile.transform.position; // Coloca na mesma posição do icone

		while(tTime<duration){
			transform.localScale = Vector3.one * tTime/duration;
			canvasGroup.alpha =  tTime/duration;
			//also position lerp here
			transform.position = myFile.transform.position;
			canvasAnchor.BringBack();

			if(scrol != null)
				scrol.verticalNormalizedPosition = 1;

			tTime += Time.deltaTime;
			yield return null;// new WaitForEndOfFrame();
		}

		transform.localScale = Vector3.one;
		canvasGroup.alpha = 1;

		//-*-*-*-*-*
		MyOpen();

	}
	
	IEnumerator LerpClose(Transform target, float duration){

		

		float tTime = duration; // acerta o timer do ienumerator

		//Debug.Log(transform.position);

		Vector3 startPosition = transform.position; // ajusta posição iniciao do lerp

		//GoTopCanvas();

		while(tTime>0){ // repete até o timer acabar
			
			transform.localScale = Vector3.one * tTime/duration; 
			canvasGroup.alpha =  tTime/duration;
			transform.position = Vector3.Lerp(startPosition, target.position, 1-tTime/duration);//also position lerp here

			//Debug.Log(transform.position);

			tTime -= Time.deltaTime;
			yield return null;// new WaitForEndOfFrame();
		}

		myFile.DoSelect();

		//-*-*-*-*-*
		EndClose();

	}

	IEnumerator testLerp(Transform target){
		float tTime = 0;

		Vector3 startPosition = transform.position;

		while(tTime < 1){
			transform.position = Vector3.Lerp(startPosition, target.position, tTime);

			tTime += Time.deltaTime;
			yield return null;


		}

	}


	void GoTopCanvas(){
		Transform tempParent = transform.parent;
		transform.SetParent(transform.parent.parent);
		transform.SetParent(tempParent);
	}

	void OnDrawGizmos() {
        if (myFile != null) {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, myFile.transform.position);
        }
    }

/* 
	void Outro(){

			IEnumerator LerpOut(float durTime){
		zoomIn = false;

		float tTime = 0;

		onLerpOut.Invoke();

		foreach(GameObject blo in block)
			blo.SetActive(true);
		
		foreach(GameObject blo in antiBlock)
			blo.SetActive(false);

		while(tTime<durTime){
			_camera.transform.position = Vector3.Lerp(secondPos, firstPos, tTime/durTime);
			_camera.orthographicSize = Mathf.Lerp(secondSize, firstSize, tTime/durTime);

			tTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		_camera.transform.position = firstPos;
		_camera.orthographicSize = firstSize;
	}

	IEnumerator Lerp (float durTime, Vector3 pos1, Vector3 pos2, float size1, float size2, bool zoomin){
		
		zoomIn = zoomin;

		float tTime = 0;
		if(!zoomin)
			onLerpOut.Invoke();
		else
			onLerpIn.Invoke();

		foreach(GameObject blo in block)
			blo.SetActive(!zoomin);

		foreach(GameObject blo in antiBlock)
			blo.SetActive(zoomin);

		while(tTime<durTime){
			_camera.transform.position = Vector3.Lerp(pos1, pos2, tTime/durTime);
			_camera.orthographicSize = Mathf.Lerp(size1, size2, tTime/durTime);

			tTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		_camera.transform.position = pos2;
		_camera.orthographicSize = size2;

	}

	}*/
}
