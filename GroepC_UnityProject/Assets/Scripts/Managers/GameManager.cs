using Unity.Mathematics;
using UnityEngine;
using GroepC.Player;

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
        /// Sets the instance to the <see cref="GameManager"/>.
        /// </summary>
        private void Awake() => Instance = this;

        /// <summary>
        /// Sets the gamemode for the game.
        /// </summary>
        /// <param name="mode">The mode to set.</param>
        public void SetGamemode(GameModes mode) => selectGamemode = mode;

        /// <summary>
        /// Check the conditions every frame.
        /// </summary>
        private void Update() => CheckFinishConditions();

        /// <summary>
        /// Sets the state of the game to started.
        /// </summary>
        public void StartGame() => gameHasStarted = true;

        /// <summary>
        /// Checks if the conditions are met for finishing the game.
        /// </summary>
        private void CheckFinishConditions()
        {
            if (!gameHasStarted)
                return;

            switch (selectGamemode)
            {
                case GameModes.timed:
                    if (SpawnManager.Instance.TargetsLeft == 0)
                        EndGame();
                    break;
                case GameModes.endless:
                    if (TimeManager.Instance.EndlessPoints <= 0)
                        EndGame();
                    break;
            }
        }

        /// <summary>
        /// Ends the game.
        /// </summary>
        public void EndGame()
        {
            gameHasStarted = false;

            switch (selectGamemode)
            {
                case GameModes.timed:
                    ScoreManager.Instance.SaveScoreTimed();
                    break;
                case GameModes.endless:
                    ScoreManager.Instance.SaveScoreEndless();
                    break;
                case GameModes.Tutorial:
                    ScoreManager.Instance.SaveScoreTutorial();
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