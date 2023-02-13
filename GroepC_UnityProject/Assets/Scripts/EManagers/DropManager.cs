using GroepC.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GroepC.Managers
{
	/// <summary>
	/// DropManager is an manager that wil keep track of what wil dropped.
	/// </summary>
	public class DropManager : MonoBehaviour
	{
		private static DropManager instance;

		/// <summary>
		/// Instance of the dropmanager.
		/// </summary>
		public static DropManager Instance => instance;

		/// <summary>
		/// An list of ammo types that also has the prefab/chance to drop.
		/// </summary>
		[SerializeField]
		public List<AmmoDrops> ammoDrops;

		private void Awake()
		{
			if (Instance != null)
			{
				Destroy(Instance);
			}
			instance = this;
		}

		/// <summary>
		/// Drops ammo on the given position and wil drop an random ammo type.
		/// </summary>
		/// <param name="dropPosition"></param>
		public void DropAmmo(Vector3 dropPosition)
		{
			var randomValue = UnityEngine.Random.Range(0f, 1f);

			float pickchanceModifier = ammoDrops.Sum(o => o.DropChance);
			randomValue *= pickchanceModifier;

			float currentDistribution = 0f;
			foreach (var prize in ammoDrops)
			{
				currentDistribution += prize.DropChance;

				if (currentDistribution >= randomValue)
				{
					Instantiate(prize.prefab, dropPosition, Quaternion.identity);
				}
			}
		}
	}
}