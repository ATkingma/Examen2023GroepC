using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GroepC.Enemies
{
	public class EnemyMovement : MonoBehaviour
	{
		[SerializeField]
		private NavMeshAgent agent;

		[SerializeField]
		private float speed = 3.5f;

		[SerializeField]
		private float lookSpeed = 5.5f;

		[SerializeField]
		private float stoppingDistance =3f;

		[SerializeField]
		private GameObject target;

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

				LookAtTarget(target.transform.position);
			}
		}
		private void LookAtTarget(Vector3 lookPosition)
		{
			lookPosition.y = transform.position.y;
			Quaternion targetRotation = Quaternion.LookRotation(lookPosition - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookSpeed * Time.deltaTime);
		}
	}
}
