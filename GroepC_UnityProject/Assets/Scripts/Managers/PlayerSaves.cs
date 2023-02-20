namespace GroepC.Player
{
    /// <summary>
    /// Class that holds the player stats.
    /// </summary>
    public class PlayerSaves
    {
        /// <summary>
        /// The highest score in the timed gamemode.
        /// </summary>
        public float HighestScoreTimed;

        /// <summary>
        /// The highest score in the endless gamemode.
        /// </summary>
        public float HighestScoreEndless;

        /// <summary>
        /// The highest score in the tutorial gamemode.
        /// </summary>
        public float HighestScoreTutorial;

        /// <summary>
        /// The amount of deaths of the player.
        /// </summary>
        public float Deaths;

        /// <summary>
        /// The amount of games played
        /// </summary>
        public float GamesPlayed;

        /// <summary>
        /// The amount of enemies killed.
        /// </summary>
        public float enemiesKilled;
    }
}