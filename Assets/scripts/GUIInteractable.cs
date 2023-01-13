using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GUIInteractable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{
    
    private void Start(){

    }

    private void Update(){
        
    }

    public void OnPointerEnter(PointerEventData eventData){
        GameController.GetInstance().SetPixelCursor();
    }

    public void OnPointerExit(PointerEventData eventData){
        GameController.GetInstance().SetTargetCursor();
    }
}
