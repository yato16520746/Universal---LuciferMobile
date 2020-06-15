using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle, 
    Run,
    Idle_Aiming,
    Walk_Aiming,
    DiveForward,
    Death
}

public class Player_Delegate : MonoBehaviour
{
    [SerializeField] Player _parent;
    public Player Parent { get { return _parent; } }

    [SerializeField] Rigidbody _rb;
    public Rigidbody Rb { get { return _rb; } }

    [SerializeField] Animator _animator;

    [Space]
    [HideInInspector] public PlayerState State;
    [HideInInspector] public bool SlowDive;

    [Header("Movement")]

    [SerializeField] float _runSpeed; // 6
    public float RunSpeed { get { return _runSpeed; } }

    [SerializeField] float _walkSpeed; // 3
    public float WalkSpeed { get { return _walkSpeed; } }

    [SerializeField] float _diveSpeed = 10;
    public float DiveSpeed { get { return _diveSpeed; } }
    
    // for change Velocity over time
    [SerializeField] float _speedLerp; // 20
    public float SpeedLerp { get { return _speedLerp; } }

    // for change Quaterniton over time
    [SerializeField] float _rotateLerp; // 20
    public float RotateLerp { get { return _rotateLerp; } }

    [Header("Blend Tree Animation")]
    [SerializeField] Transform _gunLook;
    public Transform GunLook { get { return _gunLook; } }

    Vector3 _walkDirection;

    [Header("Shoot bullet")]
    readonly float _mouseRange = 0.3f;
    public float MouseRange { get { return _mouseRange; } }

    [SerializeField] Transform _shootPoint;
    [SerializeField] GameObject _bulletPref;
    [SerializeField] GameObject _shootFXPref;

    private void Update()
    {
        // fire
        if (State == PlayerState.Idle_Aiming || State == PlayerState.Walk_Aiming)
        {
            _animator.SetBool("Fire", true);
        }
        else
        {
            _animator.SetBool("Fire", false);
        }
    }

    private void LateUpdate()
    {
        // rotate GunLook
        Vector3 mousePosition = Parent.MousePosition;
        Vector3 vector = mousePosition - GunLook.position;
        vector.y = 0f;
        if (vector.magnitude > 0.1f)
        {
            GunLook.rotation = Quaternion.LookRotation(vector);
        }

        // set blend tree animation
        Vector3 moveDirection = Parent.MoveDirection;
        Vector3 designedWalkDirection = GunLook.InverseTransformDirection(moveDirection);
        _walkDirection = Vector3.Lerp(_walkDirection, designedWalkDirection, 8f * Time.deltaTime);

        _animator.SetFloat("Direction X", _walkDirection.x);
        _animator.SetFloat("Direction Z", _walkDirection.z);
    }

    public void Event_ShootBullet()
    {
        // không cho bắn đạn lúc chuyển trạng thái
        if (State != PlayerState.Idle_Aiming && State != PlayerState.Walk_Aiming)
        {
            return;
        }

        // tạo hiệu ứng lúc ra đạn
        Instantiate(_shootFXPref, _shootPoint.position, transform.rotation);

        // bắn đạn
        GameObject bullet = Instantiate(_bulletPref, _shootPoint.position, Quaternion.identity);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetDirection(transform.rotation * Vector3.forward);
    }

    public void Event_Dead()
    {
        State = PlayerState.Death;
    }

    public void Event_SlowDive()
    {
        SlowDive = true;
    }
}
