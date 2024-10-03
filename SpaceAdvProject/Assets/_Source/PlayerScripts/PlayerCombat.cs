using UnityEngine;
using Weapon;

namespace PlayerScripts
{
    public class PlayerCombat
    {
        public void Shoot(GameObject bulletPrefab, Vector2 spawnPosition, Quaternion rotation)
        {
            var bulletClon = Object.Instantiate(bulletPrefab, spawnPosition, rotation);
            var bulletComponent = bulletClon.GetComponent<Bullet>();

            bulletComponent.StartLifetimeSpan();
        }
    }
}