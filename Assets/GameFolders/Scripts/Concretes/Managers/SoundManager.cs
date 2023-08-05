using GameProject3.Abstracts.Helpers;
using GameProject3.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject3.Managers
{
    public class SoundManager : SingletonMonoBehaviour<SoundManager>
    {

        [SerializeField] AudioClip[] _clips;

        SoundController[] _soundControllers;


        private void Awake()
        {
            SetSingeltonThisGameObject(this);

            _soundControllers = GetComponentsInChildren<SoundController>();
        }

        private void Start()
        {
            _soundControllers[0].SetClip(_clips[0]);
            _soundControllers[1].SetClip(_clips[1]);

            _soundControllers[0].PlaySound();
        }

        public void PlayMachineGun(Vector3 position)
        {
            _soundControllers[1].SetClip(_clips[1]);
        }



    }
}

