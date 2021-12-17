using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private WeaponView _template;
    [SerializeField] private GameObject _container;

    private void Start()
    {
        SetShop();
    }
    private void SetShop()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            AddItemToTheShop(_weapons[i]);
        }
    }
    private void AddItemToTheShop(Weapon weapon)
    {
        var weaponView = Instantiate(_template, _container.transform);
        weaponView.OnSellButtonClicked += OnSellButtonProcess;
        weaponView.Render(weapon);
    }

    private void OnSellButtonProcess(Weapon weapon, WeaponView weaponView)
    {
        TryToSellWeapon(weapon, weaponView);
    }
    private void TryToSellWeapon(Weapon weapon, WeaponView weaponView)
    {
        if( weapon.Price <= _player.Money)
        {
            _player.BuyWeapon(weapon);
            weapon.Buy();
            weaponView.OnSellButtonClicked -= OnSellButtonProcess;

        }
    }
}
