﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class MeshCombiner : MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {
        Combine();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Combine();
        }
    }

   

    void Combine()
    {
        Quaternion oldRot = transform.rotation;
        Vector3 oldPos = transform.position;

        transform.rotation = Quaternion.identity;
        transform.position = Vector3.zero;

        MeshFilter[] filters = GetComponentsInChildren<MeshFilter>();

        Mesh finalMesh = new Mesh();

        CombineInstance[] combiners = new CombineInstance[filters.Length];

        for (int a = 0; a < filters.Length; a++)
        {
            if (filters[a].transform == transform)
            {
                continue;
            }

            combiners[a].subMeshIndex = 0;
            combiners[a].mesh = filters[a].sharedMesh;
            combiners[a].transform = filters[a].transform.localToWorldMatrix;
        }

        finalMesh.CombineMeshes(combiners);

        GetComponent<MeshFilter>().sharedMesh = finalMesh;

        transform.rotation = oldRot;
        transform.position = oldPos;

        for (int a = 0; a < transform.childCount; a++)
        {
            transform.GetChild(a).gameObject.SetActive(false);
        }
    }
}
