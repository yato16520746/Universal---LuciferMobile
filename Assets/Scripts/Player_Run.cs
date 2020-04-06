using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Run : StateMachineBehaviour
{
    Player_Delegate _delegate;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // get Player_Delegate from animator
        if (!_delegate)
        {
            _delegate = animator.GetComponent<Player_Delegate>();
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // get direction from Joystick
        Vector3 direction = (new Vector3(_delegate.Joystick.Horizontal, 0, _delegate.Joystick.Vertical)).normalized;

        // define the velocity you want
        Vector3 designedVelocity = direction * _delegate.RunSpeed;

        // apply velocity to move
        _delegate.Rb.velocity = Vector3.Lerp(_delegate.Rb.velocity, designedVelocity, _delegate.SpeedLerp * Time.deltaTime);
        Debug.Log(_delegate.Rb.velocity);

        // rotate the player to the right direction
        if (_delegate.Rb.velocity != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(_delegate.Rb.velocity);
            animator.transform.rotation = Quaternion.Lerp(animator.transform.rotation, rotation, _delegate.RotateLerp * Time.deltaTime);
        }
    }
}
