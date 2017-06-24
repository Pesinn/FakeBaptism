using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMaster : MonoBehaviour {
    private AudioSource _source;

	void Start () {
        _source = GetComponent<AudioSource>();
    }

    public void PlayNewAudio(AudioClip sound)
    {
        _source.Stop();
        _source.PlayOneShot(sound);
    }

    public void PlayAudio(AudioClip sound)
    {
        _source.PlayOneShot(sound);
    }

    public void StopAudio()
    {
        _source.Stop();
    }
}
