using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

public class StoreHandler {

    private UtilsList _utilsList;

    public StoreHandler()
    {
        _utilsList = new UtilsList();
    }
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
        var nameString = loadName();

        return _utilsList.StringToList(nameString);
    }

    public List<string> LoadNameListWithoutSpace()
    {
        var nameString = LoadNameWithoutSpace();
        return _utilsList.StringToList(nameString);
    }

    public string LoadNameWithoutSpace()
    {
        var name = loadName();
        
        name = new string(name.ToCharArray()
        .Where(c => !Char.IsWhiteSpace(c))
        .ToArray());
        
        return name;
    }

    private string loadName()
    {
        return PlayerPrefs.GetString("name");
    }
}