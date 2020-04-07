using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton_Delegate : MonoBehaviour
{
    [Space]
    [SerializeField] NavMeshAgent _navAgent;
    public NavMeshAgent NavAgent { get { return _navAgent; } }

    [Space]
    [SerializeField] Rigidbody _rb; 
    public Rigidbody Rb { get { return _rb; } }

    [Space]
    [SerializeField] float _timeBetweenNavigation = 1f;
    public float TimeBetweenNavigation { get { return _timeBetweenNavigation; } }
}
