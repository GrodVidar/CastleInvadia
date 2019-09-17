using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : MonoBehaviour
{
	//States
	bool isFacingRight = true;
	//Caches
	Player player;
    // Start is called before the first frame update
    void Start()
    {
		player = FindObjectOfType<Player>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x < transform.position.x && isFacingRight)
		{
			Flip();
			isFacingRight = false;
		}
		else if(player.transform.position.x > transform.position.x && !isFacingRight)
		{
			Flip();
			isFacingRight = true;
		}
    }

	private void Flip()
	{
		transform.localScale = new Vector2(transform.localScale.x * -1, 1f);
	}
}
