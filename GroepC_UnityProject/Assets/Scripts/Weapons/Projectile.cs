using UnityEngine;
using GroepC.Enemies;

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
        /// For now, destroys the projectile after 1 second.
        /// </summary>
        //private void OnEnable() => Destroy(gameObject, 1);

        /// <summary>
        /// Sets the damage for the projectile.
        /// </summary>
        /// <param name="damage">The amount of damage the projectile does.</param>
        public void Setup(float damage) => damageAmount = damage;

        private void OnTriggerEnter(Collider other)
        {

            Debug.Log(other.transform.name);
            int count = hitTags.Length;
            for (int i = 0; i < count; i++)
                if (other.gameObject.CompareTag(hitTags[i]))
                    if (other.GetComponent<EnemyHealthBase>())
                        other.GetComponent<EnemyHealthBase>().DoDamage(damageAmount);
            //particle

        }
    }
}