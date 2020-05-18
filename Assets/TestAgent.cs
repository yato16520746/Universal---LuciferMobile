using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestAgent : MonoBehaviour
{
    NavMeshAgent _agent;
    Vector3 _lastPosition;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        if (Player.Instance)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _agent.isStopped = true;

                if (_agent.isStopped)
                {
                Vector3 vector = transform.position - _lastPosition;
                Debug.Log(vector.magnitude);
                    }
            }
            else
            {

                _agent.isStopped = false;
                _agent.SetDestination(Player.Instance.transform.position);
            }

        }

        _lastPosition = transform.position;
    }
}
