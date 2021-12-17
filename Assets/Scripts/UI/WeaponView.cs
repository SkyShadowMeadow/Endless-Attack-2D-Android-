using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;
    private Weapon _weapon;

    public event UnityAction<Weapon, WeaponView> OnSellButtonClicked;

    private void OnEnable()
    {
       _sellButton.onClick.AddListener(OnClickButton);
       _sellButton.onClick.AddListener(LockTheSellButton);
    }
    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnClickButton);
        _sellButton.onClick.RemoveListener(LockTheSellButton);
    }

    private void OnClickButton()
    {
        OnSellButtonClicked?.Invoke(_weapon, this);
    }
    private void LockTheSellButton()
    {
        if (_weapon.IsBought) _sellButton.interactable = false;
    }
    public void Render(Weapon weapon)
    {
        _weapon = weapon;
        _label.text = _weapon.Name;
        _price.text = _weapon.Price.ToString();
        _icon.sprite = _weapon.Icon;
    }
}
