using UnityEngine;
using GroepC.Player;

namespace GroepC.Interactable
{
    /// <summary>
    /// The base for environment interactables.
    /// </summary>
    public class Interactable : MonoBehaviour
    {
        /// <summary>
        /// Tells us when we enter a trigger hitbox. Activates <see cref="Interact(Collider)"/> when its the player.
        /// </summary>
        /// <param name="collider">The object that collides with the trigger.</param>
        private void OnTriggerEnter(Collider collider)
        {
            PlayerController player = collider.GetComponent<PlayerController>();
            if (player != null)
                Interact(player);
        }

        /// <summary>
        /// Base function for child classes that tells them the player hit this hitbox.
        /// </summary>
        /// <param name="player">The player collider.</param>
        protected virtual void Interact(PlayerController player) { }
    }
}
