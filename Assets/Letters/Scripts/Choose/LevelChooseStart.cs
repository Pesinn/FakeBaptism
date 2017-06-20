using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChooseStart : MonoBehaviour
{
    public List<string> StartLetters;

    void Awake()
    {
        var letterSprites = GameObject.FindGameObjectWithTag("LetterSprites").GetComponent<LetterSprites>();

        var mainPanelTransform = GameObject.FindGameObjectWithTag("MainPanel").transform;

        var nameSpawnerGameObject = mainPanelTransform.FindChild("Constants");
        var spawnLettersScript = nameSpawnerGameObject.GetComponent<SpawnPickLetter>();

        spawnLetters(spawnLettersScript, letterSprites);
    }


    private void spawnLetters(SpawnPickLetter spawnLettersScript, LetterSprites letterSprites)
    {
        spawnLettersScript.SetSprites(letterSprites);

        if(StartLetters.Count > 0)
            spawnLettersScript.SpawnLetters(StartLetters);
    }
}
