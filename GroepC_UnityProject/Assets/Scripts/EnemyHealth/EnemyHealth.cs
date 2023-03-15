using GroepC.Managers;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace GroepC.Enemies
{
    /// <summary>
    /// Health of the enemy that will be walking.
    /// </summary>
    public class EnemyHealth : EnemyHealthBase
	{

        /// <summary>
        /// The behavior of the enemy where the movement is assigned;
        /// </summary>
        [SerializeField]
        private EnemyMovement enemyMovement;
        /// <summary>
        /// Agent that is attached to the enemy.
        /// </summary>
        [SerializeField]
        private NavMeshAgent agent;
        /// <summary>
        /// Animator of the enemy.
        /// </summary>
        [SerializeField]
        private Animator anim;

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
        /// The hit audio that will be called when the enemy is hit.
        /// </summary>
        [SerializeField]
        private AudioSource hitAudio;

        /// <summary>
        /// Dying sound will be played when the enemy dies.
        /// </summary>
        [SerializeField]
        private AudioSource dyingAudio;

        /// <summary>
        /// The collider that needs to be disabled after an enemy dying.
        /// </summary>
        [SerializeField]
        private BoxCollider enemyCollider;

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
            enemyCollider.enabled= false;
            baseEnemy.SetActive(false);
            enemyMovement.enabled = false;
            agent.destination = transform.position;
            ragdollObject.SetActive(true);
            dyingAudio.Play();
            ScoreManager.Instance.AddScore(1);
			yield return new WaitForSeconds(destroyTimer);
			DropManager.Instance.DropAmmo(transform.position);
			Destroy(gameObject);
		}

        /// <summary>
        /// Subtracks the damage from the current health
        /// </summary>
        /// <param name="_damage"></param>
        public override void DoDamage(float _damage)
        {
            base.DoDamage(_damage);
            if (!hitAudio.isPlaying)
                hitAudio.Play();
            anim.SetTrigger("Hit");
        }
    }
}