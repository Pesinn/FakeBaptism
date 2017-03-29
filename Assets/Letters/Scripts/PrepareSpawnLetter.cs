using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareSpawnLetter : MonoBehaviour {
    private StoreHandler _storeHandler;

    // Use this for initialization
    void Start () {
        _storeHandler = new StoreHandler();
        var gameObject = GameObject.FindGameObjectWithTag("MainPanel").GetComponent<LetterCreator>();
        gameObject.SpawnLetters(getCorrectNameList());
    }

    private List<string> getCorrectNameList()
    {
        var returnList = new List<string>();
        foreach(var i in getCorrectName())
        {
            returnList.Add(i.ToString());
        }
        return returnList;
    }

    private string getCorrectName()
    {
        return _storeHandler.LoadName();
    }
}
