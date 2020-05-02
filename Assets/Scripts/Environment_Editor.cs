using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment_Editor : MonoBehaviour
{
#if UNITY_EDITOR

    [Header("Invisible Obstacles")]
    [SerializeField] Transform _invisibleObstacles;
    [SerializeField] bool _isInvisible = false;

    private void OnValidate()
    {
        foreach (MeshRenderer mesh in _invisibleObstacles.GetComponentsInChildren<MeshRenderer>())
        {
            mesh.enabled = _isInvisible;
        }
    }
#endif
}
