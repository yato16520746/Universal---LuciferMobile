using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    static string Dead_Trigger = "Dead";
    static string Hit_Trigger = "Hit";
    static string HitType_Int = "Hit Type";

    // singleton
    static PlayerHealth _instance;
    public static PlayerHealth Instance { get { return _instance; } }

    [SerializeField] Slider _HPSlider;
    [SerializeField] int _maxHP = 100;
    int _currentHP;

    [SerializeField] Animator _animator;
    bool _allowHitAnimation; 

    public bool IsDead { get { return (_currentHP <= 0); } }

   

    private void Start()
    {
        _instance = this;

        _currentHP = _maxHP;

        _HPSlider.maxValue = _maxHP;
        _HPSlider.value = _currentHP;
    }

    public void AddDamage(int amount)
    {
        if (_currentHP <= 0)
        {
            return;
        }

        if (amount >= 0)
        {
            amount = -amount;
        }

        _currentHP += amount;

        if (_currentHP > _maxHP)
        {
            _currentHP = _maxHP;
        }
        else if (_currentHP < 0)
        {
            _currentHP = 0;
        }

        _HPSlider.value = _currentHP;

        _animator.SetTrigger(Hit_Trigger);
        _animator.SetInteger(HitType_Int, Random.Range(0, 3));

        // death animation
        if (_currentHP <= 0)
        {
            _animator.SetTrigger(Dead_Trigger);
        }
    }
}
