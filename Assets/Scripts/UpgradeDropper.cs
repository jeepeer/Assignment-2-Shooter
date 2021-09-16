using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class UpgradeDropper : MonoBehaviour
{
    [SerializeField] private GameObject upgradePrefab;
    
    public void UpgradePicker(int whichUpgrade)
    {
        switch (whichUpgrade)
        {
            case 1:
                return;
            case 2:
            case 3:
            case 4:
            case 5:
                Instantiate(upgradePrefab, transform.position, quaternion.identity);
                break;
        }
    }
}
