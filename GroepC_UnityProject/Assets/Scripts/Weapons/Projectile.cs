using UnityEngine;
using GroepC.Enemies;
using System.Collections.Generic;

namespace GroepC.Weapons
{
    /// <summary>
    /// Projectile base class.
    /// </summary>
    public class Projectile : MonoBehaviour
    {
        /// <summary>
        /// The amount of damage.
        /// </summary>
        private float damageAmount;

        /// <summary>
        /// The layers of the things the projectile can hit.
        /// </summary>
        [SerializeField] private string[] hitTags;

        /// <summary>
        /// The different amount of hit particles, index should corrospond to the <see cref="hitTags"/>.
        /// </summary>
        [SerializeField] private List<GameObject> hitParticles;

        /// <summary>
        /// For now, destroys the projectile after 1 second.
        /// </summary>
        private void OnEnable() => Destroy(gameObject, 1);

        /// <summary>
        /// Sets the damage for the projectile.
        /// </summary>
        /// <param name="damage">The amount of damage the projectile does.</param>
        public void Setup(float damage) => damageAmount = damage;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(hitTags[0]))
            {
                if (collision.transform.GetComponent<EnemyHealthBase>())
                    collision.transform.GetComponent<EnemyHealthBase>().DoDamage(damageAmount);
                // enemy particle hit.
                Instantiate(hitParticles[0]);
            }
            else 
            {
                // wall particle
                Instantiate(hitParticles[1]);
            }
            Destroy(gameObject);
        }
    }
}