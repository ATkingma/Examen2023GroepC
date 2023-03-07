using System.Collections;
using UnityEngine;
using TMPro;
using GroepC.Weapons;

namespace GroepC.Player
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
        /// The <see cref="WeaponController"/> of the player.
        /// </summary>
        [SerializeField] private WeaponController holder;

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
        /// The speed of the dash.
        /// </summary>
        [SerializeField] private float dashSpeed;

        /// <summary>
        /// The amount of gravity applied each second.
        /// </summary>
        [SerializeField] private float gravity;

        /// <summary>
        /// The object that displays the amount of time left.
        /// </summary>
        [SerializeField] private TextMeshProUGUI timeObjectText;

        /// <summary>
        /// The text object that will display the score of the player.
        /// </summary>
        [SerializeField] private TextMeshProUGUI scoreObjectText;

        /// <summary>
        /// The ammo text, displays the current/max ammo.
        /// </summary>
        [SerializeField] private TextMeshProUGUI ammoText;

        /// <summary>
        /// The object that displays the amount of time left.
        /// </summary>
        public TextMeshProUGUI TimeObjectText => timeObjectText;

        /// <summary>
        /// The text object that will display the score of the player.
        /// </summary>
        public TextMeshProUGUI ScoreObjectText => scoreObjectText;

        /// <summary>
        /// The ammo text, displays the current/max ammo.
        /// </summary>
        public TextMeshProUGUI AmmoText => ammoText;

        /// <summary>
        /// The force on the y axis.
        /// </summary>
        private float downForce;

        /// <summary>
        /// The amount of down force the player gets, gets stronger based on how long in air.
        /// </summary>
        private bool isDashing;

        /// <summary>
        /// States when the player is jumping.
        /// </summary>
        private bool isJumping;

        /// <summary>
        /// The amount of jump power added when interacting with the jump pad.
        /// </summary>
        private float jumpPower;

        /// <summary>
        /// The cooldown of the dash.
        /// </summary>
        [SerializeField] private float cooldown = .1f;

        /// <summary>
        /// The time when dashing is allowed again.
        /// </summary>
        private float nextDash;

        /// <summary>
        /// Turns off the cursor.
        /// </summary>
        private void Awake()
        {
            Cursor.visible = false;
            Cursor.lockState= CursorLockMode.Locked;
            holder = GetComponentInChildren<WeaponController>();
        }

        /// <summary>
        /// This update is used to call the movement for the player.
        /// </summary>
        private void Update()
        {
            RotateCamera();
            StartCoroutine(Dash());
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
            if (!controller.isGrounded)
                downForce -= gravity * Time.deltaTime;
            else
                downForce = -.1f;

            if (isJumping)
            {
                downForce += jumpPower;
                isJumping = false;
            }

            return downForce;
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
        /// Handles dashing when pressing leftshift/space.
        /// </summary>
        /// <returns>Waits for .1 sec to reset the cooldown.</returns>
        private IEnumerator Dash()
        {
            if(Input.GetButtonDown("Dash") && Time.time > nextDash)
            {
                nextDash = Time.time + cooldown;

                isDashing = true;
                yield return new WaitForSeconds(.1f);
                isDashing = false;
            }
        }

        /// <summary>
        /// The direction of the player
        /// </summary>
        Vector3 direction;

        /// <summary>
        /// Applies the movement onto the <see cref="CharacterController"/>.
        /// </summary>
        private void ApplyMovement()
        {
            direction = CalculateMovement();
            direction.y = 0;
            direction.Normalize();
            direction *= movementSpeed;
            direction.y = ApplyGravity();
            direction *= Time.deltaTime;

            if(isDashing)
            {
                downForce = -.1f;
                direction.y = 0;
                direction *= dashSpeed;
            }

            controller.Move(direction);
        }

        /// <summary>
        /// Sets the jump power for the player.
        /// </summary>
        /// <param name="power">The amount of power for the jump.</param>
        public void SetJumpPower(float power)
        {
            jumpPower = power;
            isJumping = true;
        }

        /// <summary>
        /// Grants the weapon to the player.
        /// </summary>
        /// <param name="weapon">The weapon to give.</param>
        public void PickUpWeapon(WeaponBase weapon) => holder.SetWeapon(weapon, weapon.WeaponId);
    }
}