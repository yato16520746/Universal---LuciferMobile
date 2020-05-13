using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float _speed = 50;
    [SerializeField] float _delay = 0.1f;
    bool canFly = false;

    private void Start()
    {
        StartCoroutine(CanFly());
    }

    private void Update()
    {
        if (canFly)
            transform.Translate(Vector3.up * _speed * Time.deltaTime);

    }

    IEnumerator CanFly()
    {
        yield return new WaitForSeconds(_delay);

        canFly = true;
    }
}
