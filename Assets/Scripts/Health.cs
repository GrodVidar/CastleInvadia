using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	int maxHealth = 100;
	int health = 100;
    //bool hasChanged = false;
	RectTransform rectTransform;
	Player player;

	private void Start()
	{
		player = FindObjectOfType<Player>();
		rectTransform = GetComponent<RectTransform>();
        health = PlayerPrefs.GetInt("PlayerHealth");
	}

	private void Update()
	{
        if(health > 0)
        {
		    rectTransform.localScale = new Vector2(((float)health / maxHealth), 1f);
        }
        else
        {
            rectTransform.localScale = new Vector2(0f, 1f);
        }
	}

	public void RemoveHealth(int amount)
	{
		health -= amount;
        PlayerPrefs.SetInt("PlayerHealth", health);
		if(health <= 0)
		{
			player.Death();
			player.SetIsAlive(false);
		}
	}

	public void AddHealth(int amount)
	{
		if(health + amount < maxHealth)
		{
			health += amount;
		}
		else
		{
			health = maxHealth;
		}
		PlayerPrefs.SetInt("PlayerHealth", health);
		//health += amount;
        //PlayerPrefs.SetInt("PlayerHealth", health);
		//if(health >= maxHealth)
		//{
		//	health = maxHealth;
		//}
	}

	public bool IsHurt()
	{
		if(health >= maxHealth)
		{
			return false;
		}
		else
		{
			return true;
		}
	}

    public void SetHealth(int hp = 100)
    {
        health = hp;
    }
}
