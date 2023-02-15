using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GroepC.Weapons
{
    /// <summary>
    /// Apply this to the objects that needs to have a sway effect based on the mouse movement.
    /// </summary>
    public class WeaponSway : MonoBehaviour
    {
        /// <summary>
        /// The smoothes of the sway.
        /// </summary>
        [SerializeField] private float smooth = 10;

        /// <summary>
        /// How hard the sway will move.
        /// </summary>
        [SerializeField] private float multiplier = 5;

        /// <summary>
        /// <see cref="Sway"/>.
        /// </summary>
        private void Update() => Sway();

        /// <summary>
        /// Makes the weapon have a sway effect.
        /// </summary>
        private void Sway()
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * multiplier;
            float mouseY = Input.GetAxisRaw("Mouse Y") * multiplier;

            Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
            Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

            Quaternion targetRotation = rotationX * rotationY;

            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
        }
    }
}
