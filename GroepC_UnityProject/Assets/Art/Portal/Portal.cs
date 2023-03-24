using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private void Update()
    {
        transform.GetComponent<MeshRenderer>().material.SetFloat("_UnscaledTime", Time.unscaledTime);
    }
}
