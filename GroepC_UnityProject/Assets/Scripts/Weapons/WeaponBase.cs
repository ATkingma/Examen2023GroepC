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
        /// The type of the weapon.
        /// </summary>
        public WeaponType WeaponId;

        /// <summary>
        /// Holds the model for the weapon.
        /// </summary>
        public GameObject ModelPrefab;

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
        public int ClipSize;

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

        /// <summary>
        /// The maximum amount of ammo that can be carried.
        /// </summary>
        public int AmmoCarrySize;

        /// <summary>
        /// The current amount of ammo for this weapon.
        /// </summary>
        public int AmmoAmount;

        /// <summary>
        /// Sets the current ammo to max.
        /// </summary>
        private void OnEnable() => CurrentAmmo = ClipSize;
    }

    /// <summary>
    /// The amount of different weapons, used for picking the weapon up.
    /// </summary>
    public enum WeaponType
    {
        pistol,
        assaultRifle,
        shotgun,
        sniper,
        all,
    }
}