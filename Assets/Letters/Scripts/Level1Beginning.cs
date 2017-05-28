﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Level1Beginning : MonoBehaviour {
    private LetterCreator _letterCreator;
    private LettersContainer _letterContainer;
    private StoreHandler _storeHandler;

    // Use this for initialization
    void Awake()
    {
        _letterContainer = new LettersContainer();
        _storeHandler = new StoreHandler();
        _letterCreator = new LetterCreator();
        saveCorrectName();
        spawnLetters();
    }

    private void saveCorrectName()
    {
        _storeHandler.SaveName(listToString(_letterContainer.GetCorrectName()));
    }

    private string listToString(List<string> list)
    {
        StringBuilder builder = new StringBuilder();
        foreach (var i in list)
        {
            builder.Append(i);
        }
        var returnString = builder.ToString();
        return returnString;
    }

    
    private void spawnLetters()
    {
        _letterCreator = GameObject.FindGameObjectWithTag("MainPanel").GetComponent<LetterCreator>();

        var randomletterList = createRandomletters();

        var correctLetterList = getCorrectNameList();

        var resultList = randomletterList.Concat(correctLetterList).ToList();

        // Shuffle letters
        UtilsList utils = new UtilsList();
        var shuffeledRandomlist = utils.ShuffleList<string>(resultList);

        _letterCreator.SpawnLetters(shuffeledRandomlist);
    }

    private List<string> createRandomletters()
    {
        var lettersCount = _letterCreator.GetMaximumLettersCount();

        var randomLettersCount = lettersCount - getCorrectName().Length;

        if(randomLettersCount < 0) 
            randomLettersCount *= (-1);

        var randomLettersList = RandomString(randomLettersCount);

        return randomLettersList;
    }

    private List<string> RandomString(int length)
    {
        List<string> randomLetters = new List<string>();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVXYZ";

        for (int i=0; i < length; i++)
        {
            var random = Random.Range(0, chars.Length);
            randomLetters.Add(chars[random].ToString());
        }

        return randomLetters;
    }

    private List<string> getCorrectNameList()
    {
        var returnList = new List<string>();
        foreach(var i in getCorrectName())
        {
            returnList.Add(i.ToString());
        }
        return returnList;
    }

    private string getCorrectName()
    {
        return _storeHandler.LoadName();
    }
}
