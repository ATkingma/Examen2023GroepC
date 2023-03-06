using GroepC.Player;
using UnityEngine;

namespace GroepC.Interactables
{
    /// <summary>
    /// Makes the player jump upwards when entering the trigger area.
    /// </summary>
    public class JumpPad : Interactable
    {
        [SerializeField] private float jumpPower = 10;

        /// <summary>
        /// Activates the jump pad.
        /// </summary>
        /// <param name="player">The player controller.</param>
        protected override void Interact(PlayerController player) => player.SetJumpPower(jumpPower);
    }
}