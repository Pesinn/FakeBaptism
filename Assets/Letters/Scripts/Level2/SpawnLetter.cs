using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnLetter : MonoBehaviour {
    public GameObject _gameObject;

    public List<string> _letters;

    private LetterSprites _letterSprites;

	void Start () {
        _letters = new List<string>();

        _letters.Add("A");
        _letters.Add("B");
        _letters.Add("C");
        _letters.Add("D");
        _letters.Add("E");
        _letters.Add("F");
        _letters.Add("A");
        _letters.Add("B");
        _letters.Add("C");
        _letters.Add("D");
        _letters.Add("E");
        _letters.Add("F");
        _letters.Add("A");
        _letters.Add("B");
        _letters.Add("C");
        _letters.Add("D");
        _letters.Add("E");
        _letters.Add("F");
        _letters.Add("A");
        _letters.Add("B");
        _letters.Add("C");
        _letters.Add("D");
        _letters.Add("E");
        _letters.Add("F");

        _letterSprites = GameObject.FindGameObjectWithTag("LetterSprites").GetComponent<LetterSprites>();

        SpawnLetters(_letters);
    }
	
    public void SpawnLetters(List<string> letters)
    {
        spawnGameObject(letters);
    }

    private void spawnGameObject(List<string> letters)
    {
        int counter = 0;
        GameObject newGameObject = _gameObject;
        foreach(var i in letters)
        {
            newGameObject.name = i + counter.ToString();
            newGameObject.transform.GetChild(0).GetComponent<Image>().sprite = _letterSprites.GetSprite(i);
            var instantiate = Instantiate(newGameObject, new Vector3(0, 0, 0), transform.rotation);
            instantiate.transform.SetParent(gameObject.transform, false);
            ++counter;
        }
    }
}
