﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Walk_Aiming : StateMachineBehaviour
{
    Player_Delegate _delegate;

    Transform _transform;
    Rigidbody _rb;
    bool _lockRotateMove;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // lần đầu chạy state
        if (!_delegate)
        {
            _delegate = animator.GetComponent<Player_Delegate>();

            _transform = animator.transform;
            _rb = _delegate.Rb;
        }

        // set biến kiểm tra State
        _delegate.State = PlayerState.Walk_Aiming;

        // cho phép xoay theo hướng di chuyển
        _lockRotateMove = false;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // kiểm tra xem đã chuyển State hay chưa
        if (_delegate.State != PlayerState.Walk_Aiming)
        {
            return;
        }

        // lấy các tham số
        Vector3 joystickDirection = _delegate.JoystickDirection;
        float walkSpeed = _delegate.WalkSpeed;
        float speedLerp = _delegate.SpeedLerp * Time.deltaTime;
        float rotateLerp = _delegate.RotateLerp * Time.deltaTime;
        EnemyHealth Target = _delegate.Target;
        Transform rigPistolRight = _delegate.RigPistolRight;

        // đưa vận tốc vào => di chuyển chậm
        Vector3 velocity = new Vector3(joystickDirection.x * walkSpeed, _rb.velocity.y, joystickDirection.z * walkSpeed);
        _rb.velocity = Vector3.Lerp(_rb.velocity, velocity, speedLerp);

        if (Target && !Target.IsDead)
        {
            // khóa xoay theo hướng di chuyển
            _lockRotateMove = true;

            // xoay người về phía về mục tiêu
            Vector3 vector = Target.transform.position - rigPistolRight.transform.position;
            vector.y = 0f;
            if (vector.magnitude > 0.1f)
            {
                Quaternion rotation = Quaternion.LookRotation(vector);
                _transform.rotation = Quaternion.Lerp(_transform.rotation, rotation, rotateLerp);
            }
        }
        else if (!_lockRotateMove)
        {
            // xoay người theo hướng di chuyển
            Vector3 vector = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
            if (vector.magnitude > 0.1f)
            {
                Quaternion rotation = Quaternion.LookRotation(vector);
                _transform.rotation = Quaternion.Lerp(_transform.rotation, rotation, rotateLerp);
            }
        }
    }
}
