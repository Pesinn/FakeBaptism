using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Level2;

public class Slot : MonoBehaviour, IDropHandler, IPointerClickHandler {
    private AudioSource _source;
    public AudioClip OnDropSound;
    public AudioClip RemoveItemSound;

    void Start()
    {
        _source = GetComponent<AudioSource>();
    }

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
            {
                _source.PlayOneShot(OnDropSound);
                validateName();
            }
        }
    }

    public void playOnDropSound()
    {

    }

    private void validateName()
    {
        var validation = transform.parent.GetComponent<Level2.NameValidator>().ValidateName();
        if (validation)
            GameObject.FindGameObjectWithTag("OnEnd").GetComponent<FinishLevel2>().FinishLevel();
    }
   
    public void OnPointerClick(PointerEventData eventData)
    {
        if (transform.parent.name == "Slots" && item)
        {
            var newParentObject = GameObject.Find(item.transform.GetComponent<DragHandler>().SpawnParentPath);       
            item.transform.SetParent(newParentObject.transform);
            _source.PlayOneShot(RemoveItemSound);
        }
    }
}