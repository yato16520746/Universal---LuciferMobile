using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum Paladin_State
{
    Idle,
    Walk,
    Attack1,
    Attack2
}

public class Paladin_Delegate : MonoBehaviour
{
    [Header("AI movement")]
    [SerializeField] NavMeshAgent _agent;
    public NavMeshAgent Agent { get { return _agent; } }

    [SerializeField] Animator _animator;

    [HideInInspector] public Paladin_State State;

    [SerializeField] float _walkSpeed;
    public float WalkSpeed { get { return _walkSpeed; } }

    [SerializeField] float _speedLerp = 30;
    public float SpeedLerp { get { return _speedLerp; } }

    [SerializeField] float _rotateLerp = 20;
    public float RotateLerp { get { return _rotateLerp; } }

    [HideInInspector] public float StateSpeed;

    [SerializeField] float _distance_Attack2 = 1.3f;
    public float Distance_Attack2 { get { return _distance_Attack2; } }

    float _originAngularSpeed;

    // Attack 1
    [SerializeField] PaladinCheckAttack _checkAttack1;
    public PaladinCheckAttack CheckAttack1 { get { return _checkAttack1; } }

    [HideInInspector] public bool StopMoving_Attack1;

    [SerializeField] float _attack1_MoveSpeed = 20f;
    public float Attack1_MoveSpeed { get { return _attack1_MoveSpeed; } }

    [Header("Effect")]
    [SerializeField] GameObject _explosion1;
    [SerializeField] GameObject _explosion2;
    [SerializeField] ParticleSystem _swordTrails;
    [SerializeField] SphereCastDamage _swordDamage;

    [Header("Audio")]
    [SerializeField] AudioClip _demoClip;
    [SerializeField] AudioClip _clip;
    [SerializeField] AudioClip _attackClip;
    [SerializeField] AudioSource _source;


    void Start()
    {
        _originAngularSpeed = _agent.angularSpeed;

        CheckAttack1.gameObject.SetActive(false);

        Event_SwordTrailsStop();
        Event_TurnOfSwordDamage();

        _animator.SetInteger("Attack Type", 2);
    }

    void Update()
    {
        
    }

    public void Event_FlashToNearPlayer()
    {
        Vector3 playerPos = Player.Instance.transform.position;

        // random position from NavMesh - near Player
        Vector2 direction2D = Random.insideUnitCircle;
        Vector3 direction = new Vector3(direction2D.x, 0f, direction2D.y);
        direction = direction.normalized;
        Vector3 randomPosition = playerPos + direction * Distance_Attack2; ;

        NavMeshHit hit;
        NavMesh.SamplePosition(randomPosition, out hit, 10f, 1);
        _agent.transform.position = hit.position;

        // look player
        Vector3 vector = playerPos - transform.position;
        vector.y = 0f;
        if (vector.magnitude > 0.0001f)
        {
            _agent.transform.rotation = Quaternion.LookRotation(vector);
        }
    }


    public void Event_StopMoving_Attack1()
    {
        StopMoving_Attack1 = true;
    }

    public void Event_TurnOnAgentRotate()
    {
        _agent.angularSpeed = _originAngularSpeed;
    }

    public void Event_TurnOffAgentRotate()
    {
        _agent.angularSpeed = 0;
    }

    public void Event_setStateSpeed(float speed)
    {
        StateSpeed = speed;
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

    void Event_SwordTrailsStop()
    {
        _swordTrails.Stop();
    }

    void Event_SwordTrailsPlay()
    {
        _swordTrails.Play();
    }

    void Event_TurnOnSwordDamage()
    {
        _swordDamage.gameObject.SetActive(true);
        _source.PlayOneShot(_attackClip);
    }

    void Event_TurnOfSwordDamage()
    {
        _swordDamage.gameObject.SetActive(false);
    }
}
