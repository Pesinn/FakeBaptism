using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLevel2 : MonoBehaviour {
    public void FinishLevel()
    {
        var panel = GameObject.FindGameObjectWithTag("MainPanel");
        panel.transform.GetComponent<Image>().color = new Color(0.54F, 0.54F, 0.54F, 1F);

        var fireworksObject = GameObject.FindGameObjectWithTag("Fireworks");
        fireworksObject.GetComponent<FireworksController>().StartFireworks();
        var quitButton = fireworksObject.transform.Find("Quit");

        StartCoroutine(spawnQuitButton(quitButton, 2f));
    }

    private IEnumerator spawnQuitButton(Transform button, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        button.gameObject.SetActive(true);
    }
}
