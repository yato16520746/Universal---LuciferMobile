using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonB_PrepareShoot : StateMachineBehaviour
{
    SkeletonB_Delegate _delegate;
    Transform _shootTransform;
    Transform _parentTransform;
    [SerializeField] float _rotateSpeed;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // lần đầu chạy state
        if (!_delegate)
        {
            _delegate = animator.GetComponent<SkeletonB_Delegate>();
            _shootTransform = _delegate.ShootTransform;
            _parentTransform = _delegate.ParentTransform;
        }

        // set biến kiểm tra state
        _delegate.State = SkeletonB_State.PrepareShoot;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // kiểm tra đã chuyển state hay chưa
        if (_delegate.State != SkeletonB_State.PrepareShoot)
        {
            return;
        }

        // quay người ( dựa theo shootPoint) về phía Player
        Vector3 vector = Player.Instance.transform.position - _shootTransform.position;
        vector.y = 0f;
        if (vector.magnitude > 0.1f)
        {
            Quaternion rotation = Quaternion.LookRotation(vector);
            _parentTransform.rotation = Quaternion.Lerp(_parentTransform.rotation, rotation, _rotateSpeed * Time.deltaTime);
        }
    }
}
