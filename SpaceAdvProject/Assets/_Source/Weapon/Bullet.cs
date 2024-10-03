using EnemyScripts;
using UnityEngine;

namespace Weapon
{
    public class Bullet : MonoBehaviour
    {
        [field: SerializeField] public float BulletSpeed { get; private set; }
        [field: SerializeField] public int BulletDamage { get; private set; }

        private float _lifetime = 5;

        private void Update()
        {
            transform.Translate(Vector2.up * (BulletSpeed * Time.deltaTime));
            StartLifetimeSpan();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (LayerMaskCheck.ContainsLayer(LayerMask.GetMask("Enemy"), other.gameObject))
            {
                other.gameObject.GetComponent<Enemy>().ChangeHealth(BulletDamage);
                Destroy(gameObject);
            }
        }

        internal void StartLifetimeSpan()
        {
            _lifetime -= Time.deltaTime;
            if (_lifetime <= 0) Destroy(gameObject);
        }
    }
}