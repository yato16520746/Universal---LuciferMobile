using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum SkeletonB_State
{
    Appear,
    Idle,
    ChasingPlayer,
    DrawArrow,
    Shoot,
    RunningRandom,
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

    [SerializeField] GameObject _warningLine;

    [Space]
    // game AI
    [SerializeField] NavMeshAgent _navMeshAgent;
    public NavMeshAgent NavMeshAgent { get { return _navMeshAgent; } }

    [SerializeField] Animator _animator;

    // trạng thái của SkeletonB
    [HideInInspector] public SkeletonB_State State;
    [HideInInspector] public bool RotatingWhenShootArrow;

    private void Start()
    {
        DisableArrowGraphic();
        Event_DisableWarningLine();
    }

    // Events
    public void ShootArrow()
    {
        GameObject arrow = Instantiate(_arrowPref, _arrowTransform.position, _arrowTransform.rotation);
        arrow.transform.localScale = _arrowTransform.lossyScale;

        Arrow arrowScript = arrow.GetComponent<Arrow>();
        arrowScript.SetUp(_parentTransform.rotation);

        DisableArrowGraphic();

        if (Random.Range(0, 2) == 0)
        {
            _animator.SetBool("Running Random", true);
        }

        RotatingWhenShootArrow = false;
    }

    public void EnableArrowGraphic()
    {
        _arrowGraphic.SetActive(true);
    }

    private void DisableArrowGraphic()
    {
        _arrowGraphic.SetActive(false);
    }

    void Event_EnableWarningLine()
    {
        _warningLine.SetActive(true);
    }

    void Event_DisableWarningLine()
    {
        _warningLine.SetActive(false);
    }
}
