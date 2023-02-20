using GroepC.Managers;
using System.Collections;
using UnityEngine;

namespace GroepC.EnemyHealth
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
        /// Death Function that will be called from the base.
        /// </summary>
        public override void Death()
		{
			StartCoroutine(PlayEnemyDeath());
		}

		/// <summary>
		/// Animation player that will drop ammo when animation isplayed and then destroy the object holder.
		/// </summary>
		/// <returns></returns>
		private IEnumerator PlayEnemyDeath()
		{
			//enables ragdoll
			yield return new WaitForSeconds(destroyTimer);
			DropManager.Instance.DropAmmo(transform.position);
			Destroy(gameObject);
		}
	}
}