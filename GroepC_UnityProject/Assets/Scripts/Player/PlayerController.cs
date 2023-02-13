using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GroepC
{
    /// <summary>
    /// This class controls the player. It is used to connect the <see cref="CharacterController"/> for the player.
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        /// <summary>
        /// The <see cref="CharacterController"/> used for the player.
        /// </summary>
        [SerializeField] private CharacterController controller;

        /// <summary>
        /// The speed multiplier for the movement.
        /// </summary>
        [SerializeField] private float movementSpeed;

        /// <summary>
        /// This update is used to call the movement for the player.
        /// </summary>
        private void Update() => ApplyMovement();

        /// <summary>
        /// Calculates the movement direction based on the player input.
        /// </summary>
        /// <returns>The calculated movement direction based on player input.</returns>
        private Vector3 CalculateMovement() => new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vectical"));

        /// <summary>
        /// Applies the movement onto the <see cref="CharacterController"/>.
        /// </summary>
        private void ApplyMovement()
        {
            Vector3 direction = CalculateMovement();
            direction.Normalize();
            direction *= movementSpeed;
            direction *= Time.deltaTime;
            controller.Move(direction);
        }
    }
}