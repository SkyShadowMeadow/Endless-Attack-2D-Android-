using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : IState
{
    private readonly Animator _animator;
    private readonly Enemy _enemy;
    private readonly int _isDead = Animator.StringToHash("IsDead");

    public DeathState(Animator animator, Enemy enemy)
    {
        _animator = animator;
        _enemy = enemy;
    }
    public void OnEnter()
    {
        _animator.SetBool(_isDead, true);
    }

    public void OnExit()
    {
        _enemy.Die();
    }

    public void Tick()
    {
        if (_enemy.GetDeathAnimationStatus())
            OnExit();
    }
}
