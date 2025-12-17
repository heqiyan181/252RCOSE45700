using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public enum SpawnModes
{
    Fixed,
    Random
}

public class Spawner : MonoBehaviour
{
    public static Action OnWaveCompleted;

    [Header("Settings")]
    [SerializeField] private SpawnModes spawnMode = SpawnModes.Fixed;
    [SerializeField] private int enemyCount = 10;
    [SerializeField] private float delayBtwWaves = 1f;

    [Header("Win Settings")]
    [SerializeField] private int finalWave = 10;

    [Header("Fixed Delay")]
    [SerializeField] private float delayBtwSpawns;

    [Header("Random Delay")]
    [SerializeField] private float minRandomDelay;
    [SerializeField] private float maxRandomDelay;

    [Header("Poolers")]
    [SerializeField] private ObjectPooler enemyWave10Pooler;
    [SerializeField] private ObjectPooler enemyWave11To20Pooler;

    private float _spawnTimer;
    private int _enemiesSpawned;
    private int _enemiesRamaining;

    private Waypoint _waypoint;
    private bool _levelFinished = false;

    private void Start()
    {
        _waypoint = GetComponent<Waypoint>();
        _enemiesRamaining = enemyCount;
    }

    private void Update()
    {
        if (_levelFinished) return;

        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer < 0)
        {
            _spawnTimer = GetSpawnDelay();
            if (_enemiesSpawned < enemyCount)
            {
                _enemiesSpawned++;
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy()
    {
        ObjectPooler pooler = GetPooler();
        if (pooler == null) pooler = enemyWave10Pooler;
        if (pooler == null) return;

        GameObject newInstance = pooler.GetInstanceFromPool();
        if (newInstance == null) return;

        Enemy enemy = newInstance.GetComponent<Enemy>();
        if (enemy == null) return;

        enemy.Waypoint = _waypoint;
        enemy.ResetEnemy();

        enemy.transform.localPosition = transform.position;
        newInstance.SetActive(true);
    }

    private float GetSpawnDelay()
    {
        if (spawnMode == SpawnModes.Fixed) return delayBtwSpawns;
        return Random.Range(minRandomDelay, maxRandomDelay);
    }

    private ObjectPooler GetPooler()
    {
        return enemyWave10Pooler;
    }

    private IEnumerator NextWave()
    {
        yield return new WaitForSeconds(delayBtwWaves);

        if (_levelFinished) yield break;

        _enemiesRamaining = enemyCount;
        _spawnTimer = 0f;
        _enemiesSpawned = 0;
    }

    private void RecordEnemy(Enemy enemy)
    {
        if (_levelFinished) return;

        _enemiesRamaining--;
        if (_enemiesRamaining > 0) return;

        int currentWave = LevelManager.Instance.CurrentWave;

        if (currentWave >= finalWave)
        {
            _levelFinished = true;

            Time.timeScale = 1f;
            PlayerPrefs.SetInt("Unlock", 2);
            PlayerPrefs.Save();

            ShowVictory sv = FindObjectOfType<ShowVictory>();
            if (sv != null) sv.Show();

            return;
        }

        OnWaveCompleted?.Invoke();
        StartCoroutine(NextWave());
    }

    private void OnEnable()
    {
        Enemy.OnEndReached += RecordEnemy;
        EnemyHealth.OnEnemyKilled += RecordEnemy;
    }

    private void OnDisable()
    {
        Enemy.OnEndReached -= RecordEnemy;
        EnemyHealth.OnEnemyKilled -= RecordEnemy;
    }
}
