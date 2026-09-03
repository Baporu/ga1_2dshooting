using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // 적 프리팹
    public GameObject EnemyPrefab;

    // 적 최대 소환 수
    public int MaxSpawnCount;
    private int _currentSpawnCount;

    // 소환 대기 시간
    public float SpawnCoolTime;
    private float _spawnCoolTimer;

    private void Start()
    {
        _currentSpawnCount = 0;
        _spawnCoolTimer = 0.0f;
    }

    private void Update()
    {
        _spawnCoolTimer -= Time.deltaTime;

        if (_spawnCoolTimer <= 0.0f && _currentSpawnCount < MaxSpawnCount)
        {
            SpawnEnemy();
            _spawnCoolTimer = SpawnCoolTime;
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(EnemyPrefab, transform.position, Quaternion.identity);

        _currentSpawnCount++;
    }
}