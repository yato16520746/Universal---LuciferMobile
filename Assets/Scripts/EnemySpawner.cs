using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Space]
    [SerializeField] float _delayTime = 1.25f;
    Vector3 _position;

    [Space]
    [SerializeField] GameObject _enemyPref;

    [Space]
    [SerializeField] GameObject _spawningFX;

    private void Start()
    {
        StartCoroutine(SpawnEnemy(Random.Range(1f, 3f)));
    }

    IEnumerator SpawnEnemy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        _position = new Vector3(Random.Range(-6, 6), 0, Random.Range(-6, 6));

        Instantiate(_spawningFX, _position + new Vector3(0f, 0.1f, 0f), _spawningFX.transform.rotation);

        // spawn enenmy GO
        StartCoroutine(SpawnEnemyGO(_delayTime));
    }

    IEnumerator SpawnEnemyGO(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        Instantiate(_enemyPref, _position, _enemyPref.transform.rotation);

        // spawn enemy again
        StartCoroutine(SpawnEnemy(Random.Range(2f, 5f)));
    }
}
