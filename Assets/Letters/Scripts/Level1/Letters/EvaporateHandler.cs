using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaporateHandler : MonoBehaviour {

    List<Transform> _children;

	// Use this for initialization
	void Start () {
        _children = getChildren();
    }

    public void HideAllUnPickedLetters()
    {
        _children = getChildren();

        foreach(var i in _children)
        {
            var gameObject = i.GetComponent<LetterButton>();
            if(gameObject.GetLetterState() != 1)
            {
                i.gameObject.SetActive(false);
            }

        }
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
