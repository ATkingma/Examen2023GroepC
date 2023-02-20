using GroepC.Enemies;
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
        private GameObject[] spawnPoints;

        [SerializeField]
        private GameObject enemyPrefab;

        [SerializeField]
        private GameObject player;

        [SerializeField]
        private float spawnRate = 1f;

        [SerializeField]
        private int maxEnemies = 10;

        [SerializeField]
        private float increaseInterval = 30f;

        [SerializeField]
        private int maxEnemiesIncreaseAmount = 1;

        [SerializeField]
        private float spawnRateDecreaseAmount = 0.01f;

        [SerializeField]
        private float minSpawnRate = 0.03f;

        private int currentEnemies = 0;
        private List<GameObject> spawnedEnemies = new List<GameObject>();
        private float increaseTime = 0f;

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
            if (spawnPoints.Length <= 0) return;

            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPos = spawnPoints[spawnPointIndex].transform.position;
            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            spawnedEnemies.Add(enemy);
            enemy.GetComponent<EnemyMovement>().SetTarget(player);
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
            increaseTime += Time.deltaTime;

            if (increaseTime >= increaseInterval)
            {
                maxEnemies += maxEnemiesIncreaseAmount;
                if (spawnRate > minSpawnRate)
                {
                    spawnRate -=spawnRateDecreaseAmount;
                }
                increaseTime = 0f;
            }
        }
    }
}