using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Paladin_Walk : StateMachineBehaviour
{
    Paladin_Delegate _delegate;

    NavMeshAgent _agent;
    [SerializeField] float _timeSetDestination = 0.4f;
    float _count;
    Player _player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_delegate)
        {
            _delegate = animator.GetComponent<Paladin_Delegate>();

            _agent = _delegate.Agent;
            _player = Player.Instance;
        }

        _count = 0f;
        _agent.speed = _delegate.MoveSpeed;

        _delegate.CheckAttack1.gameObject.SetActive(true);

        _delegate.State = Paladin_State.Walk;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_delegate.State != Paladin_State.Walk)
        {
            return;
        }

        _count -= Time.deltaTime;
        if (_count < 0f)
        {
            _agent.SetDestination(_player.transform.position);
            _count = _timeSetDestination;
        }

        if (_delegate.CheckAttack1.HitTarget)
        {
            animator.SetTrigger("Attack 1");
            _delegate.CheckAttack1.gameObject.SetActive(false);
        }
    }
}
