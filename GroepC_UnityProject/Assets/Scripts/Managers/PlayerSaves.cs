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
        public float EnemiesKilled;

        /// <summary>
        /// The amount of times the player has reloaded.
        /// </summary>
        public float Reloads;

        /// <summary>
        /// The amount of times the player has swapped weapons.
        /// </summary>
        public float WeaponSwaps;

        /// <summary>
        /// The amount of times the player has shot.
        /// </summary>
        public float Shots;

        /// <summary>
        /// The amount of times the player has actually hit an enemy.
        /// </summary>
        public float Hits;

        /// <summary>
        /// shots / hits;
        /// </summary>
        public float Accuracy;

        /// <summary>
        /// The amount of times the player has been hit.
        /// </summary>
        public float SelfHits;

        /// <summary>
        /// The amount of damage the player has taken.
        /// </summary>
        public float DamageTaken;

        /// <summary>
        /// The amount of times the player has dashed
        /// </summary>
        public float Dashes;

        /// <summary>
        /// The amount of times the player has used a jump pad.
        /// </summary>
        public float JumppadsTaken;
    }
}