using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using GroepC.Managers;

namespace GroepC.UI
{
    /// <summary>
    /// Class that manages the ingamemenu this is an menu for inside the gamemode.
    /// </summary>
    public class InGameMenu : MonoBehaviour
    {
        /// <summary>
        /// Menu object is the full menu that will be enabled and disabled.
        /// </summary>
        [SerializeField]
        private GameObject menuObject;

        /// <summary>
        /// Contains the score of the player.
        /// </summary>
        [SerializeField]
        private GameObject scoreboardObject;

        /// <summary>
        /// Main panel that will be enabled when the menu is closed.
        /// </summary>
        [SerializeField]
        private GameObject mainPanel;

        /// <summary>
        /// Al the panels inside of the ingamemenu.
        /// </summary>
        [SerializeField]
        private List<GameObject> panels;

        /// <summary>
        /// Adds opening the menu to the esc button.
        /// </summary>
        private void OnEnable()
        {
            GameManager.Instance.MenuOpened += ToggleMenu;
            GameManager.Instance.ScoreOpend += ToggleScoreBoard;
        }

        /// <summary>
        /// Removes opening the menu to the esc button.
        /// </summary>
        private void OnDisable()
        {
            GameManager.Instance.MenuOpened -= ToggleMenu;
            GameManager.Instance.ScoreOpend -= ToggleScoreBoard;
        }

        /// <summary>
        /// Toggles ingamemenu.
        /// </summary>
        private void ToggleMenu()
        {
            menuObject.SetActive(!menuObject.activeSelf);
            CheckMenuState();

            ResetPanels();
        }

        private void ToggleScoreBoard()
        {
            //get score en zet in scoreboard?
            scoreboardObject.SetActive(!scoreboardObject.activeSelf);
        }

        /// <summary>
        /// Checks the state of the menu and wil lock or unlock the mouse cursor and also set the timescale.
        /// </summary>
        public void CheckMenuState()
        {
            if (menuObject.activeInHierarchy)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        /// <summary>
        /// Reset game state resets the game time scale and curssor mode.
        /// </summary>
        public void ResetGameState()
        {
            menuObject.SetActive(!menuObject.activeSelf);
            GameManager.Instance.MenuOpened.Invoke();
        }

        /// <summary>
        /// Resets al the panels and enables main panel.
        /// </summary>
        private void ResetPanels()
        {
            for (int i = 0; i < panels.Count; i++)
            {
                panels[i].SetActive(false); 
            }

            mainPanel.SetActive(true);
        }
    }
}