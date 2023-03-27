using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An class that lerps the camera true some points
/// </summary>
public class CameraLerper : MonoBehaviour
{
    /// <summary>
    /// the instance of the class
    /// </summary>
    private static CameraLerper instance;
    public static CameraLerper Instance=> instance;

    /// <summary>
    /// The speed of the movment.
    /// </summary>
    [SerializeField] private float speed;
    /// <summary>
    /// The closing distance of the point and the camera.
    /// </summary>
    [SerializeField] private float clossingDistance;
    /// <summary>
    /// The target for the camera to move towards.
    /// </summary>
    [SerializeField] private List<GameObject> points;

    /// <summary>
    /// CameraObject that wil be moved.
    /// </summary>
    private GameObject cameraObject;

    /// <summary>
    /// Current count of the index.
    /// </summary>
    private int  currentIndex;

    private void Awake()
    {
        instance = this;
    }
    
    void Update()
    {
        if (cameraObject != null)
        {
            if(Vector3.Distance(cameraObject.transform.position, points[currentIndex].transform.position)<= clossingDistance)
            {
                if (currentIndex + 1 >= points.Count)
                {
                    currentIndex= 0;    
                }
                else
                {
                    currentIndex++;
                }
            }
            else
            {
                cameraObject.transform.position =  Vector3.MoveTowards(cameraObject.transform.position, points[currentIndex].transform.position,speed);
            }
        }
    }

    public void SetCameraObject(GameObject _cameraObject)
    {
        cameraObject = _cameraObject;
        currentIndex = 0;
    }
}
