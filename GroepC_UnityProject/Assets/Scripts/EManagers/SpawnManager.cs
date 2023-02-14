using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GroepC.Managers
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject enemyPrefab;

        [SerializeField]
        private Transform playerTransform;

        [SerializeField]
        private float spawnRadius = 10f;

        [SerializeField]
        private float spawnRate = 1f;

        [SerializeField]
        private int maxEnemies = 10;

        private int currentEnemies = 0;

        private void Start()
        {
            InvokeRepeating("SpawnEnemy", 0f, spawnRate);
        }

        private void SpawnEnemy()
        {
            if (currentEnemies >= maxEnemies) return;

            Vector3 spawnPos = playerTransform.position + Random.insideUnitSphere * spawnRadius;
            spawnPos.y = playerTransform.position.y;
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            currentEnemies++;
        }
    }
}