using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public GameObject ShopPanel;
    Money PlayerMoney;
    public TextMeshProUGUI MoneyUI;
    void Start()
    {
        ShopPanel.SetActive(false);
        PlayerMoney = GameObject.FindGameObjectWithTag("Wall").GetComponent<Money>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            bool isactive = ShopPanel.activeSelf;
            ShopPanel.SetActive(!isactive);
        }
        MoneyUI.text = PlayerMoney.MoneyCount.ToString();
    }
}
