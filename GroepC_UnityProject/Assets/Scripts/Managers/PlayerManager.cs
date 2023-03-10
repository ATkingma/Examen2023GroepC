using Unity.Mathematics;
using UnityEngine;
using GroepC.Player;
using GroepC.Managers;

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

    /// <summary>
    /// Initiates spawning the player.
    /// </summary>
    private void OnEnable() => SpawnPlayer();

    /// <summary>
    /// Spawns in the player on the set location.
    /// </summary>
    private void SpawnPlayer()
    {
        PlayerHealth player = Instantiate(playerPrefab, spawnLocation, quaternion.identity).GetComponentInChildren<PlayerHealth>();
        player.Setup();
        GameManager.Instance.StartGame();
        TimeManager.Instance.GiveUI(player.GetComponent<PlayerController>());
        ScoreManager.Instance.GiveUI(player.GetComponent<PlayerController>());
        SpawnManager.Instance.SetTarget(player.gameObject);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1;
    }
}
