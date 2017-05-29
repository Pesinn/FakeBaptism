using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterImageController : MonoBehaviour {
    private GameObject thisButton;

    private Color defaultColor;
    private Color successColor;
    private Color failureColor;

    private int _letterState;
    private bool isActive;

    void Awake ()
    {
        setColors();

        _letterState = 0;
    }

    // Use this for initialization
    void Start () {
        isActive = false;

        thisButton = this.gameObject;

        // Set default color
        thisButton.GetComponent<Image>().color = defaultColor;
    }

    private void setColors()
    {
        defaultColor = new Color(255, 255, 0, 250);
        successColor = new Color(0, 255, 0, 250);
        failureColor = new Color(255, 0, 0, 250);
    }
	
    public void ChangeState(Result res)
    {
        if (res.Status == 0)
        {
            changeState(res.isTriggeredLetter);
        }
    }

    /// <summary>
    /// 0 = Not picked
    /// 1 = Picked and correct letter
    /// 2 = Picked and wrong letter
    /// </summary>
    public int GetLetterState()
    {
        return _letterState;
    }

    private void changeState(bool isCorrectLetter)
    {
        if (isActive)
            setUnActive();
        else
        {
            if (isCorrectLetter)
                setCorrectLetter();
            else
                setWrongLetter();
        }
    }

    private void setUnActive()
    {
        _letterState = 0;
        thisButton.GetComponent<Image>().color = defaultColor;
        isActive = false;
    }

    private void setCorrectLetter()
    {
        _letterState = 1;
        thisButton.GetComponent<Image>().color = successColor;
        isActive = true;
    }

    private void setWrongLetter()
    {
        _letterState = 2;
        thisButton.GetComponent<Image>().color = failureColor;
        isActive = true;
    }
}