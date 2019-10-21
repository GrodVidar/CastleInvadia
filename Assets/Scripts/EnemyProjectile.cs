using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] GameObject shooter;
    [SerializeField] bool throwable;
    [SerializeField] float speed = 20f, heightMin = 5f, heightMax = 9f;
    Player player;
    Rigidbody2D myRigidbody;
    bool isGoingLeft;
    bool isLethal = true;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
        if(player.transform.position.x < transform.position.x)
        {
            isGoingLeft = true;
        }
        else
        {
            isGoingLeft = false;
            transform.Rotate(0f, 180f, 0f);
        }
        if(throwable)
        {
            if(isGoingLeft) { GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, Random.Range(heightMin, heightMax)); }
            else { GetComponent<Rigidbody2D>().velocity = new Vector2(speed, Random.Range(heightMin, heightMax)); }
        }
    }

    private void Update()
    {
        if(isGoingLeft && isLethal)
        {
            transform.Rotate(Vector3.forward * 900 * Time.deltaTime);
        }
        else if(!isGoingLeft && isLethal)
        {
            transform.Rotate(Vector3.forward * 900 * Time.deltaTime);
        }
        else
        {
            myRigidbody.velocity = new Vector2(0,0);
            transform.Rotate(Vector3.forward * 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            isLethal = false;
            StartCoroutine(LetItDie());
        }
        else if(collision.gameObject.tag == "Player" && isLethal)
        {
            player.ReceiveDamage(10, !isGoingLeft);
            Destroy(gameObject);
        }
    }

    private IEnumerator LetItDie()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }

}
