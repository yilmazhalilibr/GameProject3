using GameProject3.Abstracts.Combats;
using GameProject3.Combats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject3.ScriptableObjects
{
    enum AttackTypeEnum : byte
    {
        Range, Melee
    }

    [CreateAssetMenu(fileName = "Attack Info", menuName = "Combat/Attack Information/Craete New", order = 51)]
    public class AttackSO : ScriptableObject
    {
        [SerializeField] AttackTypeEnum _attackType;
        [SerializeField] float _floatValue = 1f;
        [SerializeField] int _damage = 10;
        [SerializeField] LayerMask _layerMask;
        [SerializeField] float _attackMaxDelay = 0.25f;
        [SerializeField] AnimatorOverrideController _animatorOverride;


        public float AttackMaxDelay => _attackMaxDelay;
        public float FloatValue => _floatValue;
        public int Damage => _damage;
        public LayerMask LayerMask => _layerMask;
        public AnimatorOverrideController AnimatorOverride => _animatorOverride;
        public IAttackType GetAttackType(Transform transform)
        {
            if (_attackType == AttackTypeEnum.Range)
            {
                return new RangeAttackType(transform, this);
            }
            else
            {
                return new MeleeAttackType(transform, this);
            }
        }

    }

}
