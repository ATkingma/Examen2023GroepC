using GroepC;
using GroepC.Managers;
using UnityEngine;

namespace GroepC.EnemyHealth
{
	/// <summary>
	/// Health for an target dummy.
	/// </summary>
	public class TargetHealth : EnemyHealthBase
	{
		/// <summary>
		/// Is the rigidbody of the target.
		/// </summary>
		[SerializeField]
		private Rigidbody rb;

		/// <summary>
		/// The direction the target falls when he is death.
		/// </summary>
		[SerializeField]
		private Vector3 falDirection = Vector3.right;

		/// <summary>
		/// The speed amount the target falls when dying.
		/// </summary>
		[SerializeField]
		private float fallSpeed = 2;

		private void Start()
		{
			rb.isKinematic = true;
		}

		/// <summary>
		/// Inheranted death.
		/// </summary>
		public override void Death()
		{
			DropManager.Instance.DropAmmo(transform.position);
			DoTargetDeath();
		}

		/// <summary>
		///Sets the rigidbody to kinematic and usses velocity to let the target fall back.
		/// </summary>
		private void DoTargetDeath()
		{
			rb.isKinematic = false;
			rb.velocity = falDirection * fallSpeed;
		}
	}
}