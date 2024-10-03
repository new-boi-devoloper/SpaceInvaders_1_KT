using System;
using UnityEngine;

namespace PlayerScripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [field: SerializeField] public float PlayerSpeed { get; private set; }
        [field: SerializeField] public int PlayerMaxHealth { get; private set; }
        [field: SerializeField] public GameObject BulletPrefab { get; private set; }
        [field: SerializeField] public Transform BulletSpawnPosition { get; private set; }

        public Rigidbody2D Rb { get; private set; }

        private int _currentHealth;

        private void Start()
        {
            Rb = GetComponent<Rigidbody2D>();
            ResetHealth();
        }

        private void OnEnable()
        {
            EventManager.OnGameContinue += ResetHealth;
        }

        private void OnDisable()
        {
            EventManager.OnGameContinue -= ResetHealth;
        }

        private void ResetHealth()
        {
            _currentHealth = PlayerMaxHealth;
            EventManager.TriggerPlayerHealthChanged(_currentHealth);
        }

        public void ChangeHealth(int amount)
        {
            _currentHealth -= amount;
            EventManager.TriggerPlayerHealthChanged(_currentHealth);

            if (_currentHealth <= 0)
            {
                EventManager.TriggerPlayerDead();
            }
        }
    }
}