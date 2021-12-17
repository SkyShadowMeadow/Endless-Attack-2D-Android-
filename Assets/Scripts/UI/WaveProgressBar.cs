using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveProgressBar : Bar
{
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.EnemySpawned += OnValueChanged;
        Slider.value = 0;

    }
    private void OnDisable()
    {
        _spawner.EnemySpawned -= OnValueChanged;

    }
}
