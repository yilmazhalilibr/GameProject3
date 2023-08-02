using GameProject3.Abstracts.Combats;
using GameProject3.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace GameProject3.Combats
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField] HealthSO _healthInfo;

        int _currentHealth;
        public bool isDead => _currentHealth <= 0;
        private void Awake()
        {
            _currentHealth = _healthInfo.MaxHealth;
        }

        public void TakeDamage(int damage)
        {
            if (isDead) return;

            _currentHealth -= damage;
        }


    }

}
