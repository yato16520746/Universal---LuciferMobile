using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SkeletonB_DrawArrow : StateMachineBehaviour
{
    SkeletonB_Delegate _delegate;
    Transform _shootTransform;
    Transform _parentTransform;
    [SerializeField] float _rotateSpeed;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_delegate)
        {
            _delegate = animator.GetComponent<SkeletonB_Delegate>();
            _shootTransform = _delegate.ShootTransform;
            _parentTransform = _delegate.ParentTransform;
        }

        // set biến kiểm tra state
        _delegate.State = SkeletonB_State.DrawArrow;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // kiểm tra state
        if (_delegate.State != SkeletonB_State.DrawArrow)
        {
            return;
        }

        Vector3 vector_2 = Player.Instance.transform.position - animator.transform.position;
        vector_2.y = 0f;
        if (vector_2.magnitude < 1.3f)
        {
            // player đứng quá gần, xoay người vào Player
            Quaternion rotation = Quaternion.LookRotation(vector_2);
            _parentTransform.rotation = Quaternion.Lerp(_parentTransform.rotation, rotation, _rotateSpeed * Time.deltaTime);

            return;
        }

        // quay người (dựa vào _shootTransform) về phía player
        Vector3 vector = Player.Instance.transform.position - _shootTransform.position;
        vector.y = 0f;
        if (vector.magnitude > 0.1f)
        {
            Quaternion rotation = Quaternion.LookRotation(vector);
            _parentTransform.rotation = Quaternion.Lerp(_parentTransform.rotation, rotation, _rotateSpeed * Time.deltaTime);
        }
    }
}
