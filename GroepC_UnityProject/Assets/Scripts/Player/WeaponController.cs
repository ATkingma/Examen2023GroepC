using GroepC.Weapons;
using System.Collections.Generic;
using UnityEngine;

namespace GroepC.Player
{
    /// <summary>
    /// This class will handle swapping weapons and the input for shooting.
    /// </summary>
    public class WeaponController : MonoBehaviour
    {
        /// <summary>
        /// The weapon holder.
        /// </summary>
        [SerializeField] private WeaponHolder holder;

        /// <summary>
        /// All held weapons.
        /// </summary>
        [SerializeField] private List<WeaponBase> heldWeapons;

        /// <summary>
        /// The amount of weapons to swap to.
        /// </summary>
        private readonly KeyCode[] numberKeys =
        {
            KeyCode.Alpha1,
            KeyCode.Alpha2,
            KeyCode.Alpha3,
            KeyCode.Alpha4,
        };

        /// <summary>
        /// Sets the weapon stats on startup.
        /// </summary>
        private void Start() => holder.CalculateStats();

        /// <summary>
        /// See: <see cref="CheckFire"/>.
        /// </summary>
        private void Update()
        {
            CheckSwapWeapons();
            CheckFire();
        }

        /// <summary>
        /// Checks the input for firing.
        /// </summary>
        private void CheckFire()
        {
            if(Input.GetButton("Fire1"))
                holder.Fire();
        }

        /// <summary>
        /// Checks the buttons 1,2,3,4 to swap weapons.
        /// </summary>
        private void CheckSwapWeapons()
        {
            int keyCount = numberKeys.Length;
            for (int i = 0; i < keyCount; i++)
                if (Input.GetKeyDown(numberKeys[i]))
                    holder.SwapWeapon(heldWeapons[i]);
        }
    }
}