using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemy : MonoBehaviour
{
    [SerializeField] List<GameObject> _enemyGameObjects;

    private void OnTriggerEnter(Collider other)
    {
        Skeleton skeleton = other.GetComponent<Skeleton>();

        if (skeleton)
        {
            _enemyGameObjects.Add(skeleton.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Skeleton skeleton = other.GetComponent<Skeleton>();

        if (skeleton)
        {
            _enemyGameObjects.Remove(skeleton.gameObject);
        }
    }

    // calculating
    public GameObject Get_Target()
    {
        // no enemy, return null
        if (_enemyGameObjects.Count <= 0)
        {
            return null;
        }

        // clear the list - remove null
        int i = 0;
        while (i < _enemyGameObjects.Count)
        {
            if (_enemyGameObjects[i] == null)
            {
                _enemyGameObjects.RemoveAt(i);
            }
            else
            {
                i++;
            }
        }

        // no enemy, return null
        if (_enemyGameObjects.Count <= 0)
        {
            return null;
        }

        //  Default = first gameObject
        GameObject target = _enemyGameObjects[0];
        float distance = (transform.position - _enemyGameObjects[0].transform.position).magnitude;

        // check gameObject[1..n]
        for (i = 1; i < _enemyGameObjects.Count; i++)
        {
            float newDistance = (transform.position - _enemyGameObjects[i].transform.position).magnitude;

            if (newDistance < distance) // enemy[i] closer than current target
            {
                target = _enemyGameObjects[i];
                distance = newDistance;
            }
        }

        return target;
    }
}
