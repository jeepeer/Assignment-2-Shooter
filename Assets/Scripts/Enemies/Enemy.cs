using System.Collections;
using System.Xml.Schema;
using UnityEngine;
using Random = System.Random;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        private int CurrentHealth
        {
            get => totalHealth;  
            set => totalHealth = value; 
        }
        [SerializeField] private int totalHealth;
        public static int damageTaken = 5; // shouldn't be hardcoded
        public bool isDead;
        public float distanceBeforeSeeingPlayer = 5; // shouldn't be hardcoded

        public void TakeDamage()
        {
            CurrentHealth -= damageTaken;

            if (CurrentHealth <= 0)
            {
                StartCoroutine(Dead());
            }
        }

        public IEnumerator Dead() 
        {
            isDead = true;
            GetComponent<UpgradeDropper>().UpgradePicker(UnityEngine.Random.Range(1,6)); // one in five chance to drop upgrade
            GetComponent<Collider2D>().enabled = false; // turns off collider so that you can't spawn more upgrades
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }
    }
}
