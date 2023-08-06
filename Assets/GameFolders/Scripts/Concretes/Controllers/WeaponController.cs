using GameProject3.Abstracts.Combats;
using GameProject3.Combats;
using GameProject3.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameProject3.Controllers
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] bool _canFire;
        [SerializeField] AttackSO _attackSO;

        float _currentTime = 0f;

        IAttackType _attackType;

        public AnimatorOverrideController AnimatorOverride => _attackSO.AnimatorOverride;


        private void Awake()
        {
            _attackType =GetComponent<IAttackType>();
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;

            _canFire = _currentTime > _attackSO.AttackMaxDelay;
        }
       
        public void Attack()
        {
            if (!_canFire) return;

            _attackType.AttackAction();

            _currentTime = 0f;
        }








    }
}

