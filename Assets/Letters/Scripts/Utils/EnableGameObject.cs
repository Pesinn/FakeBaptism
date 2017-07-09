using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGameObject : MonoBehaviour {	
    public void EnableGameObjectWithTag()
    {
        var gameObject = FindGameObject("test");
        gameObject.SetActive(true);
    }

    public void DisableGameObjectWithtag()
    {
        var gameObject = FindGameObject("test");
        gameObject.SetActive(false);
    }

    private GameObject FindGameObject(string tag)
    {
        return GameObject.FindGameObjectWithTag(tag);
    }
}
