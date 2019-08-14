using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] Sprite closed, open;
    [SerializeField] GameObject item;
    SpriteRenderer myRenderer;
    bool activated = false;
    void Start()
    {
       myRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !activated)
        {
            myRenderer.sprite = open;
            SpitOutItem();
            activated = true;
        }
    }

    private void SpitOutItem()
    {
        Instantiate(item, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        //item.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-50f, 50f), Random.Range(50f, 59f));
    }
}
