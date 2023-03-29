using GroepC.Managers;
using GroepC.Weapons;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        [SerializeField] private WeaponBase[] heldWeapons;

        /// <summary>
        /// The Image the holds the icons.
        /// </summary>
        [SerializeField] private Image ammoIconHolder;

        /// <summary>
        /// The Image the holds the icons.
        /// </summary>
        [SerializeField] private Image weaponsIconHolder;

        /// <summary>
        /// The icons for the ammo types.
        /// </summary>
        [SerializeField] private Sprite[] weaponAmmoIcons;
        
        /// <summary>
        /// The icons for the weapons.
        /// </summary>
        [SerializeField] private Sprite[] weaponIcons;

        /// <summary>
        /// Current held weapon;
        /// </summary>
        private float weaponNumber;

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
        private void Start()
        {
            if (heldWeapons.Length == 0)
                return;

            Swap(0);
            if(heldWeapons[0] != null)
                holder.CalculateStats();
        }

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
                    Swap(i);

            weaponNumber += Input.GetAxis("Mouse ScrollWheel") * 5;
            if (weaponNumber > 3)
                weaponNumber = 0;
            else if (weaponNumber < 0)
                weaponNumber = 3;

            if (Input.GetAxis("Mouse ScrollWheel") != 0)
                Swap((int)weaponNumber);
        }

        /// <summary>
        /// Swaps the currently held weapon for the given weapon id.
        /// </summary>
        /// <param name="newWeaponID">The new weapon to swap to.</param>
        private void Swap(int newWeaponID)
        {
            if(SaveManager.Instance.PlayerSaves != null)
                SaveManager.Instance.AddReload();

            holder.SwapWeapon(heldWeapons[newWeaponID]);

            if (heldWeapons[newWeaponID] != null)
            {
                ammoIconHolder.gameObject.SetActive(true);
                weaponsIconHolder.gameObject.SetActive(true);
                SetWeaponAmmoSprite(weaponAmmoIcons[newWeaponID]);
                SetWeaponSprite(weaponIcons[newWeaponID]);
            }
        }

        /// <summary>
        /// Sets the new weapons ammo sprite.
        /// </summary>
        /// <param name="newSprite">The sprite to set.</param>
        private void SetWeaponAmmoSprite(Sprite newSprite) => ammoIconHolder.sprite = newSprite;

        /// <summary>
        /// Sets the new weapons ammo sprite.
        /// </summary>
        /// <param name="newSprite">The sprite to set.</param>
        private void SetWeaponSprite(Sprite newSprite) => weaponsIconHolder.sprite = newSprite;

        /// <summary>
        /// Sets the weapon in the designed slot.
        /// </summary>
        /// <param name="weapon">The weapon to set.</param>
        /// <param name="type">The slot for the weapon type.</param>
        public void SetWeapon(WeaponBase weapon, WeaponType type) => heldWeapons[(int)type] = weapon;

        /// <summary>
        /// Gives Ammo to the weapon type.
        /// </summary>
        /// <param name="ammoType">The weapon to give ammo to.</param>
        /// <param name="ammoAmount">The amount of ammo.</param>
        public void GiveAmmo(WeaponType ammoType, int ammoAmount)
        {
            if (ammoType == WeaponType.all)
            {
                foreach (var item in heldWeapons)
                {
                    if(item != null)
                        item.AmmoAmount = Mathf.Clamp(item.AmmoAmount + ammoAmount, 0, item.AmmoCarrySize);
                }
                   
            }
            else
            {
                if(heldWeapons[(int)ammoType] != null)
                    heldWeapons[(int)ammoType].AmmoAmount = Mathf.Clamp(heldWeapons[(int)ammoType].AmmoAmount + ammoAmount, 0, heldWeapons[(int)ammoType].AmmoCarrySize);
            }
        }
    }
}