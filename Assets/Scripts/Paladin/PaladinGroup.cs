using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinGroup : MonoBehaviour
{
    [SerializeField] Animator _statueAnimator;
    [SerializeField] GameObject _paladin;

    [Space]
    [SerializeField] float _delayTime = 1.25f;
    bool _trigger = false;

    private void Start()
    {
        _paladin.SetActive(false);
    }

    private void Update()
    {
        if (!_trigger && Input.GetKeyDown(KeyCode.P))
        {
            _trigger = true;
            Trigger();
        }
    }

    void Trigger()
    {
        _statueAnimator.SetTrigger("Dissapear");
        _statueAnimator.SetTrigger("Move");
        _paladin.SetActive(true);
    }

    IEnumerator PaladinAppear(float delay)
    {
        yield return new WaitForSeconds(delay);

        _statueAnimator.gameObject.SetActive(false);
    }
}
