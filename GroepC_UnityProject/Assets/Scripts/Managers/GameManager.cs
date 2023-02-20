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
        /// Reference to this gamemanager;
        /// </summary>
        public static GameManager Instance;

        /// <summary>
        /// The player prefab to spawn in.
        /// </summary>
        [SerializeField] private GameObject playerPrefab;

        /// <summary>
        /// The spawn location for the player.
        /// </summary>
        [SerializeField] private Vector3 spawnLocation;

        /// <summary>
        /// The selected <see cref="GameModes"/>.
        /// </summary>
        private GameModes selectGamemode;

        /// <summary>
        /// The selected <see cref="GameModes"/>.
        /// </summary>
        public GameModes SelectGamemode => selectGamemode;

        /// <summary>
        /// Sets the instance to the <see cref="GameManager"/>.
        /// </summary>
        private void Awake() => Instance = this;

        /// <summary>
        /// Spawns the player on start.
        /// </summary>
        private void Start() => SpawnPlayer();

        /// <summary>
        /// Spawns in the player on the set location.
        /// </summary>
        private void SpawnPlayer() => Instantiate(playerPrefab, spawnLocation, quaternion.identity).GetComponentInChildren<PlayerHealth>().Setup();

        /// <summary>
        /// Sets the gamemode for the game.
        /// </summary>
        /// <param name="mode">The mode to set.</param>
        public void SetGamemode(GameModes mode) => selectGamemode = mode;
    }

    /// <summary>
    /// The different gamemodes.
    /// </summary>
    public enum GameModes
    {
        Tutorial = 0,
        timed= 1,
        endless = 2,
    }
}