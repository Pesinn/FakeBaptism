using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Choose;

public class NameLetter : MonoBehaviour, IPointerClickHandler {
    private GameObject _parent;
    private NameValidator _nameValidator;

    void Start()
    {
        _parent = transform.parent.gameObject;

        _nameValidator = _parent.GetComponent<NameValidator>();

        string name = gameObject.name.ToString();
        _nameValidator.AddGameObject(gameObject);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(gameObject);

        _nameValidator.RemoveGameObject(gameObject);
    }
}
