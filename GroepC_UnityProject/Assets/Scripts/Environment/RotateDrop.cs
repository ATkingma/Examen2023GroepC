using UnityEngine;

namespace GroepC.Environment
{
    /// <summary>
    /// Rotates the object.
    /// </summary>
    public class RotateDrop : MonoBehaviour
    {
        /// <summary>
        /// Axis.
        /// </summary>
        public bool x, y, z;

        /// <summary>
        /// Rotates.
        /// </summary>
        private void Update()
        {
            if(x)
                transform.Rotate(Vector3.up, -90 * Time.deltaTime);
            else if(y)
                transform.Rotate(Vector3.right, -90 * Time.deltaTime);
            else if(z)
                transform.Rotate(Vector3.forward, -90 * Time.deltaTime);
            else
                transform.Rotate(Vector3.up, -90 * Time.deltaTime);
        }
    }
}
