using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    CashFlow money;
    // Start is called before the first frame update
    void Start()
    {
        money = FindObjectOfType<CashFlow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void Retry()
	{
        money.SetMoney(PlayerPrefs.GetInt("Money"));
		Level level = FindObjectOfType<Level>();
		level.ReloadLevel();
	}

	public void QuitGame()
	{
		Debug.Log("Quitting");
		Application.Quit();
	}
}
