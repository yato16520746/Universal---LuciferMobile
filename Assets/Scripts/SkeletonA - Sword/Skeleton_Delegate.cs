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

    [SerializeField] GameObject _enemyDamage;

    // trạng thái của Skeleton
    [HideInInspector] public SkeletonState State;

    private void Start()
    {
        DisableDamage();
    }

    // bỏ hàm này vào giây cuối cùng của quái
    public void DestroyMe()
    {
        Destroy(_parent);
    }

    public void EnableDamage()
    {
        _enemyDamage.SetActive(true);
    }

    public void DisableDamage()
    {
        _enemyDamage.SetActive(false);
    }
}
