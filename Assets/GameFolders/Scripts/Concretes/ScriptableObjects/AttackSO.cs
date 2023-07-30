using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject3.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Attack Info", menuName = "Attack Information/Craete New", order = 51)]
    public class AttackSO : ScriptableObject
    {

        [SerializeField] float _floatValue = 1f;
        [SerializeField] int _damage = 10;
        [SerializeField] LayerMask _layerMask;
        [SerializeField] float _attackMaxDelay = 0.25f;


        public float AttackMaxDelay => _attackMaxDelay;
        public float FloatValue => _floatValue;
        public int Damage => _damage;
        public LayerMask LayerMask => _layerMask;

    }

}
