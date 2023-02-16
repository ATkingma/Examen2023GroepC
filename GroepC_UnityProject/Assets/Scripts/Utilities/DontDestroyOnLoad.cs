using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GroepC.Utilities
{
    /// <summary>
    /// An class that contains an awake with dondestroyonload function being called.
    /// </summary>
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void Awake() => DontDestroyOnLoad(this);
    }
}
