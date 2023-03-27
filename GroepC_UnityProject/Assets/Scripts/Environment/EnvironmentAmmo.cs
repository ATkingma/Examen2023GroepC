using GroepC.Player;
using GroepC.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GroepC.Interactables
{
    public class EnvironmentAmmo : Interactable
    {
        /// <summary>
        /// The type of weapon to give ammo to.
        /// </summary>
        [SerializeField] private WeaponType ammoType;

        /// <summary>
        /// The amount of ammo.
        /// </summary>
        [SerializeField] private int ammoAmount;

        /// <summary>
        /// Activates the jump pad.
        /// </summary>
        /// <param name="player">The player controller.</param>
        protected override void Interact(PlayerController player)
        {
            player.PickUpAmmo(ammoType, ammoAmount);
            Destroy(gameObject);
        }
    }
}