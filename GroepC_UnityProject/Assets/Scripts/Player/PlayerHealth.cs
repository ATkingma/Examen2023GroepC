using GroepC.Managers;
using UnityEngine;

namespace GroepC.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        /// <summary>
        /// The player max health.
        /// </summary>
        [SerializeField] private float maxHealth;

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

            currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, maxHealth);

            if (currentHealth == 0)
                Die();
        }
        
        /// <summary>
        /// Activates when the player health reaches 0.
        /// </summary>
        private void Die() => GameManager.Instance.EndGame();
    }
}