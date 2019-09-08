using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Store : MonoBehaviour
{
    CashFlow money;
    int price;
    TextMeshProUGUI text;
    Player player;
    bool purchased = false;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        money = FindObjectOfType<CashFlow>();
        player = FindObjectOfType<Player>();
    }
    void Start()
    {
        if(gameObject.name == "Key Price")
        {
            SetKeyPrice();
        }
        text.text = price.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetKeyPrice()
    {
        if(money.GetMoney() < 5)
        {
            price = money.GetMoney();
        }
        else
        {
            price = 5;
        }
    }


    public void Purchase()
    {
        if(!purchased)
        {
            money.SubMoney(price);
            purchased = true;
            Debug.Log("bought");
            GiveItem();
        }
    }

    private void GiveItem()
    {
        if(gameObject.name == "Key Price")
        {
            player.PickupItem("Door Key(Clone)");
        }
    }
}
