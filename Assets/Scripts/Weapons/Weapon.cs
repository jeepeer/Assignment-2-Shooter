using System.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Weapons
{
    public class Weapon : WeaponUpgrades
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private bool isShooting;

        public void FireWeapon()
        {
            if(isShooting) { return; }
            StartCoroutine(TimeBetweenShooting());
        }

        private IEnumerator TimeBetweenShooting()
        {
            isShooting = true;
            ShootBullet();
            yield return new WaitForSeconds(fireRate);
            isShooting = false;
        }
        
        private void ShootBullet()
        {
            Instantiate(bulletPrefab, transform.position, quaternion.identity)
                .GetComponent<Rigidbody2D>().AddForce(transform.up * fireSpeed);

            if (isUpgraded) 
            {
                MultiShot();
            }
        }

        private void MultiShot() // shoots 5 bullets in a spread
        {
            var position = transform.position;
            // shoots forward
            Instantiate(bulletPrefab, position, quaternion.identity)
                .GetComponent<Rigidbody2D>().AddForce(transform.up * fireSpeed);

            // shoots inner left
            Instantiate(bulletPrefab, position, quaternion.identity)
                .GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis
                    (-70, Vector3.forward) * -transform.right * fireSpeed);
                
            // shoots inner right
            Instantiate(bulletPrefab, position, quaternion.identity)
                .GetComponent<Rigidbody2D>().AddForce((Quaternion.AngleAxis
                    (70, Vector3.forward) * transform.right * fireSpeed));
            // shoots left
            Instantiate(bulletPrefab, position, quaternion.identity)
                .GetComponent<Rigidbody2D>().AddForce(Quaternion.AngleAxis
                    (-45, Vector3.forward) * -transform.right * fireSpeed);
                
            // shoots right
            Instantiate(bulletPrefab, position, quaternion.identity)
                .GetComponent<Rigidbody2D>().AddForce((Quaternion.AngleAxis
                    (45, Vector3.forward) * transform.right * fireSpeed));
        }
    }
}
