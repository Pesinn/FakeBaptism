using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterReader : MonoBehaviour {
    public void UnpickRandomCorrectlyPicked()
    {
        var transforms = findRandomlyAlreadyPicked();

        if (transforms.Count > 0)
        {
            var randomlyPickedTransform = pickRandomObject(transforms);

            var letterButton = randomlyPickedTransform.GetComponent<LetterButton>();

            letterButton.CorrectLetterReversed();
        }
    }

    private List<Transform> findRandomlyAlreadyPicked()
    {
        var children = getChildren();

        var alreadyPicked = new List<Transform>();

        foreach (var i in children)
        {
            var gameObject = i.GetComponent<LetterButton>();
            if (gameObject.GetLetterState() == 1)
                alreadyPicked.Add(i);
        }

        return alreadyPicked;
    }

    private Transform pickRandomObject(List<Transform> objects)
    {
        var random = Random.Range(0, objects.Count);

        return objects[random];
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
