using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GroepC.Utilities
{
	public class OnTriggerEvent : MonoBehaviour
	{
		[SerializeField]
		private UnityEvent triggerEvent;

		[SerializeField]
		private LayerMask targetLayer;

		private void OnTriggerEnter(Collider other)
		{
			if(other.gameObject.layer!= targetLayer) 
			{ 
				triggerEvent.Invoke();
			}
		}
	}
}