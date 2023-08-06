using GameProject3.Abstracts.Combats;
using GameProject3.Managers;
using GameProject3.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject3.Combats
{
    public class RangeAttackType : IAttackType
    {
        AttackSO _attackSO;
        Camera _camera;

        public RangeAttackType(Transform trnasformObject, AttackSO attackSO)
        {
            _camera = trnasformObject.GetComponent<Camera>();
            _attackSO = attackSO;
        }

        public void AttackAction()
        {
            Ray ray = _camera.ViewportPointToRay(Vector3.one / 2f);

            if (Physics.Raycast(ray, out RaycastHit hit, _attackSO.FloatValue, _attackSO.LayerMask))
            {

                if (hit.collider.TryGetComponent(out IHealth health))
                {
                    health.TakeDamage(_attackSO.Damage);
                }


            }

            SoundManager.Instance.PlayMachineGun(_camera.transform.position);

        }

    }

}
