using GameProject3.Abstracts.Helpers;
using GameProject3.Controllers;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace GameProject3.Managers
{
    public class EnemyManager : SingletonMonoBehaviour<EnemyManager>
    {
        [SerializeField] int _maxCountOnGame = 50;
        [SerializeField] List<EnemyController> _enemies;

        public bool CanSpawn => _maxCountOnGame > _enemies.Count;


        private void Awake()
        {
            SetSingeltonThisGameObject(this);
            _enemies = new List<EnemyController>();
        }


        public void AddEnemyController(EnemyController enemyController)
        {
            enemyController.transform.parent = this.transform;
            _enemies.Add(enemyController);
        }
        public void RemoveEnemyController(EnemyController enemyController)
        {
            _enemies.Remove(enemyController);
        }



    }
}

