using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonB : MonoBehaviour
{
    static readonly string CanShoot_Bool = "Can Shoot";

    [SerializeField] float _detectRange = 4f;
    bool _canShoot;

    [SerializeField] Animator _animator;

    private void Start()
    {
        // quay người về phía Player
        Vector3 vector = Player.Instance.transform.position - transform.position;
        vector.y = 0f;
        if (vector.magnitude > 0.1f)
        {
            Quaternion rotation = Quaternion.LookRotation(vector);
            transform.rotation = rotation;
        }
    }

    private void Update()
    {
        CheckCanShoot();    
    }

    void CheckCanShoot()
    {
        // lấy khoảng cách đến player
        Vector3 vector = Player.Instance.transform.position - transform.position;
        float distance = vector.magnitude;

        if (distance < _detectRange)
        {
            _canShoot = true;
        }
        else
        {
            _canShoot = false;
        }

        _animator.SetBool(CanShoot_Bool, _canShoot);
    }
}
