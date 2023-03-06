using UnityEngine;

namespace GroepC.Weapons
{
    /// <summary>
    /// This class holds the basic stats for a weapon.
    /// </summary>
    [CreateAssetMenu(fileName = "WeaponsBase", menuName = "Weapons/Base")]
    public class WeaponBase : ScriptableObject
    {
        /// <summary>
        /// Holds the model for the weapon.
        /// </summary>
        public GameObject modelPrefab;

        /// <summary>
        /// The amount of bullets the weapon will shoot per second.
        /// </summary>
        public float FireRate;

        /// <summary>
        /// The damage amount of the weapon.
        /// </summary>
        public float Damage;

        /// <summary>
        /// The time it will take to reload the weapon.
        /// </summary>
        public float ReloadTime;

        /// <summary>
        /// The max amount of ammo the weapon can hold in one magazine.
        /// </summary>
        public int MaxAmmo;

        /// <summary>
        /// the current ammo of the held gun.
        /// </summary>
        public int CurrentAmmo;

        /// <summary>
        /// The speed of the projectiles.
        /// </summary>
        public float Velocity;

        /// <summary>
        /// The spawn location for the projectiles.
        /// </summary>
        public Vector3 ProjectileOrigin;

        /// <summary>
        /// The amount of extra projectiles, total = 1 + <see cref="ExtraProjectiles"/>.
        /// </summary>
        public int ExtraProjectiles;

        /// <summary>
        /// The amount of spread the projectile(s) will have.
        /// </summary>
        public float ProjectileSpread;
    }
}