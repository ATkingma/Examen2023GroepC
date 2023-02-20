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
        private void Start()
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}