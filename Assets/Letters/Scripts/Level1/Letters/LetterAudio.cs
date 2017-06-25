using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LetterFind
{
    public class LetterAudio : MonoBehaviour {

        public AudioClip WrongLetterClick;
        public AudioClip CorrectLetterClick;
        private AudioSource _audioSource;

        void Start()
        {
            _audioSource = GameObject.FindGameObjectWithTag("MainPanel").GetComponent<AudioSource>();
        }

        public void PlayWrongLetterClick()
        {
            _audioSource.PlayOneShot(WrongLetterClick);
        }

        public void PlayCorrectLetterClick()
        {
            _audioSource.PlayOneShot(CorrectLetterClick);
        }

    }
}