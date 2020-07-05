using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum Paladin_State
{
    Idle,
    Walk,
    Attack1
}

public class Paladin_Delegate : MonoBehaviour
{
    [Header("AI")]
    [SerializeField] NavMeshAgent _agent;
    public NavMeshAgent Agent { get { return _agent; } }

    [SerializeField] float _moveSpeed;
    public float MoveSpeed { get { return _moveSpeed; } }

    [SerializeField] Caster _checkAttack1;
    public Caster CheckAttack1 { get { return _checkAttack1; } }

    [Header("Effect")]
    [SerializeField] GameObject _explosion1;
    [SerializeField] GameObject _explosion2;

    [Header("Audio")]
    [SerializeField] AudioClip _demoClip;
    [SerializeField] AudioClip _clip;
    [SerializeField] AudioSource _source;

    [HideInInspector] public Paladin_State State;

    private void Start()
    {
        CheckAttack1.gameObject.SetActive(false);
    }

    private void Update()
    {
        
    }
    void Event_PowerUp()
    {
        _explosion1.SetActive(true);
        _explosion2.SetActive(true);
        _source.PlayOneShot(_clip);

        ShakeCamera.Instance.ShouldShake = true;
    }

    void Event_PlayDemoClip()
    {
        _source.PlayOneShot(_demoClip);
    }
}
