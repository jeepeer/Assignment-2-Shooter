using UnityEngine;
using Weapons;

namespace Player
{
    public class PlayerController : PlayerManager
    {
        [SerializeField] private float movementSpeed;
        [SerializeField] private float rotationSpeed;
        Weapon weapon;
        private void Awake()
        {
            weapon = GetComponentInChildren<Weapon>();
        }
        private void FixedUpdate()
        {
            PlayerMovement();
            PlayerFire();
        }

        private void PlayerMovement()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.up * movementSpeed * Time.fixedDeltaTime);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector3.down * movementSpeed * Time.fixedDeltaTime);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.forward * rotationSpeed * Time.fixedDeltaTime); 
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.back * rotationSpeed * Time.fixedDeltaTime); 
            }
        }

        private void PlayerFire()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                weapon.FireWeapon();
            }
        }
    }
}
