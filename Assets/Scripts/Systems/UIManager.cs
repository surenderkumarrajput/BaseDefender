using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public GameObject ShopPanel;
    Wall Player;
    public ArtilleryController artilleryController;
    public TextMeshProUGUI MoneyUI;
    public TextMeshProUGUI Powercount;
    public TextMeshProUGUI BulletCount;
    void Start()
    {
        ShopPanel.SetActive(false);
        Player = GameObject.FindGameObjectWithTag("Wall").GetComponent<Wall>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            bool isactive = ShopPanel.activeSelf;
            ShopPanel.SetActive(!isactive);
        }
        if(Player==null)
        {
            return;
        }
        else
        {
            MoneyUI.text = Player.GetComponent<Money>().MoneyCount.ToString();
            Powercount.text = "x" + Player.GetComponent<Powerup>().powerCount.ToString();
            BulletCount.text = "x" +artilleryController.BulletCount.ToString();
        }
    }
}
