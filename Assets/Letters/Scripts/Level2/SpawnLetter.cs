﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnLetter : MonoBehaviour {
    public GameObject _gameObject;

    private List<string> _letters;

    private LetterSprites _letterSprites;

	void Start () {
        /*       _letters = new List<string>();

            _letters.Add("A");
            _letters.Add("B");
            _letters.Add("C");
            _letters.Add("D");
            _letters.Add("E");
            _letters.Add("F");
            _letters.Add("A");
            _letters.Add("B");
            _letters.Add("C");
            _letters.Add("D");
            _letters.Add("E");
            _letters.Add("F");
            _letters.Add("A");
            _letters.Add("B");
            _letters.Add("C");
            _letters.Add("D");
            _letters.Add("E");
            _letters.Add("F");
            _letters.Add("A");
            _letters.Add("B");
            _letters.Add("C");
            _letters.Add("D");
            _letters.Add("E");
            _letters.Add("F");
            _letters.Add("F");
            _letters.Add("A");
            _letters.Add("B");
            _letters.Add("C");
            _letters.Add("D");
            _letters.Add("E");
            _letters.Add("F");
            _letters.Add("A");
            _letters.Add("B");
            _letters.Add("C");
            _letters.Add("D");
            _letters.Add("E");
            _letters.Add("F");
            _letters.Add("E");
            _letters.Add("F");
            */
        
//        SpawnLetters(_letters);
    }

    public void SetSprites(LetterSprites letterSprites)
    {
        _letterSprites = letterSprites;
    }

    public void SpawnLetters(List<string> letters)
    {
        if (letters.Count > 0)
            spawnGameObject(letters);
        else
            Debug.LogError("No letters to spawn");
    }

    public void SpawnSlot(int count)
    {
        spawnSlot(count);
    }

    private void spawnGameObject(List<string> letters)
    {
        int counter = 0;
        GameObject newGameObject = _gameObject;
        foreach(var i in letters)
        {
            newGameObject.transform.GetChild(0).GetComponent<Image>().sprite = _letterSprites.GetSprite(i);
            spawn(newGameObject).name = i + counter.ToString();
            ++counter;
        }
    }

    private void spawnSlot(int count)
    {
        GameObject newGameObject = _gameObject;
        for(var i = 0; i < count; i++)
            spawn(newGameObject).name = "Slot";
    }

    private GameObject spawn(GameObject obj)
    {
        var instantiate = Instantiate(obj, new Vector3(0, 0, 0), transform.rotation);
        instantiate.transform.SetParent(gameObject.transform, false);
        return instantiate;
    }
}
