using UnityEngine;

namespace GroepC.Environment
{
    /// <summary>
    /// Rotates the object.
    /// </summary>
    public class RotateDrop : MonoBehaviour
    {
        /// <summary>
        /// Rotates.
        /// </summary>
        private void Update() => transform.Rotate(Vector3.up, -90 * Time.deltaTime);
    }
}
