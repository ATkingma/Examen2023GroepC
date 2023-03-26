using GroepC.Managers;
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
		/// The max health of the enemy.
		/// </summary>
		private float maxHealth;

		/// <summary>
		/// Subtracks the damage from the current health
		/// </summary>
		/// <param name="_damage"></param>
		public virtual void DoDamage(float _damage)
		{
            if (healthAmount == 0)
                return;

			SaveManager.Instance.AddHit();
            healthAmount = Mathf.Clamp(healthAmount - _damage, 0, maxHealth);

            if (healthAmount == 0)
                Death();
		}

		/// <summary>
		/// function that handles the death of an health object
		/// </summary>
		public virtual void Death()
		{
            SaveManager.Instance.AddEnemyKilled();
            ScoreManager.Instance.AddScore(1);
            Destroy(gameObject);
        }
	}
}
