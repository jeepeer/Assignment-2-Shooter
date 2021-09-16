using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using Unity.Mathematics;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float timeBetweenObstacles = 4f;
    private float timeBetweenObstaclesShort = 1f;
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private GameObject spawnUp;
    [SerializeField] private GameObject spawnDown;
    public int obstaclesHit;

    PlayerBike bike;
    private void Start()
    {
        StartCoroutine(ScriptedObstacles());
        bike = FindObjectOfType<PlayerBike>();
    }

    private void Update()
    {
        if (obstaclesHit >= 1)
        {
            GameManager.RestartScene(); // could probably be called from playerbike instead
        } 
    }

    private IEnumerator ScriptedObstacles() // scripted in which order the obstacles come
    {
        yield return new WaitForSeconds(timeBetweenObstacles);
        SpawnObstacleUp();
        
        yield return new WaitForSeconds(timeBetweenObstacles);
        SpawnObstacleDown();
        
        yield return new WaitForSeconds(timeBetweenObstacles);
        SpawnObstacleUp();
        yield return new WaitForSeconds(timeBetweenObstaclesShort);
        SpawnObstacleDown();
        
        yield return new WaitForSeconds(timeBetweenObstacles);
        SpawnObstacleDown();
        yield return new WaitForSeconds(timeBetweenObstaclesShort);
        SpawnObstacleUp();
        yield return new WaitForSeconds(timeBetweenObstaclesShort);
        SpawnObstacleDown();
        yield return new WaitForSeconds(timeBetweenObstaclesShort);
        SpawnObstacleUp();
        yield return new WaitForSeconds(timeBetweenObstacles);
        bike.isMoving = true;
    }
    
    private void SpawnObstacleUp()
    {
        Instantiate(obstaclePrefab, spawnUp.transform.position, quaternion.identity);
    }
    private void SpawnObstacleDown()
    {
        Instantiate(obstaclePrefab, spawnDown.transform.position, quaternion.identity);
    }
}
