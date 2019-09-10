using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Sprite closedDoor, openDoor;
    CashFlow money;
    SpriteRenderer myRenderer;
    Player player;
    bool inside = false;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        money = FindObjectOfType<CashFlow>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inside && Input.GetKeyDown("up") && player.GetHasDoorKey())
        {
            PlayerPrefs.SetInt("Money", money.GetMoney());
            myRenderer.sprite = openDoor;
            FindObjectOfType<Level>().LoadNextLevel();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            inside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            inside = false;
        }
    }
}
