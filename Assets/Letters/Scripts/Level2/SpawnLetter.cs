﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnLetter : MonoBehaviour {
    public GameObject _gameObject;

    private List<string> _letters;

    private LetterSprites _letterSprites;

    public void SetSprites(LetterSprites letterSprites)
    {
        _letterSprites = letterSprites;
    }

    /// <summary>
    /// Spawn list of letters
    /// </summary>
    /// <param name="letters">List of letters to spawn</param>
    public void SpawnLetters(List<string> letters)
    {
        if (letters.Count > 0)
            spawnGameObject(letters);
        else
            Debug.LogError("No letters to spawn");
    }

    public void SpawnSlot(List<string> letters)
    {
        spawnSlot(letters);
    }

    private void spawnGameObject(List<string> letters)
    {
        int counter = 0;
        GameObject newGameObject = _gameObject;
        foreach(var i in letters)
        {
            newGameObject.transform.GetChild(0).GetComponent<Image>().sprite = _letterSprites.GetSprite(i);
            var obj = spawn(newGameObject);
            obj.name = i + counter.ToString();
            obj.transform.GetChild(0).name = i;
            ++counter;
        }
    }

    private void spawnSlot(List<string> letters)
    {
        GameObject newGameObject = _gameObject;
        foreach(var i in letters)
            spawn(newGameObject).name = i;
    }

    private GameObject spawn(GameObject obj)
    {
        var instantiate = Instantiate(obj, new Vector3(0, 0, 0), transform.rotation);
        instantiate.transform.SetParent(gameObject.transform, false);
        return instantiate;
    }
}
