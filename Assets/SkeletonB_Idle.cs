using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonB_Idle : StateMachineBehaviour
{
    SkeletonB_Delegate _delegate;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // lần đầu chạy state
        if (!_delegate)
        {
            _delegate = animator.GetComponent<SkeletonB_Delegate>();
        }

        // set biến kiểm tra state
        _delegate.State = SkeletonB_State.Idle;
    }
}
