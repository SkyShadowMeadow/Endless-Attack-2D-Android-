
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _enemyWaves;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _spawnPoint;
    private int _currentWave;
    private float _durationOfTheCurrentWave;
    private List<Enemy> _enemiesInTheCurrentWave;
    private int _numberOfEnemiesInTheCurrentWave;
    private float _timeBetweenSpawnes;
    private float _delayBetweenWaves = 5f;


    private void Awake()
    {
        _enemyWaves = _enemyWaves.OrderBy(x => x.DifficultyLevel).ToList(); 
    }
    void Start()
    {
        _currentWave = 0;
        StartCoroutine(PerfomSpawnRoutine());
    }

    private List<Wave> SortEnemyWavesByDifficulty()
    {
        IEnumerable<Wave> waves = _enemyWaves.OrderBy(u => u.DifficultyLevel);
        List<Wave> sortedWaves = new List<Wave>();
        foreach (Wave wave in waves)
        {
            sortedWaves.Add(wave);
        }
        return sortedWaves;
    }
    private void GetAllInformationOfTheWave()
    {
        _enemiesInTheCurrentWave = _enemyWaves[_currentWave].EnemyTypes;
        _durationOfTheCurrentWave = _enemyWaves[_currentWave].DurationTime;
        _numberOfEnemiesInTheCurrentWave = _enemyWaves[_currentWave].NumberOfEnemies;
        _timeBetweenSpawnes = _durationOfTheCurrentWave / _numberOfEnemiesInTheCurrentWave;
    }
    private void InstantiateEnemy()
    {
            Enemy randomEnemyInWave = _enemiesInTheCurrentWave[Random.Range(0, _enemiesInTheCurrentWave.Count)];
            Enemy currentEnemy = Instantiate(randomEnemyInWave, _spawnPoint.position, Quaternion.identity, _spawnPoint).GetComponent<Enemy>();
            currentEnemy.Init(_target);
    }
    IEnumerator PerfomSpawnRoutine()
    {
        GetAllInformationOfTheWave();

        while (_numberOfEnemiesInTheCurrentWave != 0)
        {
            InstantiateEnemy();
            _numberOfEnemiesInTheCurrentWave--;
            yield return new WaitForSeconds(_timeBetweenSpawnes);
        }

        _currentWave++;
        yield return new WaitForSeconds(_delayBetweenWaves);
        if (_currentWave < _enemyWaves.Count) StartCoroutine(PerfomSpawnRoutine());
    }
}
