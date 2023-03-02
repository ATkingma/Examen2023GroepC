using UnityEngine;
using TMPro;
using GroepC.Player;

namespace GroepC.Managers
{
    /// <summary>
    /// This class controls the time inside the game.
    /// </summary>
    public class TimeManager : MonoBehaviour
    {
        /// <summary>
        /// The object that displays the amount of time left.
        /// </summary>
        private TextMeshProUGUI timeObjectText;

        /// <summary>
        /// The instance of this class.
        /// </summary>
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
        /// Sets te instance of this class.
        /// </summary>
        private void Awake() => Instance = this;

        /// <summary>
        /// Grants the UI objects to this class.
        /// </summary>
        /// <param name="player">The player that contains the UI objects.</param>
        public void GiveUI(PlayerController player) => timeObjectText = player.TimeObjectText;

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
            UpdateTimeObject();
        }

        /// <summary>
        /// Sets the time to the UI of the player.
        /// </summary>
        private void UpdateTimeObject()
        {
            float seconds = Mathf.Round(currenTimeValues.z);
            string hourText = currenTimeValues.x > 9 ? currenTimeValues.x.ToString() : "0" + currenTimeValues.x;
            string minuteText = currenTimeValues.y > 9 ? currenTimeValues.y.ToString() : "0" + currenTimeValues.y;
            string secondText = seconds > 9 ? seconds.ToString() : "0" + seconds;
            string timeString = $"{hourText} : {minuteText} : {secondText}";
            timeObjectText.text = timeString;
        }
    }
}