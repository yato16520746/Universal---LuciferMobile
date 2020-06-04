using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonB : MonoBehaviour
{
    static readonly string CanShoot_Bool = "Can Shoot";
    static readonly string PlayerHealth_Layer = "Player Health";

    [SerializeField] float _range = 4f;
    [SerializeField] bool _canShoot; // no obstacles
    readonly float _timeCheckCanShoot = 0.7f;
    float _count;
    
    [Space]
    [SerializeField] Animator _animator;

    private void Start()
    {
        if (Player.Instance)
        {
            // quay người về phía Player
            Vector3 vector = Player.Instance.transform.position - transform.position;
            vector.y = 0f;
            if (vector.magnitude > 0.1f)
            {
                Quaternion rotation = Quaternion.LookRotation(vector);
                transform.rotation = rotation;
            }
        }
    }

    private void Update()
    {
        // gọi CheckCanShoot() ở mỗi khoảng tg
        _count -= Time.deltaTime;
        if (_count < 0f)
        {
            CheckCanShoot();
            _count = _timeCheckCanShoot;
        }
    }

    // Note: hàm này chỉ nên gọi ở 1 thời điểm
    void CheckCanShoot()
    {
        if (!Player.Instance)
        {
            return;
        }

        // lấy khoảng cách đến player
        Vector3 vector = Player.Instance.transform.position - transform.position;
        vector.y = 0f;
        float distance = vector.magnitude;

        if (distance < _range)
        {
            // trong tầm, check xem có vật cản hay không
            Ray ray = new Ray();
            ray.origin = transform.position + Vector3.up;
            ray.direction = vector.normalized;

            RaycastHit hit;
            int mask = LayerMask.GetMask(PlayerHealth_Layer);
            
            if (Physics.Raycast(ray, out hit, distance, mask))
            {
                PlayerHealth playerHealth = hit.collider.GetComponent<PlayerHealth>();
                if (playerHealth)
                {
                    _canShoot = true;
                }
                else
                {
                    _canShoot = false;
                }
            }
        }
        else
        {
            _canShoot = false;
        }

        _animator.SetBool(CanShoot_Bool, _canShoot);
    }
}
