using GroepC;
using GroepC.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GroepC.EnemyHealth
{
	/// <summary>
	/// Health of the enemy that wil be walking.
	/// </summary>
	public class EnemyHealth : EnemyHealthBase
	{
		/// <summary>
		/// The name of the animation bool that can be triggert when the enemy is death.
		/// </summary>
		[SerializeField]
		private string deathBoolName = "IsDeath";

		/// <summary>
		/// Animator that wil be assigned to the enemy.
		/// </summary>
		[SerializeField]
		private Animator anim;

		/// <summary>
		/// Death Function that wil be called from the base.
		/// </summary>
		public override void Death()
		{
			StartCoroutine(PlayEnemyDeath());
		}

		/// <summary>
		/// Animation player that wil drop ammo when animation isplayed and then destroy the object holder.
		/// </summary>
		/// <returns></returns>
		private IEnumerator PlayEnemyDeath()
		{
			anim.SetBool(deathBoolName, true);
			AnimatorStateInfo animStateInfo = anim.GetCurrentAnimatorStateInfo(0);
			float NTime = animStateInfo.normalizedTime;
			yield return NTime > 1.0f;
			DropManager.Instance.DropAmmo(transform.position);
			Destroy(gameObject);
		}
	}
}