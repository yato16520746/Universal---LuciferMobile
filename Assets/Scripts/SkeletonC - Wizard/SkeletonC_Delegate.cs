using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum SkeletonC_State
{
    Idle,
    ChasingPlayer,
    Attack,
    RunningRandom,
    Death
}
public class SkeletonC_Delegate : MonoBehaviour
{
    [SerializeField] Transform _parent;
    public Transform Parent { get { return _parent; } }

    [SerializeField] Animator _myAnim;

    [HideInInspector] public SkeletonC_State State;

    [Header("Game AI")]
    [SerializeField] NavMeshAgent _agent;
    public NavMeshAgent Agent { get { return _agent; } }


}
