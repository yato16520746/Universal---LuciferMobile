using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [Space]

    [SerializeField] int _health = 100;
    GameObject _parent;

    public bool IsDead
    {
        get
        {
            if (_health <= 0)
            {
                return true;
            }

            return false;
        }
    }

    private void Start()
    {
        // lấy gameobject sở hữu
        _parent = transform.parent.gameObject;
    }

    private void Update()
    {
        if (_animator)
            _animator.SetBool("Get Hit", false);
    }

    public void AddDamage(int amount)
    {
        if (_health <= 0)
        {
            return;
        }

        // trừ máu quái, nếu máu <= 0 thì destroy
        _health -= amount;

        // chạy animation nhấp nháy
        if (_animator)
        {
            _animator.SetBool("Get Hit", true);
        }

        // chạy animation death
        if (_health <= 0)
        {
            _animator.SetBool("Dead", true);
            _animator.SetInteger("Dead Type", Random.Range(0, 3));

            gameObject.layer = LayerMask.GetMask("Default");
        }
    }
}
