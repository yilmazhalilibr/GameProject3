using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameProject3.Controllers
{
    public class SoundController : MonoBehaviour
    {

        AudioSource _audioSource;


        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void SetClip(AudioClip clip)
        {
            _audioSource.clip = clip;
        }

        public void PlaySound()
        {
            _audioSource.Play();
        }



    }
}

