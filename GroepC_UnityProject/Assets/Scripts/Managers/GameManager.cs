using Unity.Mathematics;
using UnityEngine;
using GroepC.Player;

namespace GroepC.Managers
{
    /// <summary>
    /// The gamemanager, handles spawn and ending the game.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// The player prefab to spawn in.
        /// </summary>
        [SerializeField] private GameObject playerPrefab;

        /// <summary>
        /// The spawn location for the player.
        /// </summary>
        [SerializeField] private Vector3 spawnLocation;

        /// <summary>
        /// Spawns the player on start.
        /// </summary>
        private void Start() => SpawnPlayer();

        /// <summary>
        /// Spawns in the player on the set location.
        /// </summary>
        private void SpawnPlayer() => Instantiate(playerPrefab, spawnLocation, quaternion.identity).GetComponentInChildren<PlayerHealth>().Setup();
    }
}