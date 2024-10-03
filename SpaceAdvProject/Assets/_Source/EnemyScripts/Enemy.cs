using System;
using PlayerScripts;
using UnityEngine;

namespace EnemyScripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Enemy : MonoBehaviour
    {
        [field: SerializeField] public int EnemyDamage { get; private set; }
        [field: SerializeField] public float EnemySpeed { get; private set; }
        [field: SerializeField] public int EnemyHealth { get; private set; }

        private Rigidbody2D _enemyRb;

        private void Start()
        {
            _enemyRb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (LayerMaskCheck.ContainsLayer(LayerMask.GetMask("Player"), other.gameObject))
            {
                other.gameObject.GetComponent<Player>().ChangeHealth(EnemyDamage);
            }
        }

        private void Move()
        {
            _enemyRb.MovePosition(_enemyRb.position + Vector2.down * (EnemySpeed * Time.deltaTime));
        }

        public void ChangeHealth(int amount)
        {
            EnemyHealth -= amount;

            if (EnemyHealth <= 0)
            {
                EventManager.TriggerEnemyDead();
                Destroy(gameObject);
            }
        }
    }
}