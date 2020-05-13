using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum SkeletonB_State
{
    Appear,
    Idle,
    Run,
    PrepareShoot,
    Shoot,
    Death
}

public class SkeletonB_Delegate : MonoBehaviour
{
    [Space]
    [SerializeField] Transform _arrowTransform;
    [SerializeField] GameObject _arrowPref;
    [SerializeField] GameObject _arrowGraphic;

    [SerializeField] Transform _shootTransform;
    public Transform ShootTransform { get { return _shootTransform; } }

    [SerializeField] Transform _parentTransform;
    public Transform ParentTransform { get { return _parentTransform; } }

    [Space]
    // game AI
    [SerializeField] NavMeshAgent _navMeshAgent;
    public NavMeshAgent NavMeshAgent { get { return _navMeshAgent; } }

    // trạng thái của SkeletonB
    [HideInInspector] public SkeletonB_State State;

    private void Start()
    {
        DisableArrowGraphic();
    }

    // Events
    public void ShootArrow()
    {
        GameObject arrow = Instantiate(_arrowPref, _arrowTransform.position, _arrowTransform.rotation);
        DisableArrowGraphic();
    }

    public void EnableArrowGraphic()
    {
        _arrowGraphic.SetActive(true);
    }

    private void DisableArrowGraphic()
    {
        _arrowGraphic.SetActive(false);
    }
}
