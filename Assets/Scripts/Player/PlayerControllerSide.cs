using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEditor.Build;
using Weapons;
using static UnityEngine.Vector3;

namespace Player
{
    public class PlayerControllerSide : PlayerManager
    {
        [SerializeField] private float movementSpeed;
        [SerializeField] private float jumpHeight;
        [SerializeField] private GameObject playerWeapon;

        private Weapon weapon;

        private void Start()
        {
            weapon = GetComponentInChildren<Weapon>();
        }

        private void FixedUpdate()
        {
            PlayerMovement();
            PlayerAim();
            PlayerFire();
        }

        private void PlayerMovement()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(left * movementSpeed * Time.fixedDeltaTime);
                playerWeapon.transform.localPosition = left; // makes sure that the weapon is in the correct place
                playerWeapon.transform.localRotation = Quaternion.AngleAxis(90, Vector3.forward);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(right * movementSpeed * Time.fixedDeltaTime);
                playerWeapon.transform.localPosition = right;
                playerWeapon.transform.localRotation = Quaternion.AngleAxis(-90, Vector3.forward);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                transform.Translate(Vector3.up * jumpHeight * Time.fixedDeltaTime);
            }
        }

        private void PlayerAim() // changes the location and rotation of the weapon
        {
            if (Input.GetKey(KeyCode.UpArrow) 
                && Input.GetKey(KeyCode.LeftArrow))
            {
                playerWeapon.transform.localPosition = new Vector2(-1, 1);
                playerWeapon.transform.localRotation = Quaternion.AngleAxis(45, Vector3.forward);
            }
            else if (Input.GetKey(KeyCode.UpArrow) 
                     && Input.GetKey(KeyCode.RightArrow))
            {
                playerWeapon.transform.localPosition = new Vector2(1, 1);
                playerWeapon.transform.localRotation = Quaternion.AngleAxis(-45, Vector3.forward);
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                playerWeapon.transform.localPosition = up;
                playerWeapon.transform.localRotation = Quaternion.AngleAxis(0, Vector3.forward);
            }
            
            if (Input.GetKey(KeyCode.DownArrow) 
                && Input.GetKey(KeyCode.LeftArrow))
            {
                playerWeapon.transform.localPosition = new Vector2(-1, -1);
                playerWeapon.transform.localRotation = Quaternion.AngleAxis(135, Vector3.forward);
            }
            else if (Input.GetKey(KeyCode.DownArrow) 
                     && Input.GetKey(KeyCode.RightArrow))
            {
                playerWeapon.transform.localPosition = new Vector2(1, -1);
                playerWeapon.transform.localRotation = Quaternion.AngleAxis(-135, Vector3.forward);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                playerWeapon.transform.localPosition = down;
                playerWeapon.transform.localRotation = Quaternion.AngleAxis(180, Vector3.forward);
            }
        }

        private void PlayerFire()
        {
            if (Input.GetKey(KeyCode.E))
            {
                weapon.FireWeapon();
            }
        }
    }
}
