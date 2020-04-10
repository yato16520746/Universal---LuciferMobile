using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Idle_Aiming : StateMachineBehaviour
{
    Player_Delegate _delegate;

    Transform _transform;
    Rigidbody _rb;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // lần đầu chạy state
        if (_delegate == null)  
        {
            _delegate = animator.GetComponent<Player_Delegate>();

            _transform = animator.transform;
            _rb = _delegate.Rb;
        }

        // set biến kiểm tra State
        _delegate.State = PlayerState.Idle_Aiming;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // kiểm tra xem đã chuyển State hay chưa
        if (_delegate.State != PlayerState.Idle_Aiming)
        {
            return;
        }

        // lấy các tham số
        Rigidbody rb = _delegate.Rb;
        float speedLerp = _delegate.SpeedLerp * Time.deltaTime;
        float rotateLerp = _delegate.RotateLerp * Time.deltaTime;
        GameObject Target = _delegate.Target;

        // đưa vận tốc vào => đứng yên
        Vector3 velocity = new Vector3(0f, _rb.velocity.y, 0f);
        _rb.velocity = Vector3.Lerp(_rb.velocity, velocity, speedLerp);

        if (Target)
        {
            // xoay người về phía về mục tiêu
            Vector3 vector = Target.transform.position - _transform.position;
            vector.y = 0f;
            if (vector.magnitude > 0.1f)
            {
                Quaternion rotation = Quaternion.LookRotation(vector);
                _transform.rotation = Quaternion.Lerp(_transform.rotation, rotation, rotateLerp);
            }
        }
        else
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
