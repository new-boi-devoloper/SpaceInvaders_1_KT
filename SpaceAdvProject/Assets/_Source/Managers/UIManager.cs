using System;
using EnemyScripts;
using PlayerScripts;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [field: SerializeField] public GameObject OnDeadWindow { get; private set; }
    [field: SerializeField] public GameObject PointsWindow { get; private set; }
    [field: SerializeField] public GameObject HealthWindow { get; private set; }

    private TextMeshProUGUI _pointsText;
    private TextMeshProUGUI _hpText;

    private int _points;

    private void Start()
    {
        _pointsText = PointsWindow.GetComponentInChildren<TextMeshProUGUI>();
        _hpText = HealthWindow.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        EventManager.OnGameOver += ShowDeadWindow;
        EventManager.OnGameContinue += RestartGameHandler;
        EventManager.OnEnemyDead += UpdatePoints;
        EventManager.OnPlayerHealthChanged += UpdateHealth;
    }

    private void OnDisable()
    {
        EventManager.OnGameOver -= ShowDeadWindow;
        EventManager.OnGameContinue -= RestartGameHandler;
        EventManager.OnEnemyDead -= UpdatePoints;
        EventManager.OnPlayerHealthChanged -= UpdateHealth;
    }

    private void ShowDeadWindow()
    {
        OnDeadWindow.SetActive(true);
    }

    private void RestartGameHandler()
    {
        _pointsText.text = "0";
        _points = 0;
        UpdateHealth(0);
    }

    public void RestartButtonPressed()
    {
        EventManager.TriggerGameRestart();
    }

    private void UpdatePoints()
    {
        _pointsText.text = $"{++_points}";
    }

    private void UpdateHealth(int currentPlayerHealth)
    {
        _hpText.text = $"{currentPlayerHealth}";
    }
}