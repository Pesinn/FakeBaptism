using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterReader : MonoBehaviour {
    public void UnpickRandomCorrectlyPicked()
    {
        var transform = findRandomlyAlreadyPicked();

        Debug.Log(transform.name);

        var letterButton = transform.GetComponent<LetterButton>();

        letterButton.CorrectLetterReversed();
    }

    private Transform findRandomlyAlreadyPicked()
    {
        var children = getChildren();

        var alreadyPicked = new List<Transform>();

        foreach (var i in children)
        {
            var gameObject = i.GetComponent<LetterButton>();
            if (gameObject.GetLetterState() == 1)
            {
                alreadyPicked.Add(i);
            }
        }

        var random = Random.Range(0, alreadyPicked.Count);

        return alreadyPicked[random];
    }


    private List<Transform> getChildren()
    {
        List<Transform> children = new List<Transform>();

        foreach (Transform child in transform)
        {
            children.Add(child);
        }

        return children;
    }
}
