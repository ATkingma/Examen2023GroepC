using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

/// <summary>
/// An public class that hold event for moving the player.
/// </summary>
public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private Vector3 warpPosition = Vector3.zero;

    /// <summary>
    /// Moves player to new player.
    /// </summary>
    /// <param name="_positionObject"></param>
    public void MovePlayer(GameObject _positionObject) => warpPosition = _positionObject.transform.position;

    public void SetPlayerRotation(GameObject _rotationObject) => player.transform.rotation = Quaternion.Euler(_rotationObject.transform.rotation.eulerAngles);

    void LateUpdate()
    {
        if (warpPosition != Vector3.zero)
        {
            player.transform.position = warpPosition;
            warpPosition = Vector3.zero;
        }
    }

}