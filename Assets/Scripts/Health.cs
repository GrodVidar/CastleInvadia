using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	int maxHealth = 100;
	int health = 100;
	RectTransform rectTransform;
	Player player;

	//private void Awake()
	//{
	//	Singleton();	
	//}

	private void Start()
	{
		player = FindObjectOfType<Player>();
		rectTransform = GetComponent<RectTransform>();
	}

	private void Update()
	{
		rectTransform.localScale = new Vector2(((float)health / maxHealth), 1f);
	}

	public void RemoveHealth(int amount)
	{
		health -= amount;
		if(health <= 0)
		{
			player.Death();
			player.SetIsAlive(false);
		}
	}

	public void AddHealth(int amount)
	{
		health += amount;
		if(health >= maxHealth)
		{
			health = maxHealth;
		}
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

	private void Singleton()
	{
		if(FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
	}
}
