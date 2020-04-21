﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Death : StateMachineBehaviour
{
    Skeleton_Delegate _delegate;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // lần đầu chạy state
        if (!_delegate)
        {
            _delegate = animator.GetComponent<Skeleton_Delegate>();
        }

        // set biến kiểm tra state
        _delegate.State = SkeletonState.Death;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // kiểm tra xem đã chuyển state hay chưa
        if (_delegate.State != SkeletonState.Death)
        {
            return;
        }
    }
}
