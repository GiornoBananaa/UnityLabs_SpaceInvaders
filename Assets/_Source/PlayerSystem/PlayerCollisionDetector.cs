using UnityEngine;

namespace PlayerSystem
{
    public class PlayerCollisionDetector : MonoBehaviour
    {
        private PlayerInvoker _playerInvoker;
        private LayerMask _enemyBulletMask;
        
        public void Initialize (PlayerInvoker playerInvoker, LayerMask enemyBulletMask)
        {
            _playerInvoker = playerInvoker;
            _enemyBulletMask = enemyBulletMask;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if ((_enemyBulletMask & (1 << other.gameObject.layer)) != 0)
            {
                _playerInvoker.GetDamage();
            }
        }
    }
}
