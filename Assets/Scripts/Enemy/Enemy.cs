using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private Animator _animator;
    private Rigidbody2D _rigidBody;
    private AnimationStatus _animationStatus;
    private bool _isDying;
    private bool _deathIsFinished;
    private bool _playerIsDead;

    private EnemyStateMachine _enemyStateMachine;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _animationStatus = GetComponentInChildren<AnimationStatus>();

        _enemyStateMachine = new EnemyStateMachine();

        IdlingState idlingState = new IdlingState(_animator);
        MovingState movingState = new MovingState(_animator, this, _speed, _target);
        AttackState attackState = new AttackState(_animator, this);
        DeathState deathState = new DeathState(_animator, this);

        At(idlingState, movingState, HasTargetInRange());
        At(idlingState, deathState, HasDied());
        At(attackState, deathState, HasDied());
        At(movingState, attackState, HasReachedThePlayer());
        At(movingState, deathState, HasDied());

        _enemyStateMachine.SetState(idlingState);

        Func<bool> HasTargetInRange() => () => movingState.HasTargetInRange() && !_playerIsDead;
        Func<bool> HasDied() => () => GetLiveStatus();
        Func<bool> HasReachedThePlayer() => () => !movingState.HasTargetInRange() && !_playerIsDead;

        void At(IState to, IState from, Func<bool> condition) => _enemyStateMachine.AddTransition(to, from, condition);


    }

    public void GetDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
            _isDying = true;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private bool GetLiveStatus() => _isDying;

    public bool DeathAnimationStatus => _animationStatus.GetDeathAnimationStatus;

    private void FixedUpdate() => _enemyStateMachine.Tick();
}
