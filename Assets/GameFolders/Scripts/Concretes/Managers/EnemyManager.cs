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
        public bool IsListEmpty => _enemies.Count <= 0;

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
            GameManager.Instance.DecreaseWaveCount();

        }

        public void DestroyAllEnemy()
        {
            foreach (EnemyController enemyController in _enemies)
            {
                Destroy(enemyController.gameObject);
            }
            _enemies.Clear();
        }

    }
}

