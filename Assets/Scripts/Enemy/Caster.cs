using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caster : MonoBehaviour
{
    enum CasterType
    {
        Ray,
        Box,
        Phere
    }

    [SerializeField] CasterType _type;
    [SerializeField] LayerMask _mask;
    [SerializeField] float _distance;
    [SerializeField] string _targetName;
    RaycastHit _hit;

    [SerializeField] float _timeBetweenCast = 0.2f;
    float _count;

    [Space]
    [SerializeField] bool _debug;

    bool _hitTarget;
    public bool HitTarget { get { return _hitTarget; } }

    private void Update()
    {
        _hitTarget = false;

        _count -= Time.deltaTime;
        if (_count < 0f)
        {
            Cast();
            _count = _timeBetweenCast;
        }

    }

    void Cast()
    {
        bool isHit = false;

        if (_type == CasterType.Ray)
        {
            isHit = Physics.Raycast(transform.position, transform.forward, out _hit, _distance, _mask);
        }
        else if (_type == CasterType.Box)
        {
            isHit = Physics.BoxCast(transform.position, transform.lossyScale / 2f, transform.forward,
                out _hit, transform.rotation, _distance, _mask);
        }
        else if (_type == CasterType.Phere)
        {
            isHit = Physics.SphereCast(transform.position, transform.localScale.x / 2, transform.forward,
                out _hit, _distance, _mask);
        }

        if (isHit)
        {
            if (_hit.collider.gameObject.name == _targetName)
            {
                _hitTarget = true;
            }
        }
    }

    private void OnDisable()
    {
        _count = 0f;
        _hitTarget = false;
    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        if (!_debug)
        {
            return;
        }

        if (_type == CasterType.Ray)
        {
            bool isHit = Physics.Raycast(transform.position, transform.forward, out _hit, _distance, _mask);
            if (isHit)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawRay(transform.position, transform.forward * _hit.distance);
            }
            else
            {
                Gizmos.color = Color.green;
                Gizmos.DrawRay(transform.position, transform.forward * _distance);
            }
        }
        else if (_type == CasterType.Box)
        {
            bool isHit = Physics.BoxCast(transform.position, transform.lossyScale / 2f, transform.forward,
                out _hit, transform.rotation, _distance, _mask);
            if (isHit)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawRay(transform.position, transform.forward * _hit.distance);
                Gizmos.DrawWireCube(transform.position + transform.forward * _hit.distance, transform.lossyScale);
            }
            else
            {
                Gizmos.color = Color.green;
                Gizmos.DrawRay(transform.position, transform.forward * _distance);
            }
        }
        else if (_type == CasterType.Phere)
        {
            bool isHit = Physics.SphereCast(transform.position, transform.localScale.x / 2, transform.forward,
                out _hit, _distance, _mask);
            if (isHit)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawRay(transform.position, transform.forward * _hit.distance);
                Gizmos.DrawWireSphere(transform.position + transform.forward * _hit.distance, transform.lossyScale.x / 2);
            }
            else
            {
                Gizmos.color = Color.green;
                Gizmos.DrawRay(transform.position, transform.forward * _distance);
            }
        }
    }

#endif
}
