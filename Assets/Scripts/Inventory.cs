﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	//states
	bool hasBow = false;
	bool hasBomb = false;

	//caches
	[SerializeField] GameObject[] weapons;
	[SerializeField] GameObject[] backgrounds;
    [SerializeField] GameObject key;

	//variables
	int bombs = 0;

    void Start()
    {
		SetActiveWeapon(PlayerPrefs.GetInt("ActiveWeapon"));
    }

    // Update is called once per frame
    void Update()
    {
        if(bombs <= 0)
		{
			hasBomb = false;
		}
		else
		{
			hasBomb = true;
		}
    }

	public void SetBowAquired()
	{
		foreach(GameObject weapon in weapons)
		{
			if(weapon.name == "ArrowBG")
			{
				weapon.SetActive(true);
				hasBow = true;
			}
		}
	}

	public void SetBombAquired()
	{
		foreach (GameObject weapon in weapons)
		{
			if(weapon.name == "BombBG")
			{
				weapon.SetActive(true);
			}
		}
	}

	public bool GethasBow()
	{
		return hasBow;
	}

	public bool GethasBomb()
	{
		return hasBomb;
	}

	public int GetBombs()
	{
		return bombs;
	}

	public void AddBombs(int amount)
	{
		bombs += amount;
	}

	public void DecreaseBombs()
	{
		bombs--;
	}

	public void SetActiveWeapon(int index)
	{
		foreach(GameObject background in backgrounds)
		{
			background.SetActive(false);
		}
		backgrounds[index].SetActive(true);
	}

    public void SetKeyAquired()
    {
        key.SetActive(true);
    }

    public void SetKeyUnAquired()
    {
        key.SetActive(false);
    }
}
