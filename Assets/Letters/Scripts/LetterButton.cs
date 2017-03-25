using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterButton : MonoBehaviour {
    Button myButton;

    private LetterClickDetector _letterClickDetector;
    private LetterImageController _imageController;
    private LevelState _levelState;
    private bool isTriggered;

    void Awake()
    {
        isTriggered = false;

        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(onClickEvent);

        var resultEventHandler = GameObject.FindGameObjectWithTag("ResultsEventHandler");

        _letterClickDetector = resultEventHandler.GetComponent<LetterClickDetector>();
        _levelState = resultEventHandler.GetComponent<LevelState>();

        _imageController = gameObject.GetComponent<LetterImageController>();
    }	
    
    public int GetLetterState()
    {
        return _imageController.GetLetterState();
    }

    private void onClickEvent()
    {
        // Prevent correct letters that have been picket to be changed
        if (myButton != null && _imageController.GetLetterState() != 1)
            processAction(0, true);
    }
    
    /// <summary>
    /// Process action for current letter.
    /// </summary>
    /// <param name="delayTimer">Delay until action is processed</param>
    /// <param name="pick">True if current letter should be picked
    ///     false if it should be unpicked </param>
    private void processAction(float delayTimer, bool pick)
    {
        var result = processLetterTouched();

        StartCoroutine(unPickLetterWithDelay(delayTimer, result));

        if (!result.isTriggeredLetter && pick)
            processAction(2, false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private Result processLetterTouched()
    {
        var result = letterTouched();
        if (result.Status == 0)
        {
            reverseTrigger();
        }
        return result;
    }


    private Result letterTouched()
    {
        LetterAction letterAction;
        if (!isTriggered)
        {
            letterAction = new PickLetter(myButton.name);
        }
        else
        {
            letterAction = new UnPickLetter(myButton.name);
        }

        return _letterClickDetector.LetterAction(letterAction);
    }

    private IEnumerator unPickLetterWithDelay(float sec, Result res)
    {
        yield return new WaitForSeconds(sec);
        changeObjectState(res);
        triggerLevelState(res);
    }

    private void changeObjectState(Result result)
    {
        if (result.Status == 0)
        {
            _imageController.ChangeState(result);
        }
    }

    /// <summary>
    /// Let level state know that it can process any
    /// changes necessary.
    /// </summary>
    /// <param name="result"></param>
    private void triggerLevelState(Result result)
    {
        _levelState.TriggerChanges(result);
    }

    private void setTrigger(bool set)
    {
        isTriggered = set;
    }

    private void reverseTrigger()
    {
        if (isTriggered)
        {
            isTriggered = false;
        }
        else
        {
            isTriggered = true;
        }
    }
}
