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
        /// The camera used for the player.
        /// </summary>
        [SerializeField] private Camera playerCamera;

        /// <summary>
        /// Determents the speed of the camera.
        /// </summary>
        [SerializeField] private float cameraSensitivity;

        /// <summary>
        /// The limit on how far you can look up/down.
        /// </summary>
        [SerializeField] private float yRotationLimit;

        /// <summary>
        /// The current look direction.
        /// </summary>
        private Vector3 lookRotation;

        /// <summary>
        /// The speed multiplier for the movement.
        /// </summary>
        [SerializeField] private float movementSpeed;

        /// <summary>
        /// The amount of gravity applied each second.
        /// </summary>
        [SerializeField] private float gravity;

        /// <summary>
        /// The amount of down force the player gets, gets stronger based on how long in air.
        /// </summary>
        private float downForce;

        /// <summary>
        /// This update is used to call the movement for the player.
        /// </summary>
        private void Update()
        {
            RotateCamera();
            ApplyMovement();
        }

        /// <summary>
        /// Calculates the movement direction based on the player input.
        /// </summary>
        /// <returns>The calculated movement direction based on player input.</returns>
        private Vector3 CalculateMovement() => playerCamera.transform.rotation * new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        /// <summary>
        /// Applies the gravity to the player.
        /// </summary>
        /// <returns>Gravity when not on the ground.</returns>
        private float ApplyGravity()
        {
            if(!controller.isGrounded)
                return downForce -= gravity * Time.deltaTime;
            return downForce = -1f * Time.deltaTime;
        }

        /// <summary>
        /// Rotates the camera according to the mouse.
        /// </summary>
        private void RotateCamera()
        {
            Transform cameraTransform = playerCamera.transform;

            lookRotation.x += Input.GetAxis("Mouse X") * cameraSensitivity;
            lookRotation.y += Input.GetAxis("Mouse Y") * cameraSensitivity;
            lookRotation.y = Mathf.Clamp(lookRotation.y, -yRotationLimit, yRotationLimit);
            Quaternion xQuat = Quaternion.AngleAxis(lookRotation.x, Vector3.up);
            Quaternion yQuat = Quaternion.AngleAxis(lookRotation.y, Vector3.left);

            cameraTransform.localRotation = xQuat * yQuat;
        }

        /// <summary>
        /// Applies the movement onto the <see cref="CharacterController"/>.
        /// </summary>
        private void ApplyMovement()
        {
            Vector3 direction = CalculateMovement();
            direction.Normalize();
            direction.y = ApplyGravity();
            direction *= movementSpeed;
            direction *= Time.deltaTime;
            controller.Move(direction);
        }
    }
}