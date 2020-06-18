using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static int MonsterAmount = 0;

    [Space]
    [SerializeField] float _delayTime = 1.25f;
    Vector3 _position;
    [SerializeField] float _timeSpawn = 4f;

    [Space]
    [SerializeField] GameObject _enemyPref;

    [Space]
    [SerializeField] GameObject _spawningFX;

    private void Awake()
    {
        MonsterAmount = 0;
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy(Random.Range(_timeSpawn - 0.2f, _timeSpawn + 0.2f)));
    }

    private void Update()
    {
        _timeSpawn -= 0.2f* Time.deltaTime;
        if (_timeSpawn < 1.5f)
        {
            _timeSpawn = 1.5f;
        }
    }

    IEnumerator SpawnEnemy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        if (MonsterAmount < 3)
        {

            _position = new Vector3(Random.Range(-6, 6), 0, Random.Range(-6, 6));

            Instantiate(_spawningFX, _position + new Vector3(0f, 0.1f, 0f), _spawningFX.transform.rotation);
        }

        // spawn enenmy GO
        StartCoroutine(SpawnEnemyGO(_delayTime));
    }

    IEnumerator SpawnEnemyGO(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        if (MonsterAmount < 3)
        {
            Instantiate(_enemyPref, _position, _enemyPref.transform.rotation);
        }

        // spawn enemy again
        StartCoroutine(SpawnEnemy(Random.Range(2f, 5f)));
    }
}
