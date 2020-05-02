using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    NavMeshAgent navAgent;
    Rigidbody _rb;
    [SerializeField] bool _apply = false;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        _rb = GetComponent<Rigidbody>();
    }

    bool check = false;

    void Update()
    {


        //if (Input.GetKey(KeyCode.A))
        //{
        //    check = true;
 
        //}
        //if (check)
        //{
        //    navAgent.ResetPath();
        //}
        //else
        //{
        //    navAgent.isStopped = false;
        //    navAgent.SetDestination(Player.Instance.transform.position);
            
       
        //}

    }
}
