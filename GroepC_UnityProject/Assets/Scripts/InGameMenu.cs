using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            ResetPanels();
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