using GroepC.Managers;
using System.Collections;
using UnityEngine;

namespace GroepC.Enemies
{
    /// <summary>
    /// Health of the enemy that will be walking.
    /// </summary>
    public class EnemyHealth : EnemyHealthBase
	{
		/// <summary>
		/// The time that will be waited for the object to be destroyed after dying.
		/// </summary>
        [SerializeField]
        private float destroyTimer;

        /// <summary>
        /// The ragdol of the enemy that will be enabled on death.
        /// </summary>
        [SerializeField]
        private GameObject ragdollObject;

        /// <summary>
        /// The ragdol of the enemy that will be enabled on death.
        /// </summary>
        [SerializeField]
        private GameObject baseEnemy;

        /// <summary>
        /// Death Function that will be called from the base.
        /// </summary>
        public override void Death() => StartCoroutine(PlayEnemyDeath());

		/// <summary>
		/// Animation player that will drop ammo when animation isplayed and then destroy the object holder.
		/// </summary>
		/// <returns></returns>
		private IEnumerator PlayEnemyDeath()
		{
			SpawnManager.Instance.RemoveEnemy(gameObject);
			baseEnemy.SetActive(false);
            ragdollObject.SetActive(true);
			yield return new WaitForSeconds(destroyTimer);
			DropManager.Instance.DropAmmo(transform.position);
			Destroy(gameObject);
		}
	}
}