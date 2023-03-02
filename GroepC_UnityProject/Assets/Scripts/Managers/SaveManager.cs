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
        /// Sets the instance.
        /// </summary>
        private void Awake() => Instance = this;

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
    }
}