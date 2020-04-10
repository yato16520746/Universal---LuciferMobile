using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle, 
    Run,
    Idle_Aiming,
    Walk_Aiming
}

// class chỉ được truy xuất trong nội bộ Player
public class Player_Delegate : MonoBehaviour
{
    // joystick
    [SerializeField] Joystick _joystick;
    public Joystick Joystick { get { return _joystick; } }
    public Vector3 JoystickDirection
    {
        get
        {
            return (new Vector3(Joystick.Horizontal, 0f, Joystick.Vertical)).normalized;
        }
    }

    // rigidbody
    [SerializeField] Rigidbody _rb;
    public Rigidbody Rb { get { return _rb; } }

    // animator
    [SerializeField] Animator _animator;
    Vector3 _walkDirection;

    // tìm kiếm mục tiêu DetectEnemy
    [SerializeField] DetectEnemy _detectEnemy;
    public DetectEnemy DetectEnemy { get { return _detectEnemy; } }

    // mục tiêu hiện tại
    GameObject _target;
    public GameObject Target { get { return _target; } }
    int _count_GetTarget = 0;

    // game object luôn xoay về mục tiêu
    [SerializeField] GameObject _lookingForTarget;
    public GameObject LookingForTarget { get { return _lookingForTarget; } }

    // nút Firing
    [SerializeField] MyButton _fireButton;
    public MyButton FireButton { get { return _fireButton; } }

    // các thuộc tính ...
    [Space]

    // state của người chơi, cẩn thận vì nó ở chế độ Public
    public PlayerState State;

    // tốc độ chạy
    [SerializeField] float _runSpeed;
    public float RunSpeed { get { return _runSpeed; } }

    // tốc độ di chuyển
    [SerializeField] float _walkSpeed;
    public float WalkSpeed { get { return _walkSpeed; } }
    
    // tốc độ thay đổi vận tốc
    [Space]
    [SerializeField] float _speedLerp;
    public float SpeedLerp { get { return _speedLerp; } }

    // tốc độ xoay người
    [Space]
    [SerializeField] float _rotateLerp;
    public float RotateLerp { get { return _rotateLerp; } }

    // hàm update
    private void Update()
    {
        // set tham số Moving của animation
        if (Joystick.Vertical == 0 && Joystick.Horizontal == 0)
        {
            _animator.SetBool("Moving", false);    
        }
        else
        {
            _animator.SetBool("Moving", true);
        }

        // set tham số Firing của animation
        _animator.SetBool("Firing", _fireButton.Press);

        // nếu ấn nút Fire, thì liên tục lấy mục tiêu
        if (_fireButton.Press)
        {
            if (!Target)
            {
                _target = DetectEnemy.Get_Target();
            }    
        }
        // nếu không ấn nút Fire, lấy mục tiêu theo chu kỳ
        else
        {
            _count_GetTarget++;
            if (_count_GetTarget > 5)
            {
                _count_GetTarget = 0;
                _target = DetectEnemy.Get_Target();
            }
        }


        if (Target)
        {
            // xoay LookingForTarget về phía về mục tiêu
            Vector3 vector = Target.transform.position - transform.position;
            vector.y = 0f;
            if (vector.magnitude > 0.1f)
            {
                Quaternion rotation = Quaternion.LookRotation(vector);
                LookingForTarget.transform.rotation = Quaternion.Lerp(LookingForTarget.transform.rotation, rotation, 20 * Time.deltaTime);
            }

            // set tham số Walk_Aiming dựa vào Joystick và transform của LookForTarget
            if (JoystickDirection.magnitude > 0.1f)
            {
                Vector3 designedWalkDirection = LookingForTarget.transform.InverseTransformDirection(JoystickDirection);
                _walkDirection = Vector3.Lerp(_walkDirection, designedWalkDirection, 5f * Time.deltaTime);

                _animator.SetFloat("Direction X", _walkDirection.x);
                _animator.SetFloat("Direction Z", _walkDirection.z);
            }
        }
    }
}
