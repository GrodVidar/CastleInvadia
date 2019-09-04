using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Merchant : MonoBehaviour
{
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
        if(Input.GetKeyDown("up"))
        {
            Debug.Log("Pause and open shop screen");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.text = "Farewell, Stranger!\nMay Lady Luck be on yer side!";
    }
}
