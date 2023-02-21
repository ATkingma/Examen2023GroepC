using UnityEngine;
namespace GroepC.Enemies
{
	/// <summary>
	/// is the base of the enemyHealth
	/// </summary>
	public class EnemyHealthBase : MonoBehaviour
	{
		/// <summary>
		/// The amount of health the healthclass object has
		/// </summary>
		[SerializeField]
		private float healthAmount;

		/// <summary>
		/// Subtracks the damage from the current health
		/// </summary>
		/// <param name="_damage"></param>
		public virtual void DoDamage(float _damage)
		{
			healthAmount -= _damage;
			CheckHealth();
		}

		/// <summary>
		/// Checks if object is death
		/// </summary>
		private void CheckHealth()
		{
			if (healthAmount <= 0)
				Death();
		}

		/// <summary>
		/// function that handles the death of an health object
		/// </summary>
		public virtual void Death() => Destroy(gameObject);
	}
}
