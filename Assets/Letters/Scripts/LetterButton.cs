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
        if(myButton != null && _imageController.GetLetterState() != 1)
        {
            var result = letterTouched();

//            Debug.Log("InnerText: " + result.InnerText);
//            Debug.Log("TriggerLetter: " + result.TriggerLetter);
//            Debug.Log("Letter: " + result.Letter);
//            Debug.Log("Status: " + result.Status);
//            Debug.Log("Text: " + result.Text);

            // If Status is not null then this letter
            // isn't triggered, so we must reverse the
            // trigger again
            if (result.Status == 0)
            {
                reverseTrigger();
            }

            changeObjectState(result);
            triggerLevelState(result);
        }
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
