using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int _health = 100;
    GameObject _parent;

    private void Start()
    {
        // lấy gameobject sở hữu
        _parent = transform.parent.gameObject;
    }

    public void AddDamage(int amount)
    {
        // trừ máu quái, nếu máu <= 0 thì destroy
        _health -= amount;
        if (_health <= 0)
        {
            Destroy(_parent);
        }
    }
}
