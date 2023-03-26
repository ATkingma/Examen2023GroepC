using GroepC.Managers;
using GroepC.Player;
using TMPro;
using UnityEngine;

namespace GroepC.UI
{
    /// <summary>
    /// Shows an bord of scores that may or may not needed to be filled in.s
    /// </summary>
    public class ScoreBord : MonoBehaviour
    {
        /// <summary>
        /// HighScore Text.
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI highscoreText;

        /// <summary>
        /// HighScoreEndless Text.
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI highScoreEndlessText;

        /// <summary>
        /// death Text.
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI deathText;

        /// <summary>
        /// gamesplayed Text.
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI gamesPlayedText;

        /// <summary>
        /// EnemiesKilled Text.
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI enemiesKilledText;

        /// <summary>
        /// Reloads Text.
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI reloadText;

        /// <summary>
        /// WeaponSwaps Text.
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI weaponSwapsText;

        /// <summary>
        /// Shots Text.
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI shotsText;

        /// <summary>
        /// Hits Text.
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI hitsText;

        /// <summary>
        /// Accuracy Text.
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI accuracyText;

        /// <summary>
        /// SelfHits Text.
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI selfHitsText;

        /// <summary>
        /// damageTaken Text.
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI damageTakenText;

        /// <summary>
        /// dash Text.
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI dashesText;

        /// <summary>
        /// JumpPads Taken Text.
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI jumpPadsTakenText;
        private void OnEnable()
        {
            PlayerSaves saves = SaveManager.Instance.PlayerSaves;
            
            if(highscoreText!=null)
                highscoreText.text = saves.HighestScoreTimed.ToString();
            if (highScoreEndlessText != null)
                highScoreEndlessText.text = saves.HighestScoreEndless.ToString();
            if (deathText != null)
                deathText.text = saves.Deaths.ToString();
            if (gamesPlayedText != null)
                gamesPlayedText.text = saves.GamesPlayed.ToString();
            if (enemiesKilledText != null)
                enemiesKilledText.text = saves.EnemiesKilled.ToString();
            if (reloadText != null)
                reloadText.text = saves.Reloads.ToString();
            if (weaponSwapsText != null)
                weaponSwapsText.text = saves.WeaponSwaps.ToString();
            if (shotsText != null)
                shotsText.text = saves.Shots.ToString();
            if (hitsText != null)
                hitsText.text = saves.Hits.ToString();
            if (accuracyText != null)
                accuracyText.text = saves.Accuracy.ToString();
            if (selfHitsText != null)
                selfHitsText.text = saves.SelfHits.ToString();
            if (damageTakenText != null)
                damageTakenText.text = saves.DamageTaken.ToString();
            if (dashesText != null)
                dashesText.text = saves.Dashes.ToString();
            if (jumpPadsTakenText != null)
                jumpPadsTakenText.text = saves.JumppadsTaken.ToString();
        }
    }
}