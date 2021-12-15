using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int money = 0;

    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    private Animator _animator;
    private int _currentHealth;
    private Weapon _currentWeapon;

    public event UnityAction<int, int> HealthIsChange;
   
    private void Start()
    {
        _currentHealth = _health;
        _currentWeapon = _weapons[0];
        _animator = GetComponent<Animator>();
    }

    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_shootPoint);
        }
    }

    public void AddMoney(int reward) => money += reward;

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthIsChange?.Invoke(_currentHealth, _health);
        if (_currentHealth <= 0)
        {
            Debug.Log("Player is dead");
        }
    }
}
