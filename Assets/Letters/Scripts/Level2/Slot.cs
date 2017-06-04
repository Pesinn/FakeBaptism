using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler, IPointerClickHandler {

    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
                return transform.GetChild(0).gameObject;
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(!item) {
            DragHandler.itemBeingDragged.transform.SetParent(transform);

            if (transform.parent.name == "Slots")
                transform.parent.GetComponent<NameValidator>().ValidateName();
        }
    }
   
    public void OnPointerClick(PointerEventData eventData)
    {
        if (transform.parent.name == "Slots" && item)
        {
            var newParentObject = GameObject.Find(item.transform.GetComponent<DragHandler>().SpawnParentPath);       
            item.transform.SetParent(newParentObject.transform);
        }
    }
}