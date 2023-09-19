using UnityEngine;

namespace EnemySystem
{
    public class EnemyCollisionDetector: MonoBehaviour
    {
        private Enemy _enemy;
        private LayerMask _playerBulletMask;
        
        public void Initialize (Enemy enemy, LayerMask playerBulletMask)
        {
            _enemy = enemy;
            _playerBulletMask = playerBulletMask;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if ((_playerBulletMask & (1 << other.gameObject.layer)) != 0)
            {
                _enemy.GetDamage();
            }
        }
    }
}