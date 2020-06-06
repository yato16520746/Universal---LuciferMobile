using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonC : MonoBehaviour
{
    static readonly string CanAttack_Bool = "Can Attack";

    [SerializeField] float _attackRange = 7f;
    readonly float _timeCheckAttack = 0.7f;
    float _count;

    [Space]
    [SerializeField] Animator _myAnim;

    private void Start()
    {
        // random quay người
        Vector3 direction = Random.insideUnitSphere;
        direction.y = 0f;
        if (direction.magnitude < 0.001f)
        {
            direction.z = 1f;
        }

        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }

    private void Update()
    {
        // gọi CheckCanAttack() ở mỗi khoảng tg
        _count -= Time.deltaTime;
        if (_count < 0f)
        {
            CheckCanAttack();
            _count = _timeCheckAttack;
        }
    }

    void CheckCanAttack()
    {
        if (!Player.Instance)
        {
            _myAnim.SetBool(CanAttack_Bool, false);
        }

        // khoảng cách với player
        Vector3 distance = Player.Instance.transform.position - transform.position;
        distance.y = 0f;

        if (distance.magnitude < _attackRange)
        {
            _myAnim.SetBool(CanAttack_Bool, true);
        }
        else
        {
            _myAnim.SetBool(CanAttack_Bool, false);
        }
    }
}
