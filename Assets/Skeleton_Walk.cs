﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Walk : StateMachineBehaviour
{
    Skeleton_Delegate _delegate;
    float _count;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_delegate)
        {
            _delegate = animator.GetComponent<Skeleton_Delegate>();
        }

        _count = _delegate.TimeBetweenNavigation;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _count += Time.deltaTime;
        if (_count > _delegate.TimeBetweenNavigation)
        {
            _delegate.NavAgent.SetDestination(Player.Instance.transform.position);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

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
