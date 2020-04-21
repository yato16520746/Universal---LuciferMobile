using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum SkeletonState
{
    Attack,
    Idle,
    Walk,
    Death
}

public class Skeleton_Delegate : MonoBehaviour
{
    [SerializeField] NavMeshAgent _navAgent;
    public NavMeshAgent NavAgent { get { return _navAgent; } }

    [SerializeField] Rigidbody _rb; 
    public Rigidbody Rb { get { return _rb; } }

    [SerializeField] GameObject _parent;

    [Space]
    [SerializeField] float _timeBetweenNavigation = 1f;
    public float TimeBetweenNavigation { get { return _timeBetweenNavigation; } }

    // trạng thái của Skeleton
    public SkeletonState State;

    // bỏ hàm này vào giây cuối cùng của quái
    public void DestroyMe()
    {
        Destroy(_parent);
    }
}
