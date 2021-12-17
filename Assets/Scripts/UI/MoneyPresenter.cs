using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyPresenter : MonoBehaviour
{
    [SerializeField] private TMP_Text _money;
    [SerializeField] private Player _player;
    private void OnEnable()
    {
        _money.text = _player.Money.ToString();
    }
}
