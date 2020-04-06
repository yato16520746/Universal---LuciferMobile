using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    NavMeshAgent navAgent;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            navAgent.isStopped = true;
        }
        else
        {
            navAgent.isStopped = false;
            navAgent.SetDestination(Player.Instance.transform.position);
        }
     
    }
}
