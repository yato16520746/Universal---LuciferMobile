using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering;

public class NewBehaviourScript : MonoBehaviour
{
    public Volume Volume;

    private Bloom _bloom;

    public GameObject ExplosionPref;
    public Transform Transform;

    float _count;
    float _count2;
    //public List<ColorParameter> Colors;

    private void Start()
    {
        //Volume.profile.TryGet(out _bloom);
        //Volume.profile.TryGetSettings(out _bloom);

        _count = 127;
        _count2 = 30;
    }

    private void Update()
    {
        _count -= Time.deltaTime;
        if (_count < 0)
        {
            Instantiate(ExplosionPref, Transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
        }

        //_count2 -= Time.deltaTime;
        //if (_count2 < 0)
        //{
        //    _count2 = 20;
        //    ColorParameter color = Colors[Random.Range(0, Colors.Count)];
        //    _bloom.color = color;
        //}
    }
}
