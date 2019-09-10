using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BombAmount : MonoBehaviour
{
    TextMeshProUGUI text;
    Inventory inventory;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        inventory = FindObjectOfType<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = inventory.GetBombs().ToString();
    }
}
