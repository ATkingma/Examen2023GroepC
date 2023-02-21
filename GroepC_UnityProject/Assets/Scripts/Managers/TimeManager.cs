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
        /// The object that displays the amount of points left.
        /// </summary>
        private TextMeshProUGUI endlessValueObjectText;

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
        /// Grants the UI objects to this class.
        /// </summary>
        /// <param name="player">The player that contains the UI objects.</param>
        public void GiveUI(PlayerController player)
        {
            timeObjectText = player.TimeObjectText;
            endlessValueObjectText = player.EndlessValueObjectText;
        }

        /// <summary>
        /// Adds time each frame.
        /// </summary>
        private void Update()
        {
            AddTime();
            if (GameManager.Instance.SelectGamemode == GameModes.endless)
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
            UpdateTimeObject();
        }

        /// <summary>
        /// decreases points for the endless mode.
        /// </summary>
        private void DecreaseEndlessPoints()
        {
            float endlessDecreaseValue = startDecreaseValue * (1 + Time.y * .1f);
            endlessPoints -= endlessDecreaseValue * UnityEngine.Time.deltaTime;
            UpdateEndlessPoints();
        }

        /// <summary>
        /// Adds points to the endless points.
        /// </summary>
        /// <param name="addAmount">The amount to add.</param>
        public void AddEndlessPoints(float addAmount) => endlessPoints += addAmount;

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

        /// <summary>
        /// Sets the endlessPoints to the UI of the player.
        /// </summary>
        private void UpdateEndlessPoints() => endlessValueObjectText.text = Mathf.Round(Mathf.Clamp(endlessPoints, 0, Mathf.Infinity)).ToString();
    }
}