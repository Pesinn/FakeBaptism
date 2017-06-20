using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnName : MonoBehaviour {
    public GameObject Letter;

    private Sprite _sprite;
    private string _letter;

    public void SpawnLetter(Sprite sprite, string letter)
    {
        _sprite = sprite;
        _letter = letter;
        spawn();
    }

    private GameObject spawn()
    {
        Letter.transform.GetComponent<Image>().sprite = _sprite;
        var instantiate = Instantiate(Letter, new Vector3(0, 0, 0), transform.rotation);
        instantiate.transform.SetParent(gameObject.transform, false);
        instantiate.name = _letter;
        return instantiate;
    }
}
