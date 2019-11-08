using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    CashFlow money;
    bool paused = false;
    [SerializeField]GameObject pauseCanvas;
    // Start is called before the first frame update
    void Start()
    {
        money = FindObjectOfType<CashFlow>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!paused && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            paused = true;
            pauseCanvas.SetActive(true);
        }
        else if(paused && Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
    }

    public void Retry()
	{
        money.SetMoney(PlayerPrefs.GetInt("Money"));
		Level level = FindObjectOfType<Level>();
		level.ReloadLevel();
        if(paused)
        {
            Time.timeScale = 1;
        }
	}

	public void QuitGame()
	{
		Debug.Log("Quitting");
		Application.Quit();
	}

    public void Resume()
    {
        Time.timeScale = 1;
        paused = false;
        pauseCanvas.SetActive(false);
    }

    
}
