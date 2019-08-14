using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    int currentLevel;
    void Awake()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
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
