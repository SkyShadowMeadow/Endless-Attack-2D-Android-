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
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _animationStatus = GetComponentInChildren<AnimationStatus>();

        _enemyStateMachine = new EnemyStateMachine();

        IdlingState idlingState = new IdlingState(_animator);
        MovingState movingState = new MovingState(_animator, this, _speed, _target);
        AttackState attackState = new AttackState();
        DeathState deathState = new DeathState(_animator, this);

        At(idlingState, movingState, HasTargetInRange());
        At(idlingState, movingState, HasDied());
        At(idlingState, deathState, HasDied());
        At(attackState, deathState, HasDied());
        At(movingState, attackState, HasReachedThePlayer());

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
        Destroy(this);
    }

    private bool GetLiveStatus() => _isDying;

    public bool GetDeathAnimationStatus() => _animationStatus.GetDeathAnimationStatus;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
