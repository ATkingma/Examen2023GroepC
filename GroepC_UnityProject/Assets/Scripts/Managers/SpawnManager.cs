using GroepC.Enemies;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

namespace GroepC.Managers
{
    /// <summary>
    /// A manager that manages an prefab on spawnPoints.
    /// </summary>
    public class SpawnManager : MonoBehaviour
    {
        /// <summary>
        /// The instance of this class.
        /// </summary>
        public static SpawnManager Instance;

        /// <summary>
        /// The points where an prefab can spawn randomly on.
        /// </summary>
        [SerializeField]
        private GameObject[] spawnPoints;


        /// <summary>
        /// The prefab of the targets that will be spawned.
        /// </summary>
        [SerializeField]
        private GameObject targetPrefab;
        /// <summary>
        /// The prefab that will be spawned.
        /// </summary>
        [SerializeField]
        private List<GameObject> enemyPrefab;

        /// <summary>
        /// The player this is an target of the enemy this must be set when the enemy spawns.
        /// </summary>
        [SerializeField]
        private GameObject player;

        /// <summary>
        /// The rate of spawns.
        /// </summary>
        [SerializeField]
        private float spawnRate = 1f;

        /// <summary>
        /// The max amount of enemies that may be spawned.
        /// </summary>
        [SerializeField]
        private int maxEnemies = 10;

        /// <summary>
        /// The increase interval when this is met in the update there will be an increase in values.
        /// </summary>
        [SerializeField]
        private float increaseInterval = 30f;
        
        /// <summary>
        /// The amount of maxEnemies that will be increased.
        /// </summary>
        [SerializeField]
        private int maxEnemiesIncreaseAmount = 1;

        /// <summary>
        /// The Decreasement amount of the spawnRate value.
        /// </summary>
        [SerializeField]
        private float spawnRateDecreaseAmount = 0.01f;

        /// <summary>
        /// THe minimal spawnRate amount.
        /// </summary>
        [SerializeField]
        private float minSpawnRate = 0.03f;

        /// <summary>
        /// The current amount of enemies that are spawned.
        /// </summary>
        private int currentEnemies = 0;

        /// <summary>
        /// An list of targets.
        /// </summary>
        private List<GameObject> spawnedTargets = new List<GameObject>();

        /// <summary>
        /// The amount of targets left.
        /// </summary>
        public int TargetsLeft => spawnedTargets.Count;

        /// <summary>
        /// An list of enemies.
        /// </summary>
        private List<GameObject> spawnedEnemies = new List<GameObject>();

        /// <summary>
        /// The amount of enemies left.
        /// </summary>
        public int EnemiesLeft => spawnedEnemies.Count;

        /// <summary>
        /// The time when this is higher or lower then the increase interval there will be things increased.
        /// </summary>
        private float increaseTime = 0f;

        /// <summary>
        /// Sets the instance.
        /// </summary>
        private void Awake() => Instance = this;

        /// <summary>
        /// Invokes the <see cref="SpawnEnemy"/> based on the <see cref="spawnRate"/>
        /// </summary>
        private void Start()
        {
            switch (GameManager.Instance.SelectGamemode)
            {
                case GameModes.timed:
                    SpawnTargets();
                    break;
                case GameModes.endless:
                    InvokeRepeating(nameof(SpawnEnemy), 0f, spawnRate);
                    break;
            }
        }
        /// <summary>
        /// Sets the given gameobject as the new target.
        /// </summary>
        /// <param name="newtarget">The new target.</param>
        public void SetTarget(GameObject newtarget) => player = newtarget;

        /// <summary>
        /// Spawns Targets.
        /// </summary>
        private void SpawnTargets()
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                Vector3 spawnPos = spawnPoints[i].transform.position;
                GameObject enemy = Instantiate(targetPrefab, spawnPos, Quaternion.identity);
                float randomRotation = Random.Range(0, 360);
                enemy.transform.rotation = Quaternion.Euler(new Vector3(0, randomRotation, 0));
                spawnedTargets.Add(enemy);
            }
        }

        public void RemoveTarget(GameObject target)
        {
            if (spawnedTargets.Contains(target))
            {
                spawnedTargets.Remove(target);
            }
        }

        /// <summary>
        /// Spawns enemies.
        /// </summary>
        private void SpawnEnemy()
        {
            if (currentEnemies >= maxEnemies) return;
            if (spawnPoints.Length <= 0) return;
            if (!player) return;
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPos = spawnPoints[spawnPointIndex].transform.position;
            int rand = Random.Range(0, enemyPrefab.Count);
            GameObject randomPrefab = enemyPrefab[rand];
            GameObject enemy = Instantiate(randomPrefab, spawnPos, Quaternion.identity);
            spawnedEnemies.Add(enemy);
            enemy.GetComponent<EnemyMovement>().SetTarget(player);
            currentEnemies++;
        }

        /// <summary>
        /// Removes an enemy from the spawnedEnemies list and decreases currentEnemies.
        /// </summary>
        /// <param name="enemy">The enemy that wil be removed from the list.</param>
        public void RemoveEnemy(GameObject enemy)
        {
            if (spawnedEnemies.Contains(enemy))
            {
                spawnedEnemies.Remove(enemy);
                currentEnemies--;
            }
        }

        /// <summary>
        /// Increases spawn time values.
        /// </summary>
        private void Update()
        {
            increaseTime += Time.deltaTime;

            if (increaseTime >= increaseInterval)
            {
                maxEnemies += maxEnemiesIncreaseAmount;
                if (spawnRate > minSpawnRate)
                    spawnRate -= spawnRateDecreaseAmount;

                increaseTime = 0f;
            }
        }
    }
}