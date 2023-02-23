using GroepC.Managers;
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
		private float fallSpeed = 2;

		/// <summary>
		/// Inheranted death.
		/// </summary>
		public override void Death()
		{
			DropManager.Instance.DropAmmo(transform.position);
			StartCoroutine(DoTargetDeath());
		}

		/// <summary>
		///Sets the rigidbody to kinematic and usses velocity to let the target fall back.
		/// </summary>
		private IEnumerator DoTargetDeath()
		{
			rb.isKinematic = false;
			rb.velocity = Vector3.back * fallSpeed;
			yield return new WaitForSeconds(destroyTime);
			Destroy(gameObject);
		}
	}
}