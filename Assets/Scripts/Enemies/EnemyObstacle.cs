using System;
using Player;
using UnityEditorInternal;
using UnityEngine;

namespace Enemies
{
    public class EnemyObstacle : MonoBehaviour
    {
        private Obstacle obstacle;
        [SerializeField] private float speed;

        private void Start()
        {
            obstacle = FindObjectOfType<Obstacle>();
        }

        private void FixedUpdate()
        {
            transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.GetComponent<PlayerBike>())
            {
                obstacle.obstaclesHit++; // to see whether the player hits an obstacle or not
            }
            
            Destroy(gameObject);
        }
    }
}
