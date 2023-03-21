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
        /// Controls the animations of the weapon model.
        /// </summary>
        [SerializeField] private Animator weaponAnimator;

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
        /// States the state of the reload.
        /// </summary>
        private bool reload;

        /// <summary>
        /// Gets the player controller.
        /// </summary>
        private void Awake() => ammoText = GetComponentInParent<PlayerController>().AmmoText;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.R) && !reload)
                StartCoroutine(ReloadWeapon());

            //WeaponParent.transform.rotation = Quaternion.Lerp(transform.rotation, WeaponParent.transform.rotation, .5f);
        }

        /// <summary>
        /// Sets a new <see cref="WeaponBase"/>. Removes old weapon model and places the new one.
        /// </summary>
        /// <param name="newWeapon">The new weapon to swap to.</param>
        public void SwapWeapon(WeaponBase newWeapon)
        {
            CancelReload();
            if (newWeapon == null)
                return;

            weapon = newWeapon;
            CalculateStats();

            foreach (Transform oldWeapon in WeaponParent)
                Destroy(oldWeapon.gameObject);

            GameObject newModel =  Instantiate(weapon.ModelPrefab, WeaponParent);
            weaponAudioSource = newModel.GetComponent<AudioSource>();
            weaponAnimator = newModel.GetComponent<Animator>();
            weaponAnimator.SetFloat("ReloadTime", 1 / weapon.ReloadTime);

            projectileOrigin.transform.localPosition = weapon.ProjectileOrigin;
            UpdateAmmoText();
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
            if(Time.time > nextShot)
            {
                if (weapon.CurrentAmmo > 0 && !reload)
                {
                    nextShot = Time.time + cooldown;
                    FireProjectile();
                    weapon.CurrentAmmo--;
                    UpdateAmmoText();
                    ApplyRecoil();
                    if (weapon.CurrentAmmo == 0)
                        StartCoroutine(ReloadWeapon());
                }
                else if (!reload)
                {
                    StartCoroutine(ReloadWeapon());
                }
            }
        }

        /// <summary>
        /// Makes the weapon wiggle when shooting.
        /// </summary>
        private void ApplyRecoil()
        {
            float playerYRotation = (float)(Mathf.Atan2(transform.rotation.y, transform.rotation.w) / Mathf.PI) * 360;
            if (playerYRotation > 180)
                playerYRotation -= 360;

            float playerXRotation = (float)(Mathf.Atan2(transform.rotation.x, transform.rotation.w) / Mathf.PI) * 360;
            if (playerXRotation > 180)
                playerXRotation -= 360;

            float playerZXRotation = (float)(Mathf.Atan2(transform.rotation.z, transform.rotation.w) / Mathf.PI) * 360;
            if (playerXRotation > 180)
                playerXRotation -= 360;

            float spread = Random.Range(-1, 1);

            Quaternion randomRotation = Quaternion.Euler(new Vector3(playerXRotation + spread, playerYRotation, playerZXRotation));
            //WeaponParent.transform.rotation = randomRotation;
        }

        /// <summary>
        /// Updates the ammo text.
        /// </summary>
        private void UpdateAmmoText() => ammoText.text = weapon.CurrentAmmo + "/" + weapon.MaxAmmo;

        /// <summary>
        /// Reloads the weapon.
        /// </summary>
        /// <returns>Wait for the reload time.</returns>
        private IEnumerator ReloadWeapon()
        {
            reload = true;
            weaponAnimator.enabled = true;
            weaponAnimator.SetInteger("Random", Random.Range(0,6));
            weaponAnimator.SetTrigger("Reload");
            yield return new WaitForSeconds(weapon.ReloadTime);
            weapon.CurrentAmmo = weapon.MaxAmmo;
            UpdateAmmoText();
            reload = false;
            weaponAnimator.ResetTrigger("Reload");
            weaponAnimator.enabled = false;
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
                    Quaternion randomRotation = Quaternion.Euler(new Vector3(playerXRotation + spreadX, playerYRotation + spreadY, 0));

                    Rigidbody spawnedProjectile = Instantiate(projectilePrefab, spawnPosition, randomRotation);
                    Vector3 dir = spawnedProjectile.transform.forward;

                    spawnedProjectile.velocity = dir * velocity;
                    spawnedProjectile.GetComponent<Projectile>().Setup(weapon.Damage);
                }
            }
        }

        /// <summary>
        /// Cancels the reload.
        /// </summary>
        private void CancelReload() => StopCoroutine(ReloadWeapon());
    }
}