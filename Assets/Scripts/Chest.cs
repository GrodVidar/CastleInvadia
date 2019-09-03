using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] Sprite closed, open;
    [SerializeField] GameObject[] items;
    SpriteRenderer myRenderer;
    bool activated = false;
    void Start()
    {
       myRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
		if(activated)
		{
			myRenderer.sprite = open;
		}
		else
		{
			myRenderer.sprite = closed;
		}
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !activated)
        {
            SpitOutItem();
            activated = true;
        }
    }

    private void SpitOutItem()
    {
		foreach(GameObject item in items)
		{
			Instantiate(item, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
		}
        //item.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-50f, 50f), Random.Range(50f, 59f));
    }

	public void SetActivated(bool setter)
	{
		activated = setter;
	}
}
