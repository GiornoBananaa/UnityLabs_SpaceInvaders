using System;
using BulletSystem;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerCollisionDetector : MonoBehaviour
    {
        private PlayerInvoker _playerInvoker;
        private LayerMask _enemyBulletMask;
        
        public static PlayerCollisionDetector CreateComponent (GameObject gameObject, PlayerInvoker playerInvoker, LayerMask enemyBulletMask)
        {
            PlayerCollisionDetector detector = gameObject.AddComponent<PlayerCollisionDetector>();
            detector._playerInvoker = playerInvoker;
            detector._enemyBulletMask = enemyBulletMask;
            return detector;
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
