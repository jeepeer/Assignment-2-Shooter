using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Enemies
{
    public class EnemyBoss : Enemy
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject bonePrefab;
        [SerializeField] private GameObject flame;
        [SerializeField] private float throwForce; // randomize a bit
        private float timeBetweenAttacks = 4f;
        private float timeBeforeRetreatingFlamethrower = 2f;
        private Vector3 left;
        private bool flameMoving;
        
        private void Start()
        {
            StartCoroutine(BossAttack());
        }

        private void Update()
        {
            FlameThrowerAttack();
        }
        
        private IEnumerator BossAttack() // the order the attacks happen in
        {
            while (!isDead)
            {
                yield return new WaitForSeconds(timeBetweenAttacks);
                ThrowBone();
                yield return new WaitForSeconds(timeBetweenAttacks);
                flameMoving = true;
                yield return new WaitForSeconds(timeBeforeRetreatingFlamethrower);
                ThrowBone();
                flameMoving = false;
            }
            
            // big explosion
            yield break;
        }

        void ThrowBone() // throws a bone at an angle towards the player
        {
            Instantiate(bonePrefab, transform.position, quaternion.identity)
                .GetComponent<Rigidbody2D>().AddForce(
                    Quaternion.AngleAxis(-70, Vector3.forward) * -transform.right * throwForce);
        }

        void FlameThrowerAttack() // moves a "flame" object to cover the ground
        {
            if (flameMoving)
            {
                flame.transform.Translate(Vector3.left * 5 * Time.deltaTime);
            }
            else if (!flameMoving && flame.transform.position.x <= 7)
            {
                flame.transform.Translate(Vector3.right * 5 * Time.deltaTime);
            }
        }
    }
}
