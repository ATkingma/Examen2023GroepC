using Unity.Mathematics;
using UnityEngine;
using GroepC.Player;
using UnityEngine.SceneManagement;
using System;

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
        /// Defines wether the game has started.
        /// </summary>
        private bool gameHasStarted;

        /// <summary>
        /// Defines wether the game has started.
        /// </summary>
        public bool GameHasStarted => gameHasStarted;

        /// <summary>
        /// The selected <see cref="GameModes"/>.
        /// </summary>
        private GameModes selectGamemode;

        /// <summary>
        /// The selected <see cref="GameModes"/>.
        /// </summary>
        public GameModes SelectGamemode => selectGamemode;

        /// <summary>
        /// Get activated when opening the menu.
        /// </summary>
        public Action MenuOpened;

        /// <summary>
        /// Get activated when opening the scoremenu.
        /// </summary>
        public Action ScoreOpend;

        /// <summary>
        /// Sets the instance to the <see cref="GameManager"/>.
        /// </summary>
        private void Awake() => Instance = this;

        /// <summary>
        /// Checks if the menu needs to open.
        /// </summary>
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
                MenuOpened?.Invoke();

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                
            }
            else if (Input.GetKeyUp(KeyCode.Tab))
            {

            }
        }

        /// <summary>
        /// Sets the gamemode for the game.
        /// </summary>
        /// <param name="mode">The mode to set.</param>
        public void SetGamemode(GameModes mode) => selectGamemode = mode;

        /// <summary>
        /// Sets the state of the game to started.
        /// </summary>
        public void StartGame() => gameHasStarted = true;

        /// <summary>
        /// Checks if the conditions are met for finishing the game.
        /// </summary>
        public void CheckFinishConditions()
        {
            if (!gameHasStarted)
                return;

            if (SpawnManager.Instance.TargetsLeft == 0)
                EndGame();
        }

        /// <summary>
        /// Ends the game.
        /// </summary>
        public void EndGame()
        {
            SaveManager.Instance.AddGame();
            gameHasStarted = false;

            switch (selectGamemode)
            {
                case GameModes.timed:
                    ScoreManager.Instance.SaveScoreTimed();
                    SceneManager.LoadSceneAsync(1);
                    break;
                case GameModes.endless:
                    ScoreManager.Instance.SaveScoreEndless();
                    SceneManager.LoadSceneAsync(1);
                    break;
                case GameModes.Tutorial:
                    PlayerPrefs.SetInt("tutorialFinished", 1);
                    break;
            }
        }
    }

    /// <summary>
    /// The different gamemodes.
    /// </summary>
    public enum GameModes
    {
        Tutorial,
        timed,
        endless,
    }
}