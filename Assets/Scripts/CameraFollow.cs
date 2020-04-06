using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _target;

    [SerializeField] float _smoothSpeed = 22.5f;
    [SerializeField] Vector3 offset;

    [Space]
    [SerializeField] float _top;
    [SerializeField] float _bottom;
    [SerializeField] float _right;
    [SerializeField] float _left;

    void Start()
    {
        offset = transform.position - _target.position;
    }

    void FixedUpdate()
    {
        Vector3 newTarget = _target.position;
        if (newTarget.z > _top)
        {
            newTarget.z = _top;
        }
        if (newTarget.z < _bottom)
        {
            newTarget.z = _bottom;
        }
        if (newTarget.x > _right)
        {
            newTarget.x = _right;
        }
        if (newTarget.x < _left)
        {
            newTarget.x = _left;
        }

        Vector3 desiredPosition = newTarget + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed * Time.fixedDeltaTime);
        transform.position = smoothedPosition;

        //transform.LookAt(newTarget);
    }
}
