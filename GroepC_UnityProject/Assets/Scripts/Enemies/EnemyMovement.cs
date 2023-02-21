using GroepC.Player;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

namespace GroepC.Enemies
{
	/// <summary>
	/// Movement of the enemy.
	/// </summary>
	public class EnemyMovement : MonoBehaviour
	{
		/// <summary>
		/// Navmesh agent of the Enemy.
		/// </summary>
		[SerializeField]
		private NavMeshAgent agent;

		/// <summary>
		/// An animator this will control the animations with parameters that will be called within the code.
		/// </summary>
		[SerializeField]
		private Animator animator;

		/// <summary>
		/// The damage amount the enemy can do.
		/// </summary>
		[SerializeField]
		private float damage;

		/// <summary>
		/// The range of the Enemy where an attack can be started.
		/// </summary>
        [SerializeField]
		private float attackRange;

		/// <summary>
		/// The min speed the agent can move;
		/// </summary>
		[SerializeField]
		private float minSpeed = 3.5f;

        /// <summary>
        /// The max speed the agent can move;
        /// </summary>
        [SerializeField]
		private float maxSpeed = 5f;

		/// <summary>
		/// Lookspeed that amount of speed the enemy may rotate.
		/// </summary>
		[SerializeField]
		private float lookSpeed = 5.5f;

		/// <summary>
		/// Distance before it stops in front of the target.
		/// </summary>
		[SerializeField]
		private float stoppingDistance =3f;

		/// <summary>
		/// The target of the Enemy.
		/// </summary>
		[SerializeField]
		private GameObject target;

		/// <summary>
		/// The time after the attack, This can be used to let the enemy wait an few sec before attacking again.
		/// </summary>
		[SerializeField]
		private float attackCooldown;

		[SerializeField]
		private Vector3 attackSize;

		[SerializeField]
		private Transform attackPosition;

        public LayerMask m_LayerMask;

        /// <summary>
        /// Can be triggert in the future is an bool that keeps track if the enemy may move to the target.
        /// </summary>
        private bool goToTarget;

		/// <summary>
		/// Can be triggert if the bool is attacking.
		/// </summary>
		private bool isAttacking;


		/// <summary>
		/// Can be trigger for checking an boxcollider for the player and doing damage after.
		/// </summary>
		private bool checkCollider;

        /// <summary>
        /// An random range that is given at the awake.
        /// </summary>
        private float speed;

		/// <summary>
		/// Sets the speed at a random value.
		/// </summary>
        private void Awake() => speed = UnityEngine.Random.Range(minSpeed, maxSpeed);

		/// <summary>
		/// Sets the agent speed, and ready to move.
		/// </summary>
		private void Start()
		{
			goToTarget = true;
			agent.speed = speed;
		}

		/// <summary>
		/// Makes the agent move towards the target.
		/// </summary>
		private void Update()
		{
			if (goToTarget)
			{
				float distance = Vector3.Distance(transform.position, target.transform.position);
				if (distance <= attackRange && !isAttacking)
					Attack();


				if (distance > stoppingDistance)
					agent.destination = target.transform.position;
				else
					agent.destination = transform.position;

				Ray lookRay = new Ray(transform.position, target.transform.position - transform.position);
				float lookDist = Vector3.Distance(transform.position, target.transform.position);

				if (Physics.Raycast(lookRay, out RaycastHit hit, lookDist))
				{
					if (hit.transform == target.transform)
					{
						LookAtTarget(target.transform.position);
					}
				}

                if (isAttacking&&checkCollider)
                {
					MyCollisions();
                }
			}
		}

		public void EnableAttacking()
		{
			isAttacking = true;
			checkCollider = true;
        }

        public void DisableAttacking()
        {
			StartCoroutine(CoolDown());
        }

        private void Attack()
		{
			animator.SetBool("Attack", true);
            animator.SetBool("Walk", false);
        }

		IEnumerator CoolDown()
		{
            animator.SetBool("Walk", true);
            animator.SetBool("Attack", false);
			checkCollider = false;
            yield return new WaitForSeconds(attackCooldown);
            isAttacking = false;
		}

        void MyCollisions()
        {
            Collider[] hitColliders = Physics.OverlapBox(attackPosition.position, attackSize,quaternion.identity, m_LayerMask);
            if(0 < hitColliders.Length)
            {
				Debug.Log("hit");
				DoDamage();
            }
        }

		private void DoDamage()
		{
			checkCollider = false;
            StartCoroutine(CoolDown());
			target.GetComponent<PlayerHealth>().DoDamage(damage);
        }

        /// <summary>
        /// Function that slerps to the lookPosition.
        /// </summary>
        /// <param name="lookPosition">The position to look at.</param>
        private void LookAtTarget(Vector3 lookPosition)
		{
			lookPosition.y = transform.position.y;
			Quaternion targetRotation = Quaternion.LookRotation(lookPosition - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookSpeed * Time.deltaTime);
		}

		/// <summary>
		/// Sets an new target for the EnemyMovement Class.
		/// </summary>
		/// <param name="newTarget">Is the new target.</param>
        public void SetTarget(GameObject newTarget) => target = newTarget;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(attackPosition.position, attackSize);
        }
    }
}
