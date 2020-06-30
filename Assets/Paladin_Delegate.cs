using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin_Delegate : MonoBehaviour
{
    [SerializeField] GameObject _explosion1;
    [SerializeField] GameObject _explosion2;

    [Header("Audio")]
    [SerializeField] AudioClip _demoClip;
    [SerializeField] AudioClip _clip;
    [SerializeField] AudioSource _source;

    void Event_PowerUp()
    {
        _explosion1.SetActive(true);
        _explosion2.SetActive(true);
        _source.PlayOneShot(_clip);

        ShakeCamera.Instance.ShouldShake = true;
    }

    void Event_PlayDemoClip()
    {
        _source.PlayOneShot(_demoClip);
    }
}
