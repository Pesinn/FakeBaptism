using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Beginning : MonoBehaviour {

    private StoreHandler _storeHandler;
    private LetterSprites _letterSprites;

    private List<string> _name;

    // Use this for initialization
    void Start () {
        var letterSprites = GameObject.FindGameObjectWithTag("LetterSprites").GetComponent<LetterSprites>();

        var mainPanelTransform = GameObject.FindGameObjectWithTag("MainPanel").transform;

        var nameSpawnerGameObject = mainPanelTransform.FindChild("Letters");
        var spawnLettersScript = nameSpawnerGameObject.GetComponent<SpawnLetter>();

        var emptySpawnerGameObject = mainPanelTransform.FindChild("Slots");
        var spawnEmptyScript = emptySpawnerGameObject.GetComponent<SpawnLetter>();

        _storeHandler = new StoreHandler();

        spawnLetters(spawnLettersScript, letterSprites);
        spawnEmptyCubes(spawnEmptyScript, letterSprites);
    }

    private void spawnLetters(SpawnLetter spawnLettersScript, LetterSprites letterSprites)
    {
        // Set sprites in SpawnLetter script
        spawnLettersScript.SetSprites(letterSprites);

        // Load name list
        var nameToSpawnList = _storeHandler.LoadNameList();

        _name = nameToSpawnList;

        // Shuffle name
        var shuffeledNameToSpawn = shuffleLetters(nameToSpawnList);

        // Spawn it on the board
        spawnLettersScript.SpawnLetters(shuffeledNameToSpawn);
    }

    private void spawnEmptyCubes(SpawnLetter spawnLetters, LetterSprites letterSprites)
    {
        spawnLetters.SetSprites(letterSprites);
        spawnLetters.SpawnSlot(_name.Count);
    }

    private List<string> shuffleLetters(List<string> letters)
    {
        UtilsList utils = new UtilsList();

        return utils.ShuffleList<string>(letters);
    }

}
