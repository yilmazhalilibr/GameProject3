using GameProject3.Abstracts.Combats;
using GameProject3.ScriptableObjects;
using UnityEngine;

namespace GameProject3.Controllers
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] bool _canFire;

        float _currentTime = 0f;

        IAttackType _attackType;

        public AnimatorOverrideController AnimatorOverride => _attackType.AttackInfo.AnimatorOverride;


        private void Awake()
        {
            _attackType = GetComponent<IAttackType>();
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;

            _canFire = _currentTime > _attackType.AttackInfo.AttackMaxDelay;
        }

        public void Attack()
        {
            if (!_canFire) return;

            _attackType.AttackAction();

            _currentTime = 0f;
        }








    }
}

