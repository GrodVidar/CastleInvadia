using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Player player;
    Coin coin;
    int value = 0;

    void Start()
    {
        if(gameObject.name == "Coin(Clone)")
        {
            coin = GetComponent<Coin>();
            value = coin.GetValue();
        }
        player = FindObjectOfType<Player>();
        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-5f, 5f), Random.Range(5f, 9f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(gameObject.name == "Coin(Clone)")
            {
                coin.PlaySound();
                player.PickupItem(gameObject.name, value);
            }
            else if(gameObject.name == "BombItem(Clone)")
			{
				player.PickupItem(gameObject.name);
			}
			else
            {
                player.PickupItem(gameObject.name);
            }
            Destroy(gameObject);
        }                
    }
}
