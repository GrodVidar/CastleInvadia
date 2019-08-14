using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    //Caches
    Player player;

    //Configs
    [SerializeField] float knockUp = 20f;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.ApplyKnockUp(knockUp);
            player.RemoveHealth(10);
        }
    }
}
