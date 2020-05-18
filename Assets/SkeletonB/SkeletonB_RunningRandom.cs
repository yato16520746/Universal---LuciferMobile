using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonB_RunningRandom : StateMachineBehaviour
{
    SkeletonB_Delegate _delegate;

    // game AI
    NavMeshAgent _agent;
    Vector3 _destination;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_delegate)
        {
            _delegate = animator.GetComponent<SkeletonB_Delegate>();
            _agent = _delegate.NavMeshAgent;
        }

        _agent.isStopped = false;

        Vector3 sourcePosition = Random.insideUnitSphere * 10f;
        while (sourcePosition.magnitude < 2f)
        {
            sourcePosition = Random.insideUnitSphere * 10f;
        }
        sourcePosition += animator.transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(sourcePosition, out hit, 10f, 1);
        _destination = hit.position;

        _agent.SetDestination(_destination);

        // set biến kiểm tra state
        _delegate.State = SkeletonB_State.RunningRandom;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // kiểm tra state
        if (_delegate.State != SkeletonB_State.RunningRandom)
        {
            if (!_agent.isStopped)
            {
                _agent.isStopped = true;
            }

            return;
        }

        Vector3 vector = _destination - animator.transform.position;
        vector.y = 0f;
        if (vector.magnitude < 0.4f)
        {
            animator.SetBool("Running Random", false);
        }
    }
}
