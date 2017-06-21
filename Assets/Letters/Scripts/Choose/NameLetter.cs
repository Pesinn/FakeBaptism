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

        gameObject.SetActive(false);

        _nameValidator = _parent.GetComponent<NameValidator>();
        if(!_nameValidator.isNameFull())
            addLetter();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_nameValidator.isNameEmpty())
            _nameValidator.RemoveGameObject(gameObject);
        else
            Debug.LogError("Name letter game object destroyed but the name validator is empty");

        Destroy(gameObject);
    }

    private void addLetter()
    {
        _nameValidator.AddGameObject(gameObject);
        gameObject.SetActive(true);
    }
}
