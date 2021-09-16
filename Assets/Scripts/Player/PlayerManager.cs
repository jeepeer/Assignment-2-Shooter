using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        private int CurrentHealth
        {
            get => totalHealth;  
            set => totalHealth = value; 
        }
        [SerializeField] private int totalHealth;
        public int damageTaken = 1; // shouldn't be hardcoded
        
        public void TakeDamage()
        {
            CurrentHealth -= damageTaken;

            if (CurrentHealth <= 0)
            {
                StartCoroutine(Dead());
            }
        }

        private IEnumerator Dead()
        {
            yield return new WaitForSeconds(1f);
            GameManager.RestartScene();
        }
    }
}
