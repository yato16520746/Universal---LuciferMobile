using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton_Walk : StateMachineBehaviour
{
    Skeleton_Delegate _delegate;

    NavMeshAgent agent;
    float _count;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // lần đầu chạy state
        if (!_delegate)
        {
            _delegate = animator.GetComponent<Skeleton_Delegate>();

            agent = _delegate.NavAgent;
        }

        _count = _delegate.TimeBetweenNavigation;

        // set biến kiểm tra state
        _delegate.State = SkeletonState.Walk;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // kiểm tra đã chuyển state hay chưa
        if (_delegate.State != SkeletonState.Walk)
        {
            return;
        }

        _count += Time.deltaTime;
        if (_count > _delegate.TimeBetweenNavigation)
        {
            _delegate.NavAgent.SetDestination(Player.Instance.transform.position);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.ResetPath();
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
