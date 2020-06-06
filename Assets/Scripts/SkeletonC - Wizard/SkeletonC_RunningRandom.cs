using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonC_RunningRandom : StateMachineBehaviour
{
    SkeletonC_Delegate _delegate;

    // game AI
    NavMeshAgent _agent;
    Vector3 _destination;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_delegate)
        {
            _delegate = animator.GetComponent<SkeletonC_Delegate>();
            _agent = _delegate.Agent;
        }

        _agent.isStopped = false;

        Vector3 randomDirection = Random.insideUnitSphere;
        float distance = Random.Range(3.5f, 7.5f);
        randomDirection.y = 0f;
        while (randomDirection.magnitude < 0.001f)
        {
            randomDirection.z = 1f;
        }
        Vector3 randomPosition = randomDirection.normalized * distance;

        NavMeshHit hit;
        NavMesh.SamplePosition(randomPosition, out hit, 10f, 1);
        _destination = hit.position;
        _agent.SetDestination(_destination);

        _delegate.State = SkeletonC_State.RunningRandom;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // kiểm tra state
        if (_delegate.State != SkeletonC_State.RunningRandom)
        {
            if (!_agent.isStopped)
            {
                _agent.isStopped = true;
            }

            return;
        }

        Vector3 distance = _destination - animator.transform.position;
        distance.y = 0f;
        if (distance.magnitude < 0.4f)
        {
            animator.SetBool("Running Random", false);
        }
    }
}
