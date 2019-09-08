using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Merchant : MonoBehaviour
{
    bool isTriggered = false;
    bool inShop = false;
    [SerializeField] GameObject store;
    [SerializeField] TextMeshPro text;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "Aye, Stranger! \n'ave a gander at me wares... ";
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.text = "Yes, plenty of gear from me ol' cell mates 'ere";
        isTriggered = true;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        isTriggered = false;
        text.text = "Farewell, Stranger!\nMay Lady Luck be on yer side!";
    }

    private void Update()
    {
        if(isTriggered && Input.GetKeyDown("up"))
        {
            Time.timeScale = 0f;
            store.SetActive(true);
            inShop = true;
        }
        if(inShop && Input.GetKeyDown("escape"))
        {
            ExitShop();
        }
    }

    public void ExitShop()
    {        
            Time.timeScale = 1f;
            store.SetActive(false);
    }
}
