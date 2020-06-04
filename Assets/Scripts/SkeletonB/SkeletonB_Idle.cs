using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonB_Idle : StateMachineBehaviour
{
    SkeletonB_Delegate _delegate;
    
    [SerializeField] float _minTime;
    [SerializeField] float _maxTime;
    float _count;
        
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_delegate)
        {
            _delegate = animator.GetComponent<SkeletonB_Delegate>();
        }

        animator.SetBool("Idling", true);
        _count = Random.Range(_minTime, _maxTime);

        // set biến kiểm tra state
        _delegate.State = SkeletonB_State.Idle;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // kiểm tra state
        if (_delegate.State != SkeletonB_State.Idle)
        {
            return;
        }

        _count -= Time.deltaTime;
        if (_count < 0f)
        {
            animator.SetBool("Idling", false);
        }
    }
}
