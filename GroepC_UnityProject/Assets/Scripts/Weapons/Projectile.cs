using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GroepC.Weapons
{
    /// <summary>
    /// Projectile base class.
    /// </summary>
    public class Projectile : MonoBehaviour
    {
        /// <summary>
        /// For now, destroys the projectile after 1 second.
        /// </summary>
        private void Start()
        {
            Destroy(gameObject, 1);
        }
    }
}