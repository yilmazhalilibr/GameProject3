using GameProject3.Abstracts.Combats;
using GameProject3.Controllers;
using GameProject3.Managers;
using GameProject3.ScriptableObjects;
using UnityEngine;

namespace GameProject3.Combats
{
    public class RangeAttackType : MonoBehaviour, IAttackType
    {
        [SerializeField] AttackSO _attackSO;
        [SerializeField] Camera _camera;
        [SerializeField] BulletFxController _bulletFxController;
        [SerializeField] Transform _bulletPoint;

        public AttackSO AttackInfo => _attackSO;

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

            var bullet = Instantiate(_bulletFxController, _bulletPoint.position, _bulletPoint.rotation);
            bullet.SetDirection(ray.direction);

            SoundManager.Instance.RangeAttackSound(_attackSO.AudioClip, _camera.transform.position);

        }

    }

}
