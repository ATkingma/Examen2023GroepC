using GroepC.Player;
using UnityEngine;

namespace GroepC.Managers
{
    /// <summary>
    /// This class handles saving classes to jsonStrings.
    /// </summary>
    public class SaveManager : MonoBehaviour
    {
        /// <summary>
        /// The <see cref="SaveManager"/> instance.
        /// </summary>
        public static SaveManager Instance;

        /// <summary>
        /// The current player saves.
        /// </summary>
        private PlayerSaves playerSaves = new PlayerSaves();

        /// <summary>
        /// The current player saves.
        /// </summary>
        public PlayerSaves PlayerSaves => playerSaves;

        /// <summary>
        /// Sets the instance.
        /// </summary>
        private void Awake()
        {
            Instance = this;
            playerSaves = JsonUtility.FromJson<PlayerSaves>(Instance.GetSaves("player"));
            if (playerSaves == null)
                playerSaves = new PlayerSaves();
        }

        /// <summary>
        /// Saves the given class as Json.
        /// </summary>
        /// <param name="classType">The class to save.</param>
        /// <param name="saveKey">The save key.</param>
        public void Save(object classType, string saveKey) => PlayerPrefs.SetString(saveKey, JsonUtility.ToJson(PlayerPrefs.GetString(classType.ToString())));

        /// <summary>
        /// Gets the save based on the given key.
        /// </summary>
        /// <param name="saveKey">The key of the save.</param>
        /// <returns>The saved value as a string.</returns>
        public string GetSaves(string saveKey) => PlayerPrefs.GetString(saveKey);

        /// <summary>
        /// Adds the score to the corrosponding value.
        /// </summary>
        #region specific scores
        public void AddDeath() => playerSaves.Deaths++;

        public void AddGame() => playerSaves.GamesPlayed++;

        public void AddEnemyKilled() => playerSaves.EnemiesKilled++;

        public void AddReload() => playerSaves.Reloads++;

        public void AddWeaponSwap() => playerSaves.WeaponSwaps++;

        public void AddShot() => playerSaves.WeaponSwaps++;

        public void AddHit() => playerSaves.Hits++;

        public void AddSelfHit() => playerSaves.SelfHits++;

        public void AddDamageTaken(float amount)
        {
            playerSaves.DamageTaken += amount;
            AddSelfHit();
        }

        public void AddDashes() => playerSaves.Dashes++;

        public void AddJumppad() => playerSaves.Dashes++;
        #endregion
    }
}