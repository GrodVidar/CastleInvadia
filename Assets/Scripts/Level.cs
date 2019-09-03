using System.Collections;
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
        if(currentLevel == 0)
        {
            PlayerPrefs.SetInt("Money", 0);
            PlayerPrefs.SetInt("PlayerHealth", 100);
			PlayerPrefs.SetInt("ActiveWeapon", 0);
            Debug.Log(PlayerPrefs.GetInt("PlayerHealth"));
        }
    }

    private void Start()
    {
        health = FindObjectOfType<Health>();
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

	public void ReloadLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		PlayerPrefs.SetInt("PlayerHealth", 100);
		//Time.timeScale = 1f;
	}
}
