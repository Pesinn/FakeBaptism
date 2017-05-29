using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LetterClickDetector : MonoBehaviour {

    LettersContainer container;

    void Awake() {
        container = new LettersContainer();
    }

    public Result LetterAction(LetterAction e) {
        return e.StartLetterProcess(container);
    }
}