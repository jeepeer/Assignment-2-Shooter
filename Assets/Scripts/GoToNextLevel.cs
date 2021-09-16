using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class GoToNextLevel : GameManager
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.GetComponent<PlayerManager>()) return;
        
        ObjectsCleared();
        LevelCleared();
    }
}
