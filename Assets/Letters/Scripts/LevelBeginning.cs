using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBeginning : MonoBehaviour {
    private GameObject _preLevel;
    private LettersContainer _letterContainer;

    void Awake() {
        _preLevel = GameObject.FindGameObjectWithTag("PreLevel");
    }

    void Start() {
        StartCoroutine(preLevelDuration(3f));
    }

    private IEnumerator preLevelDuration(float sec)
    {
        yield return new WaitForSeconds(sec);
        var currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        var nextBuildIndex = currentBuildIndex + 1;
        SceneManager.LoadScene(nextBuildIndex);
    }
}
