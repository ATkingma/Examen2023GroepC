using GroepC.Managers;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GroepC.UI
{
    /// <summary>
    /// Keeps count of basic menu functionality.
    /// </summary>
    public class MenuManager : MonoBehaviour
    {
        /// <summary>
        /// Enables an gameobject.
        /// </summary>
        /// <param name="objectToEnable">The object to enable.</param>
        public void EnableObject(GameObject objectToEnable) => objectToEnable.SetActive(true);

        /// <summary>
        /// Disables an gameobject.
        /// </summary>
        /// <param name="objectToDisable">The object to disable.</param>
        public void DisableObject(GameObject objectToDisable) => objectToDisable.SetActive(false);

        /// <summary>
        /// Shuts down the application.
        /// </summary>
        public void ExitApplication() => Application.Quit();

        /// <summary>
        /// Loads an scene with the given sceneId.
        /// </summary>
        /// <param name="sceneId">The scene id to load.</param>
        public void LoadScene(int sceneId) => SceneManager.LoadScene(sceneId);

        /// <summary>
        /// Sets the gamemode.
        /// </summary>
        /// <param name="mode">The mode to set.</param>
        public void SetGamemode(int mode)
        {
            GameModes gameMode;
            switch (mode)
            {
                case 0:
                    gameMode = GameModes.Tutorial;
                    break;
                case 1:
                    gameMode = GameModes.timed;
                    break;
                case 2:
                    gameMode = GameModes.endless;
                    break;
                default:
                    throw new ArgumentException("Invalid game mode value.");
            }

            GameManager.Instance.SetGamemode(gameMode);
        }
    }
}