using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void Retry()
	{
		Debug.Log("Retrying");
		Level level = FindObjectOfType<Level>();
		level.ReloadLevel();
	}

	public void QuitGame()
	{
		Debug.Log("Quitting");
		Application.Quit();
	}
}
