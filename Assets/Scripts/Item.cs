using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Player player;

    void Start()
    {
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
            player.PickupItem(gameObject.name);
            Destroy(gameObject);
        }
    }
}
