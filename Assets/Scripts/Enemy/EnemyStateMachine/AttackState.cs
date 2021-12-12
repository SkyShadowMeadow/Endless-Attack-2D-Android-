using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    private readonly Animator _animator;
    private readonly Enemy _enemy;
    private readonly int _isAttacking = Animator.StringToHash("IsAttacking");

    public AttackState(Animator animator, Enemy enemy)
    {
        _animator = animator;
        _enemy = enemy;
    }
    public void OnEnter()
    {
        _animator.SetBool(_isAttacking, true);
    }

    public void OnExit()
    {
        _animator.SetBool(_isAttacking, false);
    }

    public void Tick()
    {
    }
}
