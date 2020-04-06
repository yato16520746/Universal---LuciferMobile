using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Idle : StateMachineBehaviour
{
    Player_Delegate _delegate;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_delegate)
        {
            _delegate = animator.GetComponent<Player_Delegate>();
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _delegate.Rb.velocity = Vector3.Lerp(_delegate.Rb.velocity, Vector3.zero, _delegate.SpeedLerp * Time.deltaTime);
        Debug.Log(_delegate.Rb.velocity);
    }
}
