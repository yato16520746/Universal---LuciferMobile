using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Space]
    [SerializeField] float _delayTime = 1.25f;
    float _count = 0;
    bool _spawn = false;
    Vector3 _position;

    [Space]
    [SerializeField] GameObject _enemyPref;

    [Space]
    [SerializeField] GameObject _spawningFX;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _position = new Vector3(Random.Range(-6, 6), 0, Random.Range(-6, 6));

            Instantiate(_spawningFX, _position + new Vector3(0f, 0.1f, 0f), _spawningFX.transform.rotation);

            _spawn = true;
        }

        if (_spawn)
        {
            _count += Time.deltaTime;
            if (_count > _delayTime)
            {
                _count = 0;
                _spawn = false;

                Instantiate(_enemyPref, _position, _enemyPref.transform.rotation);
            }
        }
    }
}
