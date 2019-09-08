using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreMoney : MonoBehaviour
{
    CashFlow money;
    TextMeshProUGUI text;
    void Start()
    {
        money = FindObjectOfType<CashFlow>();
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = money.GetMoney().ToString();
    }
}
