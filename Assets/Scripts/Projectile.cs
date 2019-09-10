using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Player player;
    [SerializeField] float speed = 20f, heightMin = 5f, heightMax = 9f;
    [SerializeField] int dmg = 10;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        bool facingLeft = player.GetFacingLeft();
        if(!player.GetHasBow())
        {
            if (!facingLeft) { GetComponent<Rigidbody2D>().velocity = new Vector2(speed, Random.Range(heightMin, heightMax)); }
            else { GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, Random.Range(heightMin, heightMax)); }
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            if(!facingLeft) { GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0); }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
                transform.Rotate(0f, 180f, 0f);
                //transform.GetChild(1).transform.Rotate(0f, 180f, 0f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" && gameObject.name != "Bomb(Clone)")
        {
            collision.gameObject.GetComponent<Enemy>().ReceiveDamage(dmg);
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(LetItDie());
        }
    }

    private IEnumerator LetItDie()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
