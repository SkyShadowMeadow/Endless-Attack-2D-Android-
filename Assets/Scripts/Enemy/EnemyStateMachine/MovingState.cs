using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState : IState
{
    private readonly Animator _animator;
    private readonly Enemy _enemy;
    private readonly float _speed;
    private readonly Transform _target;
    private readonly int _isMoving = Animator.StringToHash("IsWalking");

    private readonly float _minDistanceToTarget = 0.6f;
    private Vector2 _targetPosition;

    public MovingState(Animator animator, Enemy enemy, float speed, Transform target)
    {
        _animator = animator;
        _enemy = enemy;
        _speed = speed;
        _target = target;
    }

    public void OnEnter()
    {
        _animator.SetBool(_isMoving, true);
        _targetPosition = new Vector2(_target.transform.position.x, _enemy.transform.position.y);
    }

    public void OnExit()
    {
        _animator.SetBool(_isMoving, false);
    }

    public void Tick()
    {
        _enemy.transform.position = Vector2.MoveTowards(_enemy.transform.position,
                                            _targetPosition, _speed * Time.deltaTime);
    }

    public bool HasTargetInRange() => Vector2.Distance(_enemy.transform.position,
                                        _targetPosition) > _minDistanceToTarget;
}
