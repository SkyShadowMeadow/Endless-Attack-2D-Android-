using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlingState : IState
{
    private readonly Animator _animator;
    private readonly int _isIdling = Animator.StringToHash("IsIdling");

    public IdlingState(Animator animator)
    {
        _animator = animator;
    } 

    public void OnEnter()
    {
        _animator.SetBool(_isIdling, true);
    }

    public void OnExit()
    {
        _animator.SetBool(_isIdling, false);
    }

    public void Tick()
    {}
}
