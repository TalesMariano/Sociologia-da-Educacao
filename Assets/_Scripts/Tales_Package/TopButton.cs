using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class TopButton : MonoBehaviour, IDeselectHandler, ISelectHandler {

	Button thisButton;

	public bool startSelect= false;
	
	void Start () {
		thisButton = GetComponent<Button>();
		if(startSelect){	DoSelect();}
	}

	public void OnSelect(BaseEventData eventData){
		thisButton.enabled = true;
	}

	public void OnDeselect(BaseEventData eventData){
		thisButton.enabled = false;
	}

	public void DoSelect(){
		thisButton.enabled = true;
		thisButton.Select();
	}
}
