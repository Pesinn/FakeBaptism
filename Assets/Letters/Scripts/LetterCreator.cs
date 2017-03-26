using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterCreator : MonoBehaviour {
    public GameObject _spawnObject;
    // List of sprites in alpabetic order, where index 0 is A and last index is Z
    public List<Sprite> _sprites;
    private StoreHandler _storeHandler;
    private Dictionary<string, int> _letterDictionary;

    void Start () {
        _storeHandler = new StoreHandler();
        CreateLetterDictionary();
        spawnLetters();
    }

    private void spawnLetters()
    {
        var x = -200;
        GameObject newSpawnObject;
        foreach (var i in getCorrectName())
        {
            Debug.Log(_letterDictionary[i.ToString()]);
            var letterIndex = _letterDictionary[i.ToString()];
            newSpawnObject = _spawnObject;
            newSpawnObject.transform.GetComponent<Image>().sprite = _sprites[letterIndex];
            var instantiate = Instantiate(newSpawnObject, new Vector3(x, 0, 0), transform.rotation);
            instantiate.transform.SetParent(gameObject.transform, false);
            x += 200;
        }
    }

    private void CreateLetterDictionary()
    {
        _letterDictionary = new Dictionary<string, int>();
        _letterDictionary.Add("A", 0);
        _letterDictionary.Add("B", 1);
        _letterDictionary.Add("C", 2);
        _letterDictionary.Add("D", 3);
        _letterDictionary.Add("E", 4);
        _letterDictionary.Add("F", 5);
        _letterDictionary.Add("G", 6);
        _letterDictionary.Add("H", 7);
        _letterDictionary.Add("I", 8);
        _letterDictionary.Add("J", 9);
        _letterDictionary.Add("K", 10);
        _letterDictionary.Add("L", 11);
        _letterDictionary.Add("M", 12);
        _letterDictionary.Add("N", 13);
        _letterDictionary.Add("O", 14);
        _letterDictionary.Add("P", 15);
        _letterDictionary.Add("Q", 16);
        _letterDictionary.Add("R", 17);
        _letterDictionary.Add("S", 18);
        _letterDictionary.Add("T", 19);
        _letterDictionary.Add("U", 20);
        _letterDictionary.Add("V", 21);
        _letterDictionary.Add("X", 22);
        _letterDictionary.Add("Y", 23);
        _letterDictionary.Add("Z", 24);
    }

    private string getCorrectName()
    {
        return _storeHandler.LoadName();
    }


}
