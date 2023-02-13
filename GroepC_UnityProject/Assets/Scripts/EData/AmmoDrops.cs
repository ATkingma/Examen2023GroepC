using System;
using UnityEngine;

namespace GroepC.Data
{
	/// <summary>
	/// Contains information that can be helpful with the ammo drops.
	/// </summary>
	[Serializable]
	public class AmmoDrops
	{
		[SerializeField]
		public GameObject prefab;

		/// <summary>
		/// The prefab for the ammo that can be dropped.
		/// </summary>
		public GameObject Prefab => prefab;

		[SerializeField]
		private float dropChance;

		/// <summary>
		/// The chances of ammo that can be dropped.
		/// </summary>
		public float DropChance => dropChance;
	}
}
