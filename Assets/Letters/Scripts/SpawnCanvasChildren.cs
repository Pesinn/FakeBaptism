using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCanvasChildren : MonoBehaviour {
    private int _maxRowCapacity;

    private int _maxColumnCapacity;

    public SpawnCanvasChildren()
    {

    }

    public void SpawnGameObjectRelatedToParent(GameObjectContainer objectContainer, GameObject parent)
    {
        var instantiate = Instantiate(objectContainer.GetGameObject(), new Vector3(objectContainer.GetLocationX(), objectContainer.GetLocationY(), 0), transform.rotation);
        instantiate.transform.SetParent(parent.transform, false);
    }
}
