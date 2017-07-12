using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLevel2 : MonoBehaviour {
    public AudioClip _winSound;

    public void FinishLevel()
    {
        var panel = GameObject.FindGameObjectWithTag("MainPanel");
        panel.transform.GetComponent<Image>().color = new Color(0.54F, 0.54F, 0.54F, 1F);

        var fireworksObject = GameObject.FindGameObjectWithTag("Fireworks");
        fireworksObject.GetComponent<FireworksController>().StartFireworks();
        var quitButton = fireworksObject.transform.Find("Quit");

        AudioMaster audioMaster = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioMaster>();
        audioMaster.PlayNewAudio(_winSound);
    }
}
