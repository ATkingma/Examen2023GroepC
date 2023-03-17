using GroepC.Managers;
using GroepC.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GroepC.Utilities
{
    /// <summary>
    /// SceneLoader is an class that will load an scene with the given index.
    /// </summary>
    public class SceneLoader : MonoBehaviour
    {

        /// <summary>
        /// The index of the scene that will be loaded.
        /// </summary>
        [SerializeField]
        private int sceneIndex;

        /// <summary>
        /// An bool that will load an scene on start when enabled.
        /// </summary>
        [SerializeField]
        private bool loadOnStart;
        private void Start()
        {
            if (loadOnStart)
            {
                LoadScene();
            }
        }

        /// <summary>
        /// Loads the scene with an given sceneIndex.
        /// </summary>
        public void LoadScene()
        {
            SceneManager.LoadSceneAsync(sceneIndex);
        }

        /// <summary>
        /// Loads the next scene after the tuturial and also gets the right saves this is rarely used.
        /// </summary>
        public void LoadNextSceneTuturial()
        {
            int nextScene = 0;
            nextScene = MenuManager.turialSaveScene;
            GameManager.Instance.EndGame();
            GameManager.Instance.SetGamemode(MenuManager.tuturialSavedMode);
            SceneManager.LoadSceneAsync(nextScene);
        }
    }
}