using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Level1Beginning : MonoBehaviour {
    private LetterCreator _letterCreator;
    private StoreHandler _storeHandler;

    // Use this for initialization
    void Start()
    {
        _storeHandler = new StoreHandler();
        spawnLetters();
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

        var correctLetterList = getCorrectNameWithoutWhitespaces();

        var resultList = randomletterList.Concat(correctLetterList).ToList();

        // Shuffle letters
        UtilsList utils = new UtilsList();
        var shuffeledRandomlist = utils.ShuffleList<string>(resultList);

        _letterCreator.SpawnLetters(shuffeledRandomlist);
    }

    private List<string> createRandomletters()
    {
        var lettersCount = 66;

        var randomLettersCount = lettersCount - getCorrectNameWithoutWhitespaces().Count;

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

    private List<string> getCorrectNameWithoutWhitespaces()
    {
        return _storeHandler.LoadNameListWithoutSpace();
    }
}
