using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    bool isMovingRight = false;
    bool isHit = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player" && !isHit)
        {
            if(collision.transform.position.x > transform.position.x)
            {
                isMovingRight = true;
            }
            collision.GetComponent<Player>().ReceiveDamage(25, isMovingRight);
            isHit = true;
        }
        else if(collision.tag == "Enemy" && !isHit)
        {
            collision.GetComponent<Enemy>().ReceiveDamage(100);
            isHit = true;
        }
    }

    public void KillSelf()
    {
        Destroy(gameObject);
    }
}
