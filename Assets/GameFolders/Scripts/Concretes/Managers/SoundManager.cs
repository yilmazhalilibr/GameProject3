using GameProject3.Abstracts.Helpers;
using GameProject3.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject3.Managers
{
    public class SoundManager : SingletonMonoBehaviour<SoundManager>
    {

        [SerializeField] AudioClip _clip;

        SoundController[] _soundControllers;

        public SoundController[] SoundControllers => _soundControllers;
        private void Awake()
        {
            SetSingeltonThisGameObject(this);

            _soundControllers = GetComponentsInChildren<SoundController>();
        }

        private void Start()
        {
            _soundControllers[0].SetClip(_clip);
            _soundControllers[0].PlaySound(Vector3.zero);
        }

        public void RangeAttackSound(Vector3 position)
        {
            _soundControllers[1].PlaySound(position);
        }

        public void MeleeAttackSound(Vector3 position)
        {
            _soundControllers[2].PlaySound(position);
        }

    }
}

