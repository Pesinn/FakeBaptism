using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectContainer {
    private GameObject _gameObject;
    private float _x;
    private float _y;

    public GameObjectContainer(GameObject obj, float x, float y)
    {
        _gameObject = obj;
        _x = x;
        _y = y;
    }

    public GameObject GetGameObject()
    {
        return _gameObject;
    }

    public float GetLocationX()
    {
        return _x;
    }

    public float GetLocationY()
    {
        return _y;
    }
}
