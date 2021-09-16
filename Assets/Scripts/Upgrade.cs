using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using Weapons;

public class Upgrade : MonoBehaviour
{ 
    private int upgradeNumber;
    [SerializeField] private WeaponUpgrades weaponUpgrades;
    private void Start()
    {
        try // incase WeaponUpgrades doesn't exist
        {
            weaponUpgrades = FindObjectOfType<WeaponUpgrades>();
            upgradeNumber = UnityEngine.Random.Range(1, 4);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.GetComponent<PlayerManager>()) return;
        switch (upgradeNumber)
        {
            case 1:
                weaponUpgrades.BasicShooter();
                Destroy(gameObject);
                break;
            case 2:
                weaponUpgrades.FlameThrower();
                Destroy(gameObject);
                break;
            case 3:
                weaponUpgrades.MultiShooter();
                Destroy(gameObject);
                break;
        }
    }
}
