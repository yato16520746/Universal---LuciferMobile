using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment_Editor : MonoBehaviour
{
#if UNITY_EDITOR

    [Header("Invisible Navigation")]
    //[SerializeField] Transform _invisibleNavigation;
    [SerializeField] List<GameObject> _obstacles;
    [SerializeField] bool _isInvisible = false;

    private void OnValidate()
    {
        //if (_invisibleNavigation)
        //{
        //    foreach (MeshRenderer mesh in _invisibleNavigation.GetComponentsInChildren<MeshRenderer>())
        //    {
        //        mesh.enabled = _isInvisible;
        //    }
        //}

        foreach (GameObject go in _obstacles)
        {
            MeshRenderer mesh = go.GetComponent<MeshRenderer>();
            mesh.enabled = _isInvisible;
        }
    }
#endif
}
