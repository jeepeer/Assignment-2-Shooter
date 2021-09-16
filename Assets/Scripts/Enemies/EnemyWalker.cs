using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Enemies
{
    public class EnemyWalker : Enemy
    {
        [SerializeField] GameObject player;
        [SerializeField] private float movementSpeed;
        private void Update()
        {
            GetDistanceOfPlayer();
        }
        
        private void GetDistanceOfPlayer()
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance > distanceBeforeSeeingPlayer)
            {
                return;
            }
            LookAtPlayer();
            MoveTowardsPlayer();
        }
        
        private void LookAtPlayer()
        {
            transform.right = player.transform.position - transform.position;
            transform.Rotate(0,0,-90); // otherwise the walker looks to the side
        }
        
        private void MoveTowardsPlayer()
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position,
                movementSpeed * Time.deltaTime);
        }
    }
}
