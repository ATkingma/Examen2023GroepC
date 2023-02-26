using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NevTestEnemy : MonoBehaviour
{

    public GameObject target;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.P)) {
            GoToTarget();
        }
    }

    private void GoToTarget()
    {
        agent.destination = target.transform.position;
    }
}
