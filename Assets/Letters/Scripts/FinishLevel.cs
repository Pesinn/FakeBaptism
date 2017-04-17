﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour {

    EvaporateHandler _evaprovateHandler;
	// Use this for initialization
	void Start () {
        _evaprovateHandler = GameObject.FindGameObjectWithTag("MainPanel").GetComponent<EvaporateHandler>();
    }

    public void TriggerFinishLevel()
    {
        StartCoroutine(hideAllUnPickedLetterDelay(.3f));
        StartCoroutine(fireworksDelay(1f));
        StartCoroutine(changeLevel(2f));
    }

    private IEnumerator hideAllUnPickedLetterDelay(float sec)
    {
        yield return new WaitForSeconds(sec);
        _evaprovateHandler.HideAllUnPickedLetters();
    }

    private IEnumerator fireworksDelay(float sec)
    {
        yield return new WaitForSeconds(sec);
    }

    private IEnumerator changeLevel(float sec)
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene(1);
    }
}
