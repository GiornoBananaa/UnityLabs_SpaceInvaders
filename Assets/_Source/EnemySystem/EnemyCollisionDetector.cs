using UnityEngine;

namespace EnemySystem
{
    public class EnemyCollisionDetector: MonoBehaviour
    {
        private Enemy _enemy;
        private LayerMask _playerBulletMask;
        private LayerMask _endBorderMask;
        
        public void Initialize (Enemy enemy, LayerMask playerBulletMask, LayerMask endBorderMask)
        {
            _enemy = enemy;
            _playerBulletMask = playerBulletMask;
            _endBorderMask = endBorderMask;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if ((_playerBulletMask & (1 << other.gameObject.layer)) != 0)
            {
                _enemy.GetDamage();
            }
            else if((_endBorderMask & (1 << other.gameObject.layer)) != 0)
            {
                _enemy.ReachEnd();
            }
        }
    }
}