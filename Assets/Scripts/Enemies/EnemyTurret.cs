using System;
using System.Collections.Generic;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Weapons;

namespace Enemies
{
    public class EnemyTurret : Enemy
    {
        public GameObject player; 
        Weapon weapon;

        private void Start()
        {
            weapon = GetComponentInChildren<Weapon>();
        }
        
        private void FixedUpdate()
        {
            if(!isDead) GetDistanceOfPlayer();
        }

        private void GetDistanceOfPlayer()
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance > distanceBeforeSeeingPlayer)
            {
                return;
            }
            LookAtPlayer(); 
            weapon.FireWeapon();
        }
        
        private void LookAtPlayer()
        {
            transform.right = player.transform.position - transform.position;
            transform.Rotate(0,0,-90); // otherwise the turret looks to the side
        }
    }
}
