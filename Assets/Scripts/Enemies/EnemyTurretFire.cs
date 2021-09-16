using System.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Enemies
{
    public class EnemyTurretFire : MonoBehaviour
    {
        [Header("Player")] 
        private float fireRate;
        [SerializeField] private float timeBetweenShots;
        [SerializeField] private float fireSpeed;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private bool isShooting;

        public void FireWeapon()
        {
            if(isShooting) { return; }
            StartCoroutine(TimeBetweenShooting());
        }

        private IEnumerator TimeBetweenShooting()
        {
            fireRate = timeBetweenShots;
            isShooting = true;
            ShootBullet();
            yield return new WaitForSeconds(fireRate);
            isShooting = false;
        }
        
        private void ShootBullet()
        {
            Instantiate(bulletPrefab, transform.position, quaternion.identity)
                .GetComponent<Rigidbody2D>().AddForce(transform.up * fireSpeed);
        }
    }
}
