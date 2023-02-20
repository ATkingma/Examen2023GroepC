using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GroepC.Utilities
{
	/// <summary>
	/// This wil be an Utilitie that can be ussed as an general trigger event.
	/// </summary>
	public class OnTriggerEvent : MonoBehaviour
	{
		/// <summary>
		/// The event that wil be triggert.
		/// </summary>
		[SerializeField]
		private UnityEvent triggerEvent;

		/// <summary>
		/// The layer that wil be checked OnTriggerEnter.
		/// </summary>
		[SerializeField]
		private LayerMask targetLayer;

		/// <summary>
		/// Triggers the event when colliding with the <see cref="targetLayer"/>.
		/// </summary>
		/// <param name="other">The collider this collider has collition with.</param>
		private void OnTriggerEnter(Collider other)
		{
			if(other.gameObject.layer!= targetLayer)
				triggerEvent.Invoke();
		}
	}
}