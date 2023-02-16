using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using GroepC.Player;

namespace GroepC.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private Vector3 spawnLocation;

        private void Awake()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            Instantiate(playerPrefab, spawnLocation, quaternion.identity);
        }
    }
}