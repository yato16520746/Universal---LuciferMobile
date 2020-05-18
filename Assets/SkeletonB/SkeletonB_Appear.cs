using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonB_Appear : StateMachineBehaviour
{
    SkeletonB_Delegate _delegate;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_delegate)
        {
            _delegate = animator.GetComponent<SkeletonB_Delegate>();
        }

        // set biến kiểm tra state
        _delegate.State = SkeletonB_State.Appear;
    }
}
