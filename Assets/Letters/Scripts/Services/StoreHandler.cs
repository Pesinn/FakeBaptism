using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreHandler {

    public void SaveName(string name)
    {
        PlayerPrefs.SetString("name", name);
    }

    public string LoadName()
    {
        return loadName();
    }

    public List<string> LoadNameList()
    {
        List<string> returnList = new List<string>();
        var nameString = loadName();

        foreach(var i in nameString)
        {
            returnList.Add(i.ToString());
        }

        return returnList;
    }

    private string loadName()
    {
        return PlayerPrefs.GetString("name");
    }
}