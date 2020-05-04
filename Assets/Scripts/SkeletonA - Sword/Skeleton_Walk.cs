using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton_Walk : StateMachineBehaviour
{
    Skeleton_Delegate _delegate;

    NavMeshAgent agent;
    float _count;
    bool _resetPath;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // lần đầu chạy state
        if (!_delegate)
        {
            _delegate = animator.GetComponent<Skeleton_Delegate>();

            agent = _delegate.NavAgent;
        }

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
                agent.ResetPath();
                _resetPath = true;
            }

            return;
        }

        _delegate.NavAgent.SetDestination(Player.Instance.transform.position);
    }
}
