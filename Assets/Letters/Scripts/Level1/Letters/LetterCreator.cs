using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterCreator : MonoBehaviour {
    public GameObject Letter;

    LetterSprites _letterSprites;

	void Awake () {
        _letterSprites = GameObject.FindGameObjectWithTag("LetterSprites").GetComponent<LetterSprites>();
    }

    public void SpawnLetters(List<string> letters)
    {
        foreach(var i in letters)
        {
            Debug.Log(i);
            var sprites = _letterSprites.GetSprite(i);
            spawnLetter(i, sprites);
        }
    }

    private GameObject spawnLetter (string letter, Sprite sprite)
    {
        Letter.transform.GetComponent<Image>().sprite = sprite;
        var instantiate = Instantiate(Letter, new Vector3(0, 0, 0), transform.rotation);
        instantiate.transform.SetParent(gameObject.transform, false);
        instantiate.name = letter;
        return instantiate;
    }
}
