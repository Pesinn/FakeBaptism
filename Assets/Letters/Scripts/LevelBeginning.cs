using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBeginning : MonoBehaviour {
    private GameObject _preLevel;

    void Awake() {
        _preLevel = GameObject.FindGameObjectWithTag("PreLevel");
    }

    void Start() {
        StartCoroutine(preLevelDuration(3f));
    }

    private IEnumerator preLevelDuration(float sec)
    {
        yield return new WaitForSeconds(sec);
        _preLevel.SetActive(false);
    }
}
