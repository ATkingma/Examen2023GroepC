using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GroepC.Managers
{
    public class SpawnManager : MonoBehaviour
    {
        private static SpawnManager instance;
        public static SpawnManager Instance => instance;

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

        [SerializeField]
        private float maxEnemiesIncreaseInterval = 30f;

        [SerializeField]
        private int maxEnemiesIncreaseAmount = 1;

        private int currentEnemies = 0;
        private List<GameObject> spawnedEnemies = new List<GameObject>();
        private float timeSinceMaxEnemiesIncrease = 0f;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(Instance);
            }
            instance = this;
        }

        private void Start()
        {
            InvokeRepeating("SpawnEnemy", 0f, spawnRate);
        }

        private void SpawnEnemy()
        {
            if (currentEnemies >= maxEnemies) return;

            Vector3 spawnPos = playerTransform.position + Random.insideUnitSphere * spawnRadius;
            spawnPos.y = playerTransform.position.y;
            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            spawnedEnemies.Add(enemy);
            currentEnemies++;
        }

        public void RemoveEnemy(GameObject enemy)
        {
            if (spawnedEnemies.Contains(enemy))
            {
                spawnedEnemies.Remove(enemy);
                currentEnemies--;
            }
        }

        private void Update()
        {
            timeSinceMaxEnemiesIncrease += Time.deltaTime;

            if (timeSinceMaxEnemiesIncrease >= maxEnemiesIncreaseInterval)
            {
                maxEnemies += maxEnemiesIncreaseAmount;
                timeSinceMaxEnemiesIncrease = 0f;
            }
        }
    }
}