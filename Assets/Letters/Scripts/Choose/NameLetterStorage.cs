using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores all letters in name which has been picked
/// and validated
/// </summary>
public class NameLetterStorage {
    private List<string> _name;
    private StoreHandler _storeHandler;
    public NameLetterStorage()
    {
        _name = new List<string>();
        _storeHandler = new StoreHandler();
    }

    public void SetName(List<string> name)
    {
        _name = name;
        saveName();
    }

    private void saveName()
    {
        _storeHandler.SaveName(_name);
    }
}
