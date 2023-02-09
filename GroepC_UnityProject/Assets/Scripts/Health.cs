using UnityEngine;

namespace GroepC
{
	public class Health : MonoBehaviour
	{
		/// <summary>
		/// The amount of health the healthclass object has
		/// </summary>
		[SerializeField]
		private float healthAmount;

		/// <summary>
		/// Subtracks the damage from the current health
		/// </summary>
		/// <param name="damage"></param>
		public virtual void DoDamage(float damage)
		{
			healthAmount = -damage;
			CheckHealth();
		}

		/// <summary>
		/// Checks if object is death
		/// </summary>
		private void CheckHealth()
		{
			if (healthAmount > 0)
			{
				Death();
			}
		}

		/// <summary>
		/// function that handles the death of an health object
		/// </summary>
		public virtual void Death()
		{
			Destroy(gameObject);
		}
	}
}
