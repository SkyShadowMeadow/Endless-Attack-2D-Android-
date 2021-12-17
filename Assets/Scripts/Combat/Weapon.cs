using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBought;
    [SerializeField] protected Bullet Bullet;

    public string Name => _name;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBought => _isBought;

    public abstract void Shoot(Transform shootPoint);

    public void Buy() => _isBought = true;
}
