using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreHandler {
    public void SaveName(string name)
    {
        PlayerPrefs.SetString("name", name);
    }

    public void LoadName()
    {
        PlayerPrefs.GetString("name");
    }
}
