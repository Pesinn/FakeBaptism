using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Level1Beginning : MonoBehaviour {

    private LettersContainer _letterContainer;
    private StoreHandler _storeHandler;

    // Use this for initialization
    void Awake()
    {
        _letterContainer = new LettersContainer();
        _storeHandler = new StoreHandler();
        saveCorrectName();
    }

    private void saveCorrectName()
    {
        _storeHandler.SaveName(listToString(_letterContainer.GetCorrectName()));
    }

    private string listToString(List<string> list)
    {
        StringBuilder builder = new StringBuilder();
        foreach (var i in list)
        {
            builder.Append(i);
        }
        var returnString = builder.ToString();
        return returnString;
    }
}
