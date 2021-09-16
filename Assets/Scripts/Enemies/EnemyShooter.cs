using System;
using System.Collections.Generic;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Weapons;

namespace Enemies
{ 
    public class EnemyShooter : Enemy
    {
        Weapon weapon;

        private void Start()
        {
            weapon = GetComponentInChildren<Weapon>();
            StartCoroutine(Shooting());
        }
        
        private IEnumerator Shooting() // shoots in bursts of 3 every 4 seconds
        {
            while (!isDead)
            {
                yield return new WaitForSeconds(4); // shouldn't be hardcoded
                for (int i = 0; i < 3; i++)
                {
                    weapon.FireWeapon();
                    yield return new WaitForSeconds(1);
                }
            }
        }
    }
}
