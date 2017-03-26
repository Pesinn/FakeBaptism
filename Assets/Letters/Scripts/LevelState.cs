using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Changes state of the level each time
/// something triggers it
/// </summary>
public class LevelState : MonoBehaviour {

    private SwapHandler _swapHandler;
    private FinishLevel _finishLevel;

	// Use this for initialization
	void Start () {
        _swapHandler = GameObject.FindGameObjectWithTag("Letters").GetComponent<SwapHandler>();
        _finishLevel = GameObject.FindGameObjectWithTag("ResultsEventHandler").GetComponent<FinishLevel>();
    }

    public void TriggerChanges(Result result)
    {
        if (result.Status == 0)
        {
            if (result.isCorrectName)
                _finishLevel.TriggerFinishLevel();
            else if (result.isTriggeredLetter && result.Action == "PICK" && result.isCorrectLetter) {
                Debug.Log("fuck");
                StartCoroutine(swapTrigger(.2f));
            }
        }
    }

    private IEnumerator swapTrigger(float sec)
    {
        yield return new WaitForSeconds(sec);
        _swapHandler.SwapTrigger();
    }
}
