using UnityEngine;

namespace GroepC.Managers
{
    /// <summary>
    /// This class controls the time inside the game.
    /// </summary>
    public class TimeManager : MonoBehaviour
    {
        /// <summary>
        /// The current time in hour/minute/second
        /// </summary>
        private Vector3 currenTimeValues;

        /// <summary>
        /// The current time in hour/minute/second
        /// </summary>
        public Vector3 Time => currenTimeValues;

        /// <summary>
        /// Adds time each frame.
        /// </summary>
        private void Update() => AddTime();

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
    }
}