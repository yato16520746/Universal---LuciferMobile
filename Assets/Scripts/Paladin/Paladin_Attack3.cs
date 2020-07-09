﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Paladin_Attack3 : StateMachineBehaviour
{
    Paladin_Delegate _delegate;

    NavMeshAgent _agent;
    Player _player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_delegate)
        {
            _delegate = animator.GetComponent<Paladin_Delegate>();

            _agent = _delegate.Agent;
            _player = Player.Instance;
        }

        _delegate.Event_setAttack3MovingType(1);


        _delegate.State = Paladin_State.Attack3;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_delegate.State != Paladin_State.Attack3)
        {
            return;
        }

        float rotateLerp = _delegate.RotateLerp * Time.deltaTime;

        if (_delegate.Attack3_MovingType == 1)
        {
            _agent.speed = _delegate.Attack3_moveSpeed2;
            _agent.SetDestination(_player.transform.position);

            // looking player
            Vector3 vector = Player.Instance.transform.position - animator.transform.position;
            vector.y = 0f;
            if (vector.magnitude > 0.0001f)
            {
                Quaternion rotation = Quaternion.LookRotation(vector);
                _agent.transform.rotation = Quaternion.Lerp(_agent.transform.rotation, rotation, rotateLerp);
            }
        }
        else if (_delegate.Attack3_MovingType == 2)
        {
            _agent.speed = 0;
        }
    }
}
