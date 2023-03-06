using GroepC.Interactables;
using GroepC.Player;
using GroepC.Weapons;
using UnityEngine;

namespace GroepC.Weapons
{
    public class EnvironmentWeapon : Interactable
    {
        [SerializeField] private WeaponBase droppedWeapon;

        /// <summary>
        /// Activates the jump pad.
        /// </summary>
        /// <param name="player">The player controller.</param>
        protected override void Interact(PlayerController player) => player.PickUpWeapon(droppedWeapon);        /// 
    }
}