using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class StoreHandler {

    public void SaveName(string name)
    {
        PlayerPrefs.SetString("name", name);
    }

    public void SaveName(List<string> name)
    {
        StringBuilder str = new StringBuilder();

        foreach (var i in name)
            str.Append(i);

        PlayerPrefs.SetString("name", str.ToString());
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