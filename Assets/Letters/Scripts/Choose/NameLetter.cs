using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Choose;

public class NameLetter : MonoBehaviour, IPointerClickHandler {
    public AudioClip RemoveLetterSound;

    private GameObject _parent;
    private NameValidator _nameValidator;
    private AudioMaster _audioMaster;

    void Start()
    {
        _parent = transform.parent.gameObject;
        
        gameObject.SetActive(false);

        _nameValidator = _parent.GetComponent<NameValidator>();
        if(!_nameValidator.isNameFull())
            addLetter();

        _audioMaster = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioMaster>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_nameValidator.isNameEmpty())
        {
            _nameValidator.RemoveGameObject(gameObject);

            _audioMaster.PlayAudio(RemoveLetterSound);
        }
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
