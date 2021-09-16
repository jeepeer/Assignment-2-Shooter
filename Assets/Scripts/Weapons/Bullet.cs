using System;
using System.Collections;
using Enemies;
using Player;
using UnityEngine;

namespace Weapons
{
    [RequireComponent(typeof(Rigidbody2D))] 
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float timeBeforeDestroyed;
        private void Start()
        {
            StartCoroutine(DestroyBullet());
        }

        private void OnCollisionEnter2D(Collision2D other) // checks what to do with different collisions
        {
            if (other.collider.GetComponent<Enemy>())
            {
                other.collider.GetComponent<Enemy>().TakeDamage();
                Destroy(gameObject);
            }

            if (other.collider.GetComponent<PlayerController>())
            {
                other.collider.GetComponent<PlayerManager>().TakeDamage();
                Destroy(gameObject);
            }

            if (other.collider.GetComponent<EnemyObjective>())
            {
                other.collider.GetComponent<EnemyObjective>().TakeDamage();
                Destroy(gameObject);
            }
            
            Destroy(gameObject);
        }
        
        private IEnumerator DestroyBullet()
        {
            yield return new WaitForSeconds(timeBeforeDestroyed);
            Destroy(gameObject);
        }
    }
}

