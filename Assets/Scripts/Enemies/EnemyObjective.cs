using System;
using UnityEngine;
using System.Collections;

namespace Enemies
{
    public class EnemyObjective : MonoBehaviour
    {
        [SerializeField] private int totalHealth;
        public int damageTaken = 2;
        
        private GameManager gameManager;
        private void Awake()
        {
            gameManager = FindObjectOfType<GameManager>();
        }

        private int CurrentHealth
        {
            get => totalHealth;  
            set => totalHealth = value; 
        }

        public void TakeDamage()
        {
            CurrentHealth -= damageTaken;

            if (CurrentHealth == 0)
            {
                StartCoroutine(Dead());
            }
        }

        public IEnumerator Dead()
        {
            gameManager.objectsDestroyed++;
            GetComponent<Collider2D>().enabled = false;
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }
    }
}
