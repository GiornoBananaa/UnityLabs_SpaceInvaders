using UISystem;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerInvoker
    {
        private readonly PlayerMovement _playerMovement;
        private readonly PlayerCombat _playerCombat;
        private readonly PlayerHealth _playerHealth;
        private readonly Player _player;
    
        public PlayerInvoker(Player player)
        {
            _player = player;
            _playerMovement = new PlayerMovement(_player.PlayerBorderMinX,_player.PlayerBorderMaxX);
            _playerCombat = new PlayerCombat();
            _playerHealth = new PlayerHealth(_player.MaxHealth,_player.MaxLives, player.PlayerHud,player.GameState);
        }
        
        public void Move(Vector3 moveDirection)
        {
            _playerMovement.Move(_player.transform, _player.MovementSpeed, moveDirection);
        }
        
        public void Shoot()
        {
            _playerCombat.Shoot(_player.FirePoint, _player.BulletPrefab);
        }

        public void GetDamage()
        {
            _playerHealth.GetDamage();
        }
    }
}
