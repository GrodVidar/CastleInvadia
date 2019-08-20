using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour
{

	Enemy enemy;
	GameObject hazards;
    // Start is called before the first frame update
    void Start()
    {
		enemy = GetComponent<Enemy>();
		hazards = GameObject.Find("Hazards");
    }

	private void Update()
	{
		if(enemy.GetIsDead())
		{
			hazards.SetActive(false);
		}
	}
}
