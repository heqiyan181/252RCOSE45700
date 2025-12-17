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

    // ✅ 修改这里：最后一波 = 10（因为你只有10波）
    [Header("Win Settings")]
    [SerializeField] private int finalWave = 10;

    [Header("Fixed Delay")]
    [SerializeField] private float delayBtwSpawns;

    [Header("Random Delay")]
    [SerializeField] private float minRandomDelay;
    [SerializeField] private float maxRandomDelay;

    [Header("Poolers")]
    [SerializeField] private ObjectPooler enemyWave10Pooler;
    // 如果你删除了其他波数，可以删除或禁用这些引用
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
        if (pooler == null) 
        {
            // 如果获取不到 pooler，使用默认的
            pooler = enemyWave10Pooler;
        }

        GameObject newInstance = pooler.GetInstanceFromPool();
        Enemy enemy = newInstance.GetComponent<Enemy>();
        enemy.Waypoint = _waypoint;
        enemy.ResetEnemy();

        enemy.transform.localPosition = transform.position;
        newInstance.SetActive(true);
    }

    private float GetSpawnDelay()
    {
        if (spawnMode == SpawnModes.Fixed) return delayBtwSpawns;
        return GetRandomDelay();
    }

    private float GetRandomDelay()
    {
        return Random.Range(minRandomDelay, maxRandomDelay);
    }

    private ObjectPooler GetPooler()
    {
        int currentWave = LevelManager.Instance.CurrentWave;

        // 简化：所有波都用同一个 pooler
        return enemyWave10Pooler;
        
        /* 或者保留两波：
        if (currentWave <= 10) return enemyWave10Pooler;
        return enemyWave11To20Pooler;
        */
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
        if (_enemiesRamaining <= 0)
        {
            int currentWave = LevelManager.Instance.CurrentWave;

            // ✅ 这里：第10波结束就胜利
            if (currentWave >= finalWave) // finalWave = 10
            {
                _levelFinished = true;

                // 显示胜利画面
                ShowVictory sv = FindObjectOfType<ShowVictory>();
                if (sv != null) sv.Show();

                return;
            }

            // 正常进入下一波
            OnWaveCompleted?.Invoke();
            StartCoroutine(NextWave());
        }
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