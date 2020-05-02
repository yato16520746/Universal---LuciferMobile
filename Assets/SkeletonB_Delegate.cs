using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonB_Delegate : MonoBehaviour
{
    [SerializeField] Transform _arrowTransform;
    [SerializeField] GameObject _arrowPref;

    public void ShootArrow()
    {
        GameObject arrow = Instantiate(_arrowPref, _arrowTransform.position, _arrowTransform.rotation);        
    }
}
