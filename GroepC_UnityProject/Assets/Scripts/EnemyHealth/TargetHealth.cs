using GroepC.Managers;
using GroepC.Player;
using System.Collections;
using UnityEngine;

namespace GroepC.Enemies
{
	/// <summary>
	/// Health for an target dummy.
	/// </summary>
	public class TargetHealth : EnemyHealthBase
	{
		/// <summary>
		/// The time after dying before destroying the gameobject.
		/// </summary>
		[SerializeField]
		private float destroyTime;
		/// <summary>
		/// Is the rigidbody of the target.
		/// </summary>
		[SerializeField]
		private Rigidbody rb;

		/// <summary>
		/// The speed amount the target falls when dying.
		/// </summary>
		[SerializeField]
		private float fallSpeed = 100;

		/// <summary>
		/// Inheranted death.
		/// </summary>
		public override void Death()
		{
            ScoreManager.Instance.AddScore(1);
            DropManager.Instance.DropAmmo(transform.position);
			StartCoroutine(DoTargetDeath());
		}

		/// <summary>
		///Sets the rigidbody to kinematic and usses velocity to let the target fall back.
		/// </summary>
		private IEnumerator DoTargetDeath()
		{
			rb.isKinematic = false;
			PlayerController player = FindObjectOfType<PlayerController>();
			Vector3 fallDirection = player.transform.position - transform.position;
			rb.AddForce(fallDirection.z > 0 ? transform.right : -transform.right * fallSpeed);
			yield return new WaitForSeconds(destroyTime);
			Destroy(gameObject);
		}
	}
}