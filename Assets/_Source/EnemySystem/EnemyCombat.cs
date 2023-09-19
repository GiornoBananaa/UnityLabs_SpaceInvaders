using UnityEngine;

namespace EnemySystem
{
    public class EnemyCombat
    {
        public void Shoot(Transform firePoint, GameObject bulletPrefab)
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab,firePoint);
            bullet.transform.parent = null;
        }
    }
}