using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Beginning : MonoBehaviour {

    private LetterCreator _letterCreator;
    private StoreHandler _storeHandler;

    // Use this for initialization
    void Awake () {
        _letterCreator = GameObject.FindGameObjectWithTag("MainPanel").GetComponent<LetterCreator>();
        _storeHandler = new StoreHandler();

        spawnLetters();
        spawnEmptyCubes();
    }

    private void spawnLetters()
    {
        // Load name list
        var nameToSpawnList = _storeHandler.LoadNameList();

        // Shuffle name
        var shuffeledNameToSpawn = shuffleLetters(nameToSpawnList);

        // Spawn it on the board
        _letterCreator.SpawnLetters(shuffeledNameToSpawn, 3);
    }

    private void spawnEmptyCubes()
    {
        List<string> emptyStrings = new List<string>();

        // Create as many empty as they are suppose to be
        emptyStrings.Add(" ");
        emptyStrings.Add(" ");
        emptyStrings.Add(" ");
        emptyStrings.Add(" ");
        emptyStrings.Add(" ");
        emptyStrings.Add(" ");

        _letterCreator.SpawnLetters(emptyStrings, 0, 0.1f);
    }

    private List<string> shuffleLetters(List<string> letters)
    {
        UtilsList utils = new UtilsList();

        return utils.ShuffleList<string>(letters);
    }

}
