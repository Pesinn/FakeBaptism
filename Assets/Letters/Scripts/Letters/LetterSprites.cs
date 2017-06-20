using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterSprites : MonoBehaviour {
    private Dictionary<string, int> _letterDictionary;

    public List<Sprite> _yellowBlackSprites;
    public List<Sprite> _yellowYellowSprites;
    public List<Sprite> _yellowWhiteSprites;
    public List<Sprite> _blackWhiteSprites;

    public Dictionary<List<Sprite>, int> _spriteList;

    // Use this for initialization
    void Awake () {
        createLetterDictionary();
	}

    public Sprite GetSprite(string letter, string color = "yellow_black")
    {
        if(color == "black_white")
            return _blackWhiteSprites[_letterDictionary[letter]];
        if(color == "yellow_yellow")
            return _yellowYellowSprites[_letterDictionary[letter]];
        if (color == "yellow_white")
            return _yellowWhiteSprites[_letterDictionary[letter]];
        return _yellowBlackSprites[_letterDictionary[letter]];
    }

    private void createLetterDictionary()
    {
        _letterDictionary = new Dictionary<string, int>();
        _letterDictionary.Add("A", 0);
        _letterDictionary.Add("B", 1);
        _letterDictionary.Add("C", 2);
        _letterDictionary.Add("D", 3);
        _letterDictionary.Add("E", 4);
        _letterDictionary.Add("F", 5);
        _letterDictionary.Add("G", 6);
        _letterDictionary.Add("H", 7);
        _letterDictionary.Add("I", 8);
        _letterDictionary.Add("J", 9);
        _letterDictionary.Add("K", 10);
        _letterDictionary.Add("L", 11);
        _letterDictionary.Add("M", 12);
        _letterDictionary.Add("N", 13);
        _letterDictionary.Add("O", 14);
        _letterDictionary.Add("P", 15);
        _letterDictionary.Add("Q", 16);
        _letterDictionary.Add("R", 17);
        _letterDictionary.Add("S", 18);
        _letterDictionary.Add("T", 19);
        _letterDictionary.Add("U", 20);
        _letterDictionary.Add("V", 21);
        _letterDictionary.Add("W", 22);
        _letterDictionary.Add("X", 23);
        _letterDictionary.Add("Y", 24);
        _letterDictionary.Add("Z", 25);
        _letterDictionary.Add(" ", 26);
    }
}
