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
		/// Speed the agent may move.
		/// </summary>
		[SerializeField]
		private float speed = 3.5f;

		/// <summary>
		/// Lookspeed that amount of speed the enemy may rotate.
		/// </summary>
		[SerializeField]
		private float lookSpeed = 5.5f;

		/// <summary>
		/// Distance before it stops infront of the target.
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


		private void Start()
		{
			goToTarget = true;
			agent.speed = speed;
		}

		private void Update()
		{
			if (goToTarget)
			{
				if (Vector3.Distance(transform.position, target.transform.position)> stoppingDistance)
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
	}
}
