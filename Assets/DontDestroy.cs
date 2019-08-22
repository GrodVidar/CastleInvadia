﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
	private void Awake()
	{
		Singleton();
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
