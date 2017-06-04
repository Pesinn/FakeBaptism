using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameValidator : MonoBehaviour {

    List<bool> _result;


    public void ValidateName()
    {
        validateEachChildren();
    }

    private void validateEachChildren()
    {
        _result = new List<bool>();
        
        executeOnEachChild(validateObject);

        var str = "";
        foreach (var i in _result)
            str += i + " ";
        Debug.Log(str);

    }

    /// <summary>
    /// Returns true when excpected letter of the object is the
    /// same as it's children. So if the object expects 'A' as
    /// a letter, it returns true only if 'A' is attached to it.
    /// </summary>
    /// <param name="obj">Object to validate</param>
    /// <returns>True when object's exp letter and
    ///         children letter matches</returns>
    private void validateObject(Transform obj)
    {
        if (obj.childCount == 1)
            _result.Add(compareRelatives(obj, obj.GetChild(0)));
        else if (obj.childCount > 1)
            Debug.LogError("Object should only have single object");
        else
            _result.Add(false);
    }

    private void executeOnEachChild(Action<Transform> callback)
    {
        foreach (Transform child in transform)
        {
            callback(child);
        }
    }

    private bool compareRelatives(Transform parent, Transform child)
    {
        if (parent.name == child.name)
            return true;
        return false;
    }
}
