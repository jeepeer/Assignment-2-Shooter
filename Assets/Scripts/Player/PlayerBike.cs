using System;
using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerBike : PlayerManager
    {
        [SerializeField] private float bikeSpeed;
        private float playAreaMin = -4f; 
        private float playAreaMax = -0f;
        private float offScreen = 8f;
        public bool isMoving = false;
        
        private void FixedUpdate()
        {
            BikeMovement();
            if(isMoving) { MoveRight();}
        }

        private void BikeMovement()
        {
            if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < playAreaMax)
            {
                transform.Translate(Vector3.up * bikeSpeed * Time.fixedDeltaTime);
            }
            else if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > playAreaMin)
            {
                transform.Translate(Vector3.down * bikeSpeed * Time.fixedDeltaTime);
            }
        }
        
        private void MoveRight() // after you've dodged all obstacles you move to the right and end the level
        { 
            transform.Translate(Vector3.right * bikeSpeed * Time.fixedDeltaTime);
            float currentPositon = transform.position.x;
            if(currentPositon >= offScreen){ GameManager.LoadNextScene(); }
        }
    }
}
