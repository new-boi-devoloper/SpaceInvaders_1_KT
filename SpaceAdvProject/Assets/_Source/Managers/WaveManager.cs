using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [field: SerializeField] public float SpawnDelay { get; private set; }
    [field: SerializeField] public int SpawnQuantity { get; private set; }

    private EnemySpawner _enemySpawner;
    private List<GameObject> _activeEnemies = new();

    private bool _isStopedWaves = true;
    private bool _isRestartingWaves = false;

    private void OnEnable()
    {
        EventManager.OnGameOver += StopWaves;
        EventManager.OnGameRestart += ClearEnemies;
        EventManager.OnGameContinue += ContinueWaves;
        EventManager.OnEnemySpawned += HandleEnemySpawned;
        EventManager.OnEnemyDead += HandleEnemyDead;
        StartWaveSpawn().Forget();
    }

    private void OnDisable()
    {
        EventManager.OnGameOver -= StopWaves;
        EventManager.OnGameRestart -= ClearEnemies;
        EventManager.OnGameContinue -= ContinueWaves;
        EventManager.OnEnemySpawned -= HandleEnemySpawned;
        EventManager.OnEnemyDead -= HandleEnemyDead;
    }

    private void Start()
    {
        _enemySpawner = GetComponent<EnemySpawner>();
    }

    private void StopWaves()
    {
        _isStopedWaves = false;
    }

    private void ContinueWaves()
    {
        _isStopedWaves = true;
        _isRestartingWaves = true;
    }

    private void SpawnEnemies()
    {
        _enemySpawner.SpawnEnemies(SpawnQuantity);
    }

    private async UniTask StartWaveSpawn()
    {
        while (true)
        {
            while (_isStopedWaves)
            {
                await UniTask.Delay((int)(SpawnDelay * 1000));
                if (!_isStopedWaves) break;

                SpawnEnemies();
            }

            if (_isRestartingWaves)
            {
                _isRestartingWaves = false;
                continue;
            }

            await UniTask.WaitUntil(() => _isStopedWaves);
        }
    }

    private void HandleEnemySpawned(GameObject enemy)
    {
        _activeEnemies.Add(enemy);
    }

    private void HandleEnemyDead()
    {
        _activeEnemies.RemoveAll(e => e == null || !e.activeInHierarchy);
    }

    private void ClearEnemies()
    {
        foreach (var enemy in _activeEnemies)
        {
            if (enemy != null)
            {
                Destroy(enemy);
            }
        }
        _activeEnemies.Clear();
    }
}