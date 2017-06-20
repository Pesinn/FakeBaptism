using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PickHandler : MonoBehaviour, IPointerClickHandler {
    public Sprite Default;
    public Sprite OnClick;

    private int _number;

    void Start()
    {
        _number = 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().sprite = OnClick;
        Invoke("SetDefaultSprite", 0.3f);
        SpawnLetter();
    }

    private void SetDefaultSprite()
    {
        gameObject.GetComponent<Image>().sprite = Default;
    }

    private void SpawnLetter()
    {
        ++_number;
        GameObject.Find("/Canvas/Panel/Choosen").GetComponent<SpawnName>().SpawnLetter(Default, gameObject.name + _number);
    }
}
