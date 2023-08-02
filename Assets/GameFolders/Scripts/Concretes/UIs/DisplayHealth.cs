using GameProject3.Combats;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameProject3.UIs
{
    public class DisplayHealth : MonoBehaviour
    {
        Image _healthImage;

        private void Awake()
        {
            _healthImage = GetComponent<Image>();
        }

        private void OnEnable()
        {
            Health health = GetComponentInParent<Health>();
            health.OnTakeHit += HandleTakeIt;
        }

        private void HandleTakeIt(int currentHealth, int maxHealth)
        {
            _healthImage.fillAmount = Convert.ToSingle(currentHealth) / Convert.ToSingle(maxHealth);
        }







    }
}

