﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CashFlow : MonoBehaviour
{
	int money = 0;
    const int max = 99;
	TextMeshProUGUI text;

	private void Start()
	{
		text = GetComponent<TextMeshProUGUI>();
	}

	private void Update()
	{
		text.text = money.ToString();
	}

	public void AddMoney(int amount)
	{
        if((money + amount) < max)
        {
		    money += amount;
        }
        else
        {
            money = max;
        }
	}

    public bool CheckMoney(int amount)
    {
        if(money >= amount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SubMoney(int amount)
    {
        money -= amount;
    }

    public int GetMoney()
    {
        return money;
    }

    public void SetMoney(int amount)
    {
        money = amount;
    }
}
