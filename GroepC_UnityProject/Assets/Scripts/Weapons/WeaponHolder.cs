using UnityEngine;
using System.Collections;
using GroepC.Player;
using TMPro;

namespace GroepC.Weapons
{
    /// <summary>
    /// Holds the current weapon that the player uses.
    /// </summary>
    public class WeaponHolder : MonoBehaviour
    {
        /// <summary>
        /// Reference to the player cotroller.
        /// </summary>
        private TextMeshProUGUI ammoText;

        /// <summary>
        /// The start weapon: <see cref="WeaponBase"/>.
        /// </summary>
        [SerializeField] private WeaponBase weapon;

        /// <summary>
        /// The projectile to spawn as bullet.
        /// </summary>
        [SerializeField] private Rigidbody projectilePrefab;
        
        /// <summary>
        /// The spawn location.
        /// </summary>
        [SerializeField] private Transform projectileOrigin;

        /// <summary>
        /// The parent for the weapons.
        /// </summary>
        [SerializeField] private Transform WeaponParent;

        /// <summary>
        /// The audio source of the current weapon.
        /// </summary>
        [SerializeField] private AudioSource weaponAudioSource;

        /// <summary>
        /// The cooldown for shooting.
        /// </summary>
        private float cooldown;

        /// <summary>
        /// The time when the next shot may be fired.
        /// </summary>
        private float nextShot;
        
        /// <summary>
        /// The cooldown based on the firerate of the weapon.
        /// </summary>
        private float Cooldown => 1 / weapon.FireRate;

        /// <summary>
        /// Gets the player controller.
        /// </summary>
        private void Awake() => ammoText = GetComponentInParent<PlayerController>().AmmoText;

        /// <summary>
        /// Sets a new <see cref="WeaponBase"/>. Removes old weapon model and places the new one.
        /// </summary>
        /// <param name="newWeapon">The new weapon to swap to.</param>
        public void SwapWeapon(WeaponBase newWeapon)
        {
            weapon = newWeapon;
            CalculateStats();

            foreach (Transform oldWeapon in WeaponParent)
                Destroy(oldWeapon.gameObject);

            GameObject newModel =  Instantiate(weapon.ModelPrefab, WeaponParent);
            weaponAudioSource = newModel.GetComponent<AudioSource>();

            projectileOrigin.transform.localPosition = weapon.ProjectileOrigin;
        }

        /// <summary>
        /// Sets the current cooldown for shooting.
        /// </summary>
        public void CalculateStats() => cooldown = Cooldown;

        /// <summary>
        /// Checks if the next shot may be fired.
        /// </summary>
        public void Fire()
        {
            if(Time.time > nextShot && weapon.CurrentAmmo > 0)
            {
                nextShot = Time.time + cooldown;
                FireProjectile();
                ammoText.text = weapon.CurrentAmmo + "/" + weapon.MaxAmmo;
            }
            else
            {
                ReloadWeapon();
            }
        }

        /// <summary>
        /// Reloads the weapon.
        /// </summary>
        /// <returns>Wait for the reload time.</returns>
        private IEnumerator ReloadWeapon()
        {
            yield return new WaitForSeconds(weapon.ReloadTime);
            weapon.CurrentAmmo = weapon.MaxAmmo;
        }

        /// <summary>
        /// Fires a projectile from the <see cref="projectileOrigin"/>.
        /// </summary>
        private void FireProjectile()
        {
            if(projectilePrefab != null)
            {
                weaponAudioSource.Play();

                int projectileCount = 1 + weapon.ExtraProjectiles;
                Vector3 spawnPosition = projectileOrigin.position;
                Quaternion spawnRotation = transform.rotation;

                float velocity = weapon.Velocity;
                float angle = weapon.ProjectileSpread;

                for (int i = 0; i < projectileCount; i++)
                {
                    float playerYRotation = (float)(Mathf.Atan2(spawnRotation.y, spawnRotation.w) / Mathf.PI) * 360;
                    if (playerYRotation > 180)
                        playerYRotation -= 360;

                    float playerXRotation = (float)(Mathf.Atan2(spawnRotation.x, spawnRotation.w) / Mathf.PI) * 360;
                    if (playerXRotation > 180)
                        playerXRotation -= 360;

                    float spreadY = Random.Range(-angle, angle);
                    float spreadX = Random.Range(-angle, angle);

                    // ook nog omhoog
                    Quaternion randomRotation = Quaternion.Euler(new Vector3(playerXRotation + spreadX, playerYRotation + spreadY, 0));

                    Rigidbody spawnedProjectile = Instantiate(projectilePrefab, spawnPosition, randomRotation);
                    Vector3 dir = spawnedProjectile.transform.forward;

                    spawnedProjectile.velocity = dir * velocity;
                    spawnedProjectile.GetComponent<Projectile>().Setup(weapon.Damage);
                }
            }
        }
    }
}