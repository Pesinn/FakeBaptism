using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterCreator : MonoBehaviour {
    public GameObject Letter;

    LetterSprites _letterSprites;

	void Awake () {
        _letterSprites = GameObject.FindGameObjectWithTag("LetterSprites").GetComponent<LetterSprites>();
    }

    public void SpawnLetters(List<string> letters)
    {
        StartCoroutine(spawnLetterDelay(letters, 0.025f));
    }

    private IEnumerator spawnLetterDelay(List<string> letters, float sec)
    {
        foreach (var i in letters)
        {
            var sprite = _letterSprites.GetSprite(i);
            spawnLetter(i, sprite);
            yield return new WaitForSeconds(sec);
        }
    }

    private GameObject spawnLetter (string letter, Sprite sprite)
    {
        Letter.transform.GetComponent<Image>().sprite = sprite;
        var instantiate = Instantiate(Letter, new Vector3(0, 0, 0), transform.rotation);
        instantiate.transform.SetParent(gameObject.transform, false);
        instantiate.name = letter;
        return instantiate;
    }
}
