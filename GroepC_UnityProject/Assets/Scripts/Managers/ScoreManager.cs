using UnityEngine;
using GroepC.Player;

namespace GroepC.Managers
{
    /// <summary>
    /// This manager to control the scores.
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        /// <summary>
        /// The instance for this class.
        /// </summary>
        public static ScoreManager Instance;

        /// <summary>
        /// Sets the instance.
        /// </summary>
        private void Awake() => Instance = this;

        /// <summary>
        /// The current score.
        /// </summary>
        private int score;

        /// <summary>
        /// The current score.
        /// </summary>
        public int Score => score;

        /// <summary>
        /// Adds score.
        /// </summary>
        /// <param name="addedScore">The amount of score to add.</param>
        public void AddScore(int addedScore) => score += addedScore;

        /// <summary>
        /// Saves the score to the player saves. For the timed gamemode.
        /// </summary>
        public void SaveScoreTimed()
        {
            PlayerSaves saves = JsonUtility.FromJson<PlayerSaves>(SaveManager.Instance.GetSaves("player"));
            if (saves.HighestScoreTimed < score)
                saves.HighestScoreTimed = score;

            SaveManager.Instance.Save(saves, "player");
        }

        /// <summary>
        /// Saves the score to the player saves. For the endless gamemode.
        /// </summary>
        public void SaveScoreEndless()
        {
            PlayerSaves saves = JsonUtility.FromJson<PlayerSaves>(SaveManager.Instance.GetSaves("player"));
            if (saves.HighestScoreEndless < score)
                saves.HighestScoreEndless = score;

            SaveManager.Instance.Save(saves, "player");
        }

        /// <summary>
        /// Save the score to the player saves. For the tutorial gamemode.
        /// </summary>
        public void SaveScoreTutorial()
        {
            PlayerSaves saves = JsonUtility.FromJson<PlayerSaves>(SaveManager.Instance.GetSaves("player"));

            if (saves == null)
            {
                saves = new PlayerSaves();
                saves.HighestScoreTutorial = score;
            }
            else if (saves.HighestScoreTutorial < score)
            {
                saves.HighestScoreTutorial = score;
            }

            SaveManager.Instance.Save(saves, "player");
        }
    }
}