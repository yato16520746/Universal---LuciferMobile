using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCastDamage : MonoBehaviour
{
    [SerializeField] LayerMask _mask;
    [SerializeField] float _radius = 0.2f;
    [SerializeField] float _distance;

    private void Start()
    {

    }

    void Update()
    {
        RaycastHit hit;
        Vector3 position = transform.position + Vector3.up;
        bool isHit = Physics.SphereCast(position, _radius, transform.forward, out hit, _distance, _mask);

        if (isHit)
        {
            PlayerHealth playerHealth = hit.collider.GetComponent<PlayerHealth>();
            if (playerHealth)
            {
                playerHealth.AddDamage(-10);
            }

            gameObject.SetActive(false);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        RaycastHit hit;
        Vector3 position = transform.position + Vector3.up;
        bool isHit = Physics.SphereCast(position, _radius, transform.forward, out hit, _distance, _mask);

        if (isHit)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }
        Gizmos.DrawRay(position, transform.forward * _distance);
        Gizmos.DrawWireSphere(position + transform.forward * _distance, _radius);

    }
#endif
}