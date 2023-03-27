using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    void Update()
    {
        transform.LookAt(player.transform.position);
    }
}
