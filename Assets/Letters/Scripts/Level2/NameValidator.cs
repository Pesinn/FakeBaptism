using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        // If any element in _result returns false
        // validateList will become true
        var validateList = _result.Any(x => x.Equals(false));

        // When validate list is false, we have correct name
        if (!validateList)
            executeOnEachChild(setLetterSuccess);
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
            Debug.LogError("Object should only have single object but has " + obj.childCount);
        else
            _result.Add(false);
    }

    /// <summary>
    /// Make object green
    /// </summary>
    /// <param name="obj">Object to make green</param>
    private void setLetterSuccess(Transform obj)
    {
        if(obj.childCount == 1)
            obj.transform.GetChild(0).GetComponent<LetterImageColor>().SetLetterSuccess();
        else
            Debug.LogError("Object should have single object but has " + obj.childCount);
    }

    private void executeOnEachChild(Action<Transform> callback)
    {
        foreach (Transform child in transform)
            callback(child);
    }

    private bool compareRelatives(Transform parent, Transform child)
    {
        if (parent.name == child.name)
            return true;
        return false;
    }
}
