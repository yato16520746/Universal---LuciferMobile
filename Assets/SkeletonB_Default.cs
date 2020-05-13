using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonB_Default : StateMachineBehaviour
{
    SkeletonB_Delegate _delegate;

    [SerializeField] SkeletonB_State _thisState;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_delegate)
        {
            _delegate = animator.GetComponent<SkeletonB_Delegate>();
        }

        _delegate.State = _thisState;
    }
}
