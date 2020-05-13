using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton_Walk : StateMachineBehaviour
{
    Skeleton_Delegate _delegate;

    NavMeshAgent _agent;
    [SerializeField] float _timeBetweenSetDestination;
    float _count;
    bool _resetPath;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // lần đầu chạy state
        if (!_delegate)
        {
            _delegate = animator.GetComponent<Skeleton_Delegate>();
            _agent = _delegate.NavAgent;
        }

        _count = 0f;
        _resetPath = false;

        // set biến kiểm tra state
        _delegate.State = SkeletonState.Walk;
    }   

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // kiểm tra đã chuyển state hay chưa
        if (_delegate.State != SkeletonState.Walk)
        {
            if (!_resetPath)
            {
                _agent.ResetPath();
                _resetPath = true;
            }

            return;
        }

        // tìm đường chạy đến player sau mỗi khoảng tg
        _count -= Time.deltaTime;
        if (_count < 0f)
        {
            _agent.SetDestination(Player.Instance.transform.position);
            _count = _timeBetweenSetDestination;
        }
    }
}
