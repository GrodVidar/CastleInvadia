using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Sprite closedDoor, openDoor;
    SpriteRenderer myRenderer;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && Input.GetKeyDown("up") && player.GetHasDoorKey())
        {
            myRenderer.sprite = openDoor;
			FindObjectOfType<Level>().LoadNextLevel();
        }
    }

}
