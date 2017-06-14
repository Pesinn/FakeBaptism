using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
	void Start () {
        Gradient gradient = new Gradient();

        GradientColorKey[] gck;
        GradientAlphaKey[] gak;

        gck = new GradientColorKey[2];
        gck[0].color = new Color(Random.value, Random.value, Random.value, 1.0F);
        gck[0].time = 0.0F;
        gck[0].color = new Color(Random.value, Random.value, Random.value, 1.0F);
        gck[1].time = 1.0F;

        gak = new GradientAlphaKey[2];
        gak[0].alpha = 1.0F;
        gak[0].time = 0.0F;
        gak[1].alpha = 0.0F;
        gak[1].time = 1.0F;

        gradient.SetKeys(gck, gak);

        var startColor = new ParticleSystem.MinMaxGradient(gradient);

        var particleSystem = this.GetComponent<ParticleSystem>();
        var main = particleSystem.main;

        main.startColor = gradient;

//        var rand = Random.Range(0, 10);
//        Debug.Log(rand + " " + Time.time);
//        main.startDelay = rand;
    }
}
