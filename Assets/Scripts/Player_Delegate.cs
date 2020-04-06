using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Delegate : MonoBehaviour
{
    [SerializeField] Joystick _joystick;
    public Joystick Joystick { get { return _joystick; } }

    [SerializeField] Rigidbody _rb;
    public Rigidbody Rb { get { return _rb; } }

    [SerializeField] Animator _animator;
 
    [Space]
    [SerializeField] float _runSpeed;
    public float RunSpeed { get { return _runSpeed; } }
    
    // speed lerp for all animation
    [Space]
    [SerializeField] float _speedLerp;
    public float SpeedLerp { get { return _speedLerp; } }

    // rotate lerp
    [Space]
    [SerializeField] float _rotateLerp;
    public float RotateLerp { get { return _rotateLerp; } }

    private void Update()
    {
        if (Joystick.Vertical == 0 && Joystick.Horizontal == 0)
        {
            _animator.SetBool("Moving", false);    
        }
        else
        {
            _animator.SetBool("Moving", true);
        }
    }
}
