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
            for (int i = 0; i < _soundControllers.Length; i++)
            {
                _soundControllers[i].SetClip(_clips[i]);

            }

            _soundControllers[0].PlaySound(Vector3.zero);
        }

        public void PlayMachineGun(Vector3 position)
        {
            _soundControllers[1].PlaySound(position);
        }



    }
}

