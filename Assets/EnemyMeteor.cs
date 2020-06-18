using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeteor : MonoBehaviour
{
    [Header("Boom")]
    [SerializeField] Transform _boomTransform;
    [SerializeField] Rigidbody _boomRb;
    [SerializeField] Animator _boomAnimator;
    [SerializeField] float _speed = 10f;
    [SerializeField] float _height = 10f;
    [SerializeField] float _randomRange = 3f;
    [SerializeField] float _delay = 0.5f;
    float _animationSpeed = 0f;
    float _offset;
    bool _goDown = false;
    [SerializeField] float _lerpSpeed = 1f;
    Vector3 _designedVelocity;


    [Header("Explosion")]
    [SerializeField] GameObject _explosion;
    [SerializeField] AudioClip _clip;
    [SerializeField] AudioSource _audioSource;

    void Start()
    {
        // offset
        _offset = _boomTransform.position.y - transform.position.y;

        // random position
        Vector3 boomPosition = transform.position;
        boomPosition.y += _height;

        Vector3 insideSphere = Random.insideUnitSphere;
        insideSphere.y = 0f;

        boomPosition += insideSphere * _randomRange;
        _boomTransform.position = boomPosition;


        Vector3 direction = transform.position - boomPosition;
        _designedVelocity = direction.normalized * _speed;

        _explosion.SetActive(false);

        StartCoroutine(GoDown(_delay));
    }

    void Update()
    {
        if (_goDown && _boomTransform.position.y - transform.position.y <= _offset)
        {
            _goDown = false;
            _boomAnimator.SetTrigger("Disappear");

            _explosion.SetActive(true);
            _audioSource.PlayOneShot(_clip);
        }

        if (!_goDown)
        {
            // explose
            _boomRb.velocity = Vector3.zero;
            _animationSpeed = Mathf.Lerp(_animationSpeed, 0f, 5f * Time.deltaTime);
        }
        else
        {
            _boomRb.velocity = Vector3.Lerp(_boomRb.velocity, _designedVelocity, _lerpSpeed * Time.deltaTime);
            _animationSpeed = Mathf.Lerp(_animationSpeed, 1f, 5f * Time.deltaTime);
        }

        _boomAnimator.SetFloat("Speed", _animationSpeed);
    }

    IEnumerator GoDown(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        _goDown = true;
    }
}
