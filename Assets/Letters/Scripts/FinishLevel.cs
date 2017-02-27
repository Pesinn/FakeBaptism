using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour {

    EvaporateHandler _evaprovateHandler;
	// Use this for initialization
	void Start () {
        _evaprovateHandler = GameObject.FindGameObjectWithTag("Letters").GetComponent<EvaporateHandler>();
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
        Debug.LogWarning("ROCKETS");
    }

    private IEnumerator changeLevel(float sec)
    {
        yield return new WaitForSeconds(sec);
        Application.LoadLevel(1);
    }
}
