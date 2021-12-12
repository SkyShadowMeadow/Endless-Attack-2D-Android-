using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "New Wave", order = 20)]

public class Wave : ScriptableObject
{
    [SerializeField] private List<Enemy> _enemyTypes;
    [Range(1, 20)] [SerializeField] private int _numberOfEnemies;
    [Range(1, 5)] public int DifficultyLevel;
    [SerializeField] private float _durationTime;

    public List<Enemy> EnemyTypes => _enemyTypes;
    public int NumberOfEnemies => _numberOfEnemies;
    public float DurationTime => _durationTime;

}
