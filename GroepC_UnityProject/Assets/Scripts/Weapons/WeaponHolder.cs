using UnityEngine;

namespace GroepC.Weapons
{
    /// <summary>
    /// Holds the current weapon that the player uses.
    /// </summary>
    public class WeaponHolder : MonoBehaviour
    {
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
        /// 
        /// </summary>
        [SerializeField] private Transform WeaponParent;

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
        /// Sets a new <see cref="WeaponBase"/>. Removes old weapon model and places the new one.
        /// </summary>
        /// <param name="newWeapon"></param>
        public void SwapWeapon(WeaponBase newWeapon)
        {
            weapon = newWeapon;
            CalculateStats();

            foreach (Transform oldWeapon in WeaponParent)
                Destroy(oldWeapon.gameObject);

            Instantiate(weapon.modelPrefab, WeaponParent);

            projectileOrigin.transform.localPosition = weapon.ProjectileOrigin;
        }

        /// <summary>
        /// Sets the current cooldown for shooting.
        /// </summary>
        public void CalculateStats()
        {
            cooldown = Cooldown;
        }

        /// <summary>
        /// Checks if the next shot may be fired.
        /// </summary>
        public void Fire()
        {
            if(Time.time > nextShot)
            {
                nextShot = Time.time + cooldown;
                FireProjectile();
            }
        }

        /// <summary>
        /// Fires a projectile from the <see cref="projectileOrigin"/>.
        /// </summary>
        private void FireProjectile()
        {
            if(projectilePrefab != null)
            {
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
                }
            }
        }
    }
}