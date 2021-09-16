using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int objectsDestroyed;
    private int totalObjects = 4;
    [SerializeField] private GameObject menu;
    private bool isMenuOpen;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenu(); 
        }
    }

    public void ObjectsCleared()
    {
        if (objectsDestroyed < totalObjects) { return; }
        
        Debug.Log("all objectives are destroyed");
        LoadNextScene();
        // message ? find the exit
        // open door to next level
    }

    public void LevelCleared()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            LoadNextScene();
        }
    }
    
    public static void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

    public static void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void MainMenu() // missing pause etc
    {
        isMenuOpen = !isMenuOpen;
        menu.SetActive(isMenuOpen);
    }
}
