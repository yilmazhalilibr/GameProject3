using GameProject3.Abstracts.Combats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameProject3.Controllers
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] int _damage = 10;
        [SerializeField] bool _canFire;
        [SerializeField] float _attackMaxDelay = 0.025f;
        [SerializeField] float _distance = 100f;
        [SerializeField] Camera _camera;
        [SerializeField] LayerMask _layerMask;

        float _currentTime = 0f;

        private void Update()
        {
            _currentTime += Time.deltaTime;

            _canFire = _currentTime > _attackMaxDelay;

        }

        public void Attack()
        {
            if (!_canFire) return;


            Ray ray = _camera.ViewportPointToRay(Vector3.one / 2f);

            if (Physics.Raycast(ray, out RaycastHit hit, _distance, _layerMask))
            {

                if (hit.collider.TryGetComponent(out IHealth health))
                {
                    health.TakeDamage(_damage);
                }


            }

            _currentTime = 0f;
        }








    }
}

