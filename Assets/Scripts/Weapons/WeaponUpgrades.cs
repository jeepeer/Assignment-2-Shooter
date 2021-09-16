using Enemies;
using UnityEngine;
using UnityEngine.Serialization;

namespace Weapons
{
    public class WeaponUpgrades : MonoBehaviour
    {
        public float fireRate;
        public float fireSpeed; 
        public bool isUpgraded;

        public void FlameThrower() 
        {
            isUpgraded = false;
            fireRate = .1f;
            fireSpeed = 2f; 
            Enemy.damageTaken = 1;
        }

        public void BasicShooter() 
        {
            isUpgraded = false;
            fireRate = .3f;
            fireSpeed = 5f;
            Enemy.damageTaken = 5;
        }

        public void MultiShooter() 
        {
            isUpgraded = true;
            fireRate = .3f;
            fireSpeed = 5;
            Enemy.damageTaken = 3;
        }
    }
}
