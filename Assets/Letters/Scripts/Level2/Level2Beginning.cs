using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Beginning : MonoBehaviour {

    private LetterCreator _letterCreator;
    private LetterCreator _emptyLetterCreator;
    private StoreHandler _storeHandler;

    // Use this for initialization
    void Awake () {
        var mainPanelTransform = GameObject.FindGameObjectWithTag("MainPanel").transform;

        //var nameSpawnerGameObject = mainPanelTransform.FindChild("NameSpawner");
        //_letterCreator = nameSpawnerGameObject.GetComponent<LetterCreator>();

        var emptySpawnerGameObject = mainPanelTransform.FindChild("EmptySpawner");
        _emptyLetterCreator = emptySpawnerGameObject.GetComponent<LetterCreator>();

        _storeHandler = new StoreHandler();

        //spawnLetters();
        spawnEmptyCubes();
    }

/*    private void spawnLetters()
    {
        // Load name list
        var nameToSpawnList = _storeHandler.LoadNameList();

        // Shuffle name
        var shuffeledNameToSpawn = shuffleLetters(nameToSpawnList);

        // Spawn it on the board
        _letterCreator.SpawnLetters(shuffeledNameToSpawn, 3);
    }
    */
    private void spawnEmptyCubes()
    {
        List<string> emptyStrings = new List<string>();

        var name = _storeHandler.LoadName();

        // Create one empty character for each letter
        foreach(var i in name)
            emptyStrings.Add(" ");

        _emptyLetterCreator.SpawnLetters(emptyStrings, 0, 0.1f);
    }

    private List<string> shuffleLetters(List<string> letters)
    {
        UtilsList utils = new UtilsList();

        return utils.ShuffleList<string>(letters);
    }

}
