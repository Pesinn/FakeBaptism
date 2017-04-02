using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// OnStart for level 1
/// </summary>
public class OnStart : MonoBehaviour {

    private SwapHandler _swapHandler;
    private LettersContainer _letterContainer;

    // Use this for initialization
    void Start () {
        _swapHandler = GameObject.FindGameObjectWithTag("Letters").GetComponent<SwapHandler>();
        _swapHandler.SwapTrigger();
        _letterContainer = new LettersContainer();
        saveCorrectName();
    }

    private void saveCorrectName()
    {

        //        PlayerPrefs.SetString("name", listToString(_letterContainer.GetCorrectName()));
        PlayerPrefs.SetString("name", "NADIABJORKPETURSDOTTIR");
    }

    private string listToString(List<string> list)
    {
        StringBuilder builder = new StringBuilder();
        foreach (var i in list)
        {
            builder.Append(i);
        }
        var returnString = builder.ToString();
        return returnString;
    }
}
