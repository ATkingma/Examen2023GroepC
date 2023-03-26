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
            playerSaves = JsonUtility.FromJson<PlayerSaves>(SaveManager.Instance.GetSaves("player"));
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
        public void AddDeath()
        {

        }

        public void AddGame()
        {

        }

        public void AddEnemy()
        {

        }

        public void AddReload()
        {

        }

        public void AddWeaponSwap()
        {

        }

        public void AddShot()
        {

        }

        public void AddHit()
        {

        }

        public void AddSelfHit()
        {

        }

        public void AddDamageTaken(float amount)
        {

        }

        public void AddDashes()
        {

        }

        public void AddJumppad()
        {

        }
        #endregion
    }
}