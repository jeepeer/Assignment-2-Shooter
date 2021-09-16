using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class tester : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            GetComponent<WeaponUpgrades>().FlameThrower();
        }
        if (Input.GetKey(KeyCode.Y))
        {
            GetComponent<WeaponUpgrades>().BasicShooter();
        }
        if (Input.GetKey(KeyCode.U))
        {
            GetComponent<WeaponUpgrades>().MultiShooter();
        }
        
        if (Input.GetKey(KeyCode.P))
        {
            GameManager.LoadNextScene();
        }
    }
}
