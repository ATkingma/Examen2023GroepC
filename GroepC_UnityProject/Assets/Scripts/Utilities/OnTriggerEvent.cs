using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GroepC.Utilities
{
	/// <summary>
	/// This will be an Utilitie that can be ussed as an general trigger event.
	/// </summary>
	public class OnTriggerEvent : MonoBehaviour
	{
		/// <summary>
		/// The event that wil be triggert.
		/// </summary>
		[SerializeField]
		private UnityEvent triggerEvent;

		/// <summary>
		/// The Tag that wil be checked OnTriggerEnter.
		/// </summary>
		[SerializeField]
		private GameTags tag;

		/// <summary>
		/// Triggers the event when colliding with the <see cref="tag"/>.
		/// </summary>
		/// <param name="other">The collider this collider has collition with.</param>
		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag(tag.ToString()))
				triggerEvent.Invoke();
		}
	}

	/// <summary>
	/// Tags that are in game.
	/// </summary>
	enum GameTags
	{
		UnTagged,
		Respawn,
		Finish,
		EditorOnly,
		MainCamera,
		Player,
		GameController,
	}
}