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
        return PlayerPrefs.GetString("name");
    }
}
