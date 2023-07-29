using GameProject3.Abstracts.Controllers;
using GameProject3.Abstracts.Movements;
using GameProject3.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProject3.Controllers
{
    public class EnemyController : MonoBehaviour, IEntityController
    {
        [SerializeField] Transform _playerPrefab;

        IMover _mover;

        private void Awake()
        {
            _mover = new MoveWithNavMesh(this);
        }

        private void Update()
        {
            _mover.MoveAction(_playerPrefab.transform.position, 10f);
        }


    }

}
