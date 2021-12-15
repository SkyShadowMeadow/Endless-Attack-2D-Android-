using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveProgressBar : Bar
{
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        Slider.value = 0;
        _spawner.EnemySpawned += OnValueChanged;
    }
    private void OnDisable()
    {
        _spawner.EnemySpawned -= OnValueChanged;

    }
}
