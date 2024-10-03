using System;
using UnityEngine;
using UnityEngine.Accessibility;

public static class EventManager
{
    public static event Action OnGameOver;
    public static event Action OnGameContinue;
    public static event Action OnPlayerDead;
    public static event Action<int> OnPlayerHealthChanged;
    public static event Action OnEnemyDead;
    public static event Action OnGameRestart;
    public static event Action OnEnemyWon;
    public static event Action<GameObject> OnEnemySpawned;


    public static void TriggerGameOver() => OnGameOver?.Invoke();
    public static void TriggerGameContinue() => OnGameContinue?.Invoke();
    public static void TriggerPlayerDead() => OnPlayerDead?.Invoke();
    public static void TriggerPlayerHealthChanged(int health) => OnPlayerHealthChanged?.Invoke(health);
    public static void TriggerEnemyDead() => OnEnemyDead?.Invoke();
    public static void TriggerGameRestart() => OnGameRestart?.Invoke();
    public static void TriggerEnemySpawn(GameObject enemy) => OnEnemySpawned?.Invoke(enemy);
    public static void TriggerEnemyWon() => OnEnemyWon?.Invoke();
}