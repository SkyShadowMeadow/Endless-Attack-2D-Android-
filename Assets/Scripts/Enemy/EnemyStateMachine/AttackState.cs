using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    private readonly Animator _animator;
    private readonly Enemy _enemy;
    private readonly int _isAttacking = Animator.StringToHash("IsAttacking");
    private float _decounter;
    private float _delayBetweenAttacks = 0.75f;

    public AttackState(Animator animator, Enemy enemy)
    {
        _animator = animator;
        _enemy = enemy;
    }
    public void OnEnter()
    {
        _animator.SetBool(_isAttacking, true);
        _decounter = _delayBetweenAttacks;
    }

    public void OnExit()
    {
        _animator.SetBool(_isAttacking, false);
        _decounter = _delayBetweenAttacks;
    }

    public void Tick()
    {
        _decounter -= Time.deltaTime;
        if(_decounter <= 0)
        {
            _enemy.GiveDamage();
            _decounter = _delayBetweenAttacks;
        }
    }
}
