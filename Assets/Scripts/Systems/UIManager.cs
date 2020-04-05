﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    Wall Player;
    public ArtilleryController artilleryController;
    public TextMeshProUGUI MoneyUI;
    public TextMeshProUGUI Powercount;
    public TextMeshProUGUI BulletCount;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Wall").GetComponent<Wall>();
    }

    void Update()
    {
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
    public void ActiveObject(GameObject gameObject)
    {
        bool isactive = gameObject.activeSelf;
        gameObject.SetActive(!isactive);
    }
}
