using GameProject3.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameProject3.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Spawner", menuName = "Combat/Spawner Info/Create New", order = 51)]
    public class SpawnInfoSO : ScriptableObject
    {
        [SerializeField] EnemyController _enemyPrefab;
        [SerializeField] float _maxSpawnTime = 15f;
        [SerializeField] float _minSpawnTime = 3f;

        public EnemyController EnemyPrefab => _enemyPrefab;
        public float RandomMaxSpawnTime => Random.Range(_minSpawnTime, _maxSpawnTime);

    }

}

