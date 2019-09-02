using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueChest : MonoBehaviour
{
	Player player;
	Chest chest;
    // Start is called before the first frame update
    void Start()
    {
		player = FindObjectOfType<Player>();
		chest = GetComponent<Chest>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetHasBow() == true)
		{
			chest.SetActivated(true);
		}
    }
}
