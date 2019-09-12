using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Store : MonoBehaviour
{
    CashFlow money;
    Inventory inventory;
    [SerializeField]int price = 0;
    [SerializeField] GameObject soldOutSign, bombButton;
    TextMeshProUGUI text;
    Player player;
    bool keyPurchased = false;
    bool activateSoldOut = false;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        money = FindObjectOfType<CashFlow>();
        player = FindObjectOfType<Player>();
        inventory = FindObjectOfType<Inventory>();
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
        if(gameObject.name == "Bomb Price" && inventory.GetBombs() >= 5)
        {
            soldOutSign.SetActive(true);
        }
        else if(gameObject.name == "Bomb Price" && inventory.GetBombs() < 5)
        {
            soldOutSign.SetActive(false);
        }
        
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


    public void PurchaseKey()
    {
        if(!keyPurchased && money.CheckMoney(price))
        {
            money.SubMoney(price);
            keyPurchased = true;
            Debug.Log("bought");
            soldOutSign.SetActive(true);
            GiveItem();
        }
    }

    public void PuchaseBombs()
    {
        if(money.CheckMoney(price) && inventory.GetBombs() < 5)
        {
            money.SubMoney(price);
            GiveItem();
        }
    }

    private void GiveItem()
    {
        if(gameObject.name == "Key Price")
        {
            player.PickupItem("Door Key(Clone)");
        }
        else if(gameObject.name == "Bomb Price")
        {
            player.PickupItem("BombItem(Clone)");
        }
    }

    public void KeyPurchased()
    {
        bombButton.SetActive(true);
    }
}
