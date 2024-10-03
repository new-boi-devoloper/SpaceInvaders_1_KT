using System;
using PlayerScripts;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.OnPlayerDead += HandleGameOver;
        EventManager.OnGameRestart += HandleGameRestart;
        EventManager.OnEnemyWon += HandleGameOver;
    }

    private void OnDisable()
    {
        EventManager.OnPlayerDead -= HandleGameOver;
        EventManager.OnGameRestart -= HandleGameRestart;
        EventManager.OnEnemyWon -= HandleGameOver;
    }

    private void HandleGameOver()
    {
        EventManager.TriggerGameOver();
    }

    private void HandleGameRestart()
    {
        EventManager.TriggerGameContinue();
    }
}