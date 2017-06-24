using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBeginning : MonoBehaviour {
    public AudioClip Sound;

    private LettersContainer _letterContainer;
    private AudioSource _source;

    void Start() {
        _source = GetComponent<AudioSource>();
        playSound();
        StartCoroutine(preLevelDuration(6f));
    }

    private void playSound()
    {
        _source.PlayOneShot(Sound);
    }

    private IEnumerator preLevelDuration(float sec)
    {
        yield return new WaitForSeconds(sec);
        var currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        var nextBuildIndex = currentBuildIndex + 1;
        SceneManager.LoadScene(nextBuildIndex);
    }
}
