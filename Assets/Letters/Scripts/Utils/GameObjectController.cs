using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectController : MonoBehaviour {

    public void EnableGameObjectByNamePath(string namePath)
    {
        var gameObject  = GameObject.Find(namePath);
        gameObject.SetActive(true);
    }

    public void DisableGameObjectByNamePath(string namePath)
    {
        var gameObject = GameObject.Find(namePath);
        gameObject.SetActive(false);
    }
}