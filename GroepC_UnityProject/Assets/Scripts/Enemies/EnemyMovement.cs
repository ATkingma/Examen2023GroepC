using GroepC.Player;
using System.Collections;
using System.Collections.Generic;
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
		/// Can be triggert in the future is an bool that keeps track if the enemy may move to the target.
		/// </summary>
		private bool goToTarget;

		/// <summary>
		/// Can be triggert if the bool is attacking.
		/// </summary>
		private bool isAttacking;


		/// <summary>
		/// An random range that is given at the awake.
		/// </summary>
        private float speed;
        private void Awake()
        {
            speed = Random.Range(minSpeed, maxSpeed);	
        }
        private void Start()
		{
			goToTarget = true;
			agent.speed = speed;
		}

		private void Update()
		{
			if (goToTarget)
			{
				float distance = Vector3.Distance(transform.position, target.transform.position);
				if(distance<= attackRange&&!isAttacking)
				{
					StartCoroutine(Attack());
                }

				if (distance > stoppingDistance)
				{
					agent.destination = target.transform.position;
                }
				else
				{
					agent.destination = transform.position;
				}

                Ray ray = new Ray(transform.position, target.transform.position - transform.position);


                float maxDistance = Vector3.Distance(transform.position, target.transform.position);

                RaycastHit hit;

                // Perform the raycast
                if (Physics.Raycast(ray, out hit, maxDistance))
                {
                    // Check if the object hit by the ray is the target transform
                    if (hit.transform == target.transform)
                    {
                        LookAtTarget(target.transform.position);
						if (isAttacking)
						{
							target.GetComponent<PlayerHealth>().DoDamage(damage);
							isAttacking = false;
                        }
                    }
                }
            }
		}
		
		/// <summary>
		/// Function that slerps to the lookPosition.
		/// </summary>
		/// <param name="lookPosition"></param>
		private void LookAtTarget(Vector3 lookPosition)
		{
			lookPosition.y = transform.position.y;
			Quaternion targetRotation = Quaternion.LookRotation(lookPosition - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookSpeed * Time.deltaTime);
		}

		/// <summary>
		/// Lets the enemy attack and plays the animation.
		/// </summary>
		/// <returns></returns>
		private IEnumerator Attack()
		{
			animator.SetBool("Attack", true);
			isAttacking = true;
            AnimatorStateInfo animStateInfo = animator.GetCurrentAnimatorStateInfo(0);
            float NTime = animStateInfo.normalizedTime;
            yield return NTime > 1.0f;
            isAttacking = false;
        }

		/// <summary>
		/// Sets an new target for the EnemyMovement Class.
		/// </summary>
		/// <param name="newTarget">Is the new target.</param>
        public void SetTarget(GameObject newTarget)
        {
            target = newTarget;
        }
    }
}
