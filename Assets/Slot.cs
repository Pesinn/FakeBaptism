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
        if(!item)
            DragHandler.itemBeingDragged.transform.SetParent(transform);
    }
    
    private static string getGameObjectPath(Transform transform)
    {
        string path = transform.name;
        while (transform.parent != null)
        {
            transform = transform.parent;
            path = transform.name + "/" + path;
        }
        return path;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (transform.name == "Slot" && item)
        {
            var newParentObject = GameObject.Find(item.transform.GetComponent<DragHandler>().SpawnParentPath);       
            item.transform.SetParent(newParentObject.transform);
        }
    }
}
