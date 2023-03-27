using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockStateManager : MonoBehaviour
{
    [SerializeField]
    private CursorLockMode lockstate;
    private void Awake()
    {
        Cursor.lockState = lockstate;
    }
}
