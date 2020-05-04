using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    public static string Attack_Bool = "Attack";

    [SerializeField] Animator _animator;
    [SerializeField] DetecPlayerHealth _detecPlayerHealth;

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
        // attack animation
        if (_detecPlayerHealth.InRange)
        {
            _animator.SetBool(Attack_Bool, true);
        }
        else
        {
            _animator.SetBool(Attack_Bool, false);
        }

        // check player Dead
         _animator.SetBool("Player Dead", PlayerHealth.Instance.IsDead);
    }
}
