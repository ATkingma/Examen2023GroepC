using GroepC.Managers;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using System.Collections;

namespace GroepC.Player
{
    /// <summary>
    /// Controls the player health.
    /// </summary>
    public class PlayerHealth : MonoBehaviour
    {
        /// <summary>
        /// Controls the blood amount on the screen.
        /// </summary>
        [SerializeField] private Volume volume; 

        /// <summary>
        /// The player healthbar.
        /// </summary>
        [SerializeField] private Slider healthBar;

        /// <summary>
        /// The player max health.
        /// </summary>
        [SerializeField] private float maxHealth;

        /// <summary>
        /// End scoreBord
        /// </summary>
        [SerializeField] private GameObject endScorebord;

        /// <summary>
        /// camera that wil be enalbed when dying.
        /// </summary>
        [SerializeField] private GameObject deathCam;

        /// <summary>
        /// End scoreBord
        /// </summary>
        [SerializeField] private PlayerController controller;

        /// <summary>
        /// The current health of the player.
        /// </summary>
        private float currentHealth;

        /// <summary>
        /// Initializes the health script. Called when spawning in the player.
        /// </summary>
        public void Setup() => currentHealth = maxHealth;

        /// <summary>
        /// Makes the player take damage.
        /// </summary>
        /// <param name="damageAmount">The amount of damage the player will take.</param>
        public void DoDamage(float damageAmount)
        {
            if (currentHealth == 0)
                return;

            SaveManager.Instance.AddDamageTaken(damageAmount);
            currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, maxHealth);
            healthBar.value = currentHealth / maxHealth;

            if (currentHealth == 0)
                StartCoroutine(Die());
        }

        /// <summary>
        /// Regens life ddor the player overtime.
        /// </summary>
        private void Update() => RegenLife();

        /// <summary>
        /// Regens life for the player overtime;
        /// </summary>
        private void RegenLife()
        {
            if(currentHealth > 0 && currentHealth < maxHealth)
                currentHealth = Mathf.Clamp(currentHealth + 10 * Time.deltaTime, 0, maxHealth);

            UpdateBloodValue();
        }

        /// <summary>
        /// Updates the blood amount on th screen.
        /// </summary>
        private void UpdateBloodValue()
        {
            float bloodValue = 1 - (currentHealth / maxHealth - .2f);
            if (volume.profile.TryGet(out Vignette vignette))
                vignette.intensity.value = bloodValue;
        }

        /// <summary>
        /// Activates when the player health reaches 0.
        /// </summary>
        private IEnumerator Die()
        {
            deathCam.SetActive(true);
            CameraLerper.Instance.SetCameraObject(deathCam);
            controller.MenuOpened();
            endScorebord.SetActive(true);
            yield return new WaitForSeconds(10);
            SaveManager.Instance.AddDeath();
            GameManager.Instance.EndGame();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}