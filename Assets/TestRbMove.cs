using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRbMove : MonoBehaviour
{
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Up;
    public KeyCode Down;

    [Space]
    public Rigidbody MyRb;

    [Space]
    public Transform KinematicCollider;

    void Update()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(Left))
        {
            horizontal = -1;
        }
        if (Input.GetKey(Right))
        {
            horizontal = 1;
        }
        if (Input.GetKey(Up))
        {
            vertical = 1;
        }
        if (Input.GetKey(Down))
        {
            vertical = -1;
        }

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical);
        moveDirection = moveDirection.normalized;

        MyRb.velocity = moveDirection * 3f;

       
    }

    private void LateUpdate()
    {
        if (KinematicCollider)
            KinematicCollider.position = transform.position;
    }
}
