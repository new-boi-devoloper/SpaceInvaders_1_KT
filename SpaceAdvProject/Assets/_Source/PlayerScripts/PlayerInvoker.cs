using System;
using Unity.VisualScripting;

namespace PlayerScripts
{
    public class PlayerInvoker : IDisposable
    {
        private readonly Player _player;
        private readonly PlayerCombat _playerCombat;
        private readonly PlayerMovement _playerMovement;

        private bool _isGameOver = true;

        public PlayerInvoker(Player player, PlayerMovement playerMovement, PlayerCombat playerCombat)
        {
            _player = player;
            _playerMovement = playerMovement;
            _playerCombat = playerCombat;

            InputListener.OnFire += InvokeShoot;
            EventManager.OnGameOver += StopPlayer;
            EventManager.OnGameContinue += MakePlayerAlive;
        }


        public void Dispose()
        {
            InputListener.OnFire -= InvokeShoot;
            EventManager.OnGameOver -= StopPlayer;
            EventManager.OnGameContinue -= MakePlayerAlive;
        }

        private void StopPlayer()
        {
            _isGameOver = false;
        }

        private void MakePlayerAlive()
        {
            _isGameOver = true;
        }

        public void HandleInput(float inputMove)
        {
            if (_isGameOver)
            {
                InvokeMove(inputMove);
            }
        }

        private void InvokeMove(float moveDirection)
        {
            _playerMovement.Move(_player.Rb, moveDirection, _player.PlayerSpeed);
        }

        private void InvokeShoot()
        {
            _playerCombat.Shoot(_player.BulletPrefab, _player.BulletSpawnPosition.position, _player.transform.rotation);
        }
    }
}