using GameProject3.Managers;
using GameProject3.ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameProject3.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] SpawnInfoSO _spawnInfo;

        float _currentTime = 0f;
        float _maxTime;

        private void Start()
        {
            _maxTime = _spawnInfo.RandomMaxSpawnTime;
        }


        private void Update()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime > _maxTime && EnemyManager.Instance.CanSpawn && !GameManager.Instance.IsWaveFinished)
            {
                Spawn();
            }
        }

        private void Spawn()
        {
            EnemyController enemyController = Instantiate(_spawnInfo.EnemyPrefab, transform.position, Quaternion.identity);
            EnemyManager.Instance.AddEnemyController(enemyController);

            _currentTime = 0f;
            _maxTime = _spawnInfo.RandomMaxSpawnTime;
        }
    }
}

