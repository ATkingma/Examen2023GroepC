using Unity.Mathematics;
using UnityEngine;
using GroepC.Player;

/// <summary>
/// Manages spawning the player.
/// </summary>
public class PlayerManager : MonoBehaviour
{
    /// <summary>
    /// The player prefab to spawn in.
    /// </summary>
    [SerializeField] private GameObject playerPrefab;

    /// <summary>
    /// The spawn location for the player.
    /// </summary>
    [SerializeField] private Vector3 spawnLocation;

    private void OnEnable() => SpawnPlayer();

    /// <summary>
    /// Spawns in the player on the set location.
    /// </summary>
    private void SpawnPlayer() => Instantiate(playerPrefab, spawnLocation, quaternion.identity).GetComponentInChildren<PlayerHealth>().Setup();
}
