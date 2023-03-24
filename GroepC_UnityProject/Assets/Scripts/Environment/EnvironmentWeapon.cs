using GroepC.Interactables;
using GroepC.Player;
using UnityEngine;

namespace GroepC.Weapons
{
    /// <summary>
    /// This class enables picking up weapons from the ground.
    /// </summary>
    public class EnvironmentWeapon : Interactable
    {
        /// <summary>
        /// The weapon to pick up.
        /// </summary>
        [SerializeField] private WeaponBase droppedWeapon;

        /// <summary>
        /// Picks up the <see cref="droppedWeapon"/>.
        /// </summary>
        /// <param name="player">The player controller.</param>
        protected override void Interact(PlayerController player)
        {
            player.PickUpWeapon(droppedWeapon);
            Destroy(gameObject);
        }
    }
}