using UnityEngine;

namespace EnemySystem
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Transform firePoint;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private LayerMask playerBulletLayerMask;
        [SerializeField] private LayerMask endBorderMask;
        private bool _canShoot;
        private float _timeBeforeShoot;
        private int _enemyColumn;
        private EnemyArmy _enemyArmy;
        private EnemyCombat _enemyCombat;
        
        private void Start()
        {
            _timeBeforeShoot = Random.Range(0.6f,3);
            _enemyCombat = new EnemyCombat();
            gameObject.AddComponent<EnemyCollisionDetector>().Initialize(this, playerBulletLayerMask, endBorderMask);
        }

        private void Update()
        {
            if (_canShoot)
            {
                _timeBeforeShoot -= Time.deltaTime;
                CheckShootTime();
            }
        }

        public void Initialize(EnemyArmy enemyArmy, int enemyColumn)
        {
            _enemyArmy = enemyArmy;
            _enemyColumn = enemyColumn;
        }

        public void GetDamage()
        {
            _enemyArmy.KillEnemy(_enemyColumn);
        }
        
        public void ReachEnd()
        {
            _enemyArmy.ReachEnd();
        }
        
        public void ActivateShooting()
        {
            _canShoot = true;
        }
        
        private void CheckShootTime()
        {
            if (_timeBeforeShoot <= 0)
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            _timeBeforeShoot = Random.Range(0.6f,3);
            _enemyCombat.Shoot(firePoint,bulletPrefab);
        }
    }
}