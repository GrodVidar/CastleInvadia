﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    Health health;
    int currentLevel;
    void Awake()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    private void Start()
    {
        health = FindObjectOfType<Health>();
        if(currentLevel == 0)
        {
            PlayerPrefs.SetInt("PlayerHealth", 100);
            Debug.Log(PlayerPrefs.GetInt("PlayerHealth"));
        }
    }

    public void LoadNextLevel()
    {
        int nextLevel = currentLevel + 1;
        SceneManager.LoadScene(nextLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
