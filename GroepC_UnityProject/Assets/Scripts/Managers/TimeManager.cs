using UnityEngine;

namespace GroepC.Managers
{
    /// <summary>
    /// This class controls the time inside the game.
    /// </summary>
    public class TimeManager : MonoBehaviour
    {
        public static TimeManager Instance;

        /// <summary>
        /// The current time in hour/minute/second
        /// </summary>
        private Vector3 currenTimeValues;

        /// <summary>
        /// The current time in hour/minute/second
        /// </summary>
        public Vector3 Time => currenTimeValues;

        /// <summary>
        /// The start amount of points.
        /// </summary>
        [SerializeField] private float endlessPoints = 100;

        /// <summary>
        /// The decrease amount to reduce the point, get multiplied by minutes ingame.
        /// </summary>
        [SerializeField] private float startDecreaseValue = 1;

        /// <summary>
        /// The amount of points the player has left.
        /// </summary>
        public float EndlessPoints => endlessPoints;

        /// <summary>
        /// Sets te instance of this class.
        /// </summary>
        private void Awake() => Instance = this;

        /// <summary>
        /// Adds time each frame.
        /// </summary>
        private void Update()
        {
            if (GameManager.Instance.SelectGamemode == GameModes.timed)
                AddTime();
            else
                DecreaseEndlessPoints();
        }

        /// <summary>
        /// Adds time and calculates the minutes/hours.
        /// </summary>
        private void AddTime()
        {
            currenTimeValues.z += UnityEngine.Time.deltaTime;
            if (currenTimeValues.z > 60)
            {
                currenTimeValues.z = 0;
                currenTimeValues.y++;
                if(currenTimeValues.y > 60)
                {
                    currenTimeValues.z = 0;
                    currenTimeValues.x++;
                }
            }
        }

        private void DecreaseEndlessPoints()
        {
            float endlessDecreaseValue = startDecreaseValue * (Time.y * .1f);
            endlessPoints -= endlessDecreaseValue * UnityEngine.Time.deltaTime;
        }
    }
}