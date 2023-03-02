using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace GroepC.UI
{
    public class InGameMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject menuObject;

        [SerializeField]
        private GameObject mainPanel;

        [SerializeField]
        private List<GameObject> panels;

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                ToggleMenu();
            }
        }

        private void ToggleMenu()
        {
            menuObject.SetActive(!menuObject.active);
            CheckMenuState();

            ResetPanels();
        }

        public void CheckMenuState()
        {
            if (menuObject.activeInHierarchy)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        public void ResetGameState()
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.None;
        }

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