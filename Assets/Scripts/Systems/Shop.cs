using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    GameObject PlayerMoney,Trigger;
    private void Start()
    {
        PlayerMoney = GameObject.FindGameObjectWithTag("Wall");
        Trigger = GameObject.FindGameObjectWithTag("Trigger");
    }
    public void HealthBuy(int Cost)
    {
        if (PlayerMoney.GetComponent<Money>().MoneyCount==Cost || PlayerMoney.GetComponent<Money>().MoneyCount > Cost)
        {
            if (PlayerMoney.GetComponent<HealthSystem>().Health< PlayerMoney.GetComponent<HealthSystem>().Maxhealth)
            {
                PlayerMoney.GetComponent<HealthSystem>().Health = PlayerMoney.GetComponent<HealthSystem>().Maxhealth;
                PlayerMoney.GetComponent<Money>().MoneyCount -= Cost;
            }
            else
            {
                return;
            }
        }
    }
    public void PowerupBuy(int Cost)
    {
        if (PlayerMoney.GetComponent<Money>().MoneyCount == Cost || PlayerMoney.GetComponent<Money>().MoneyCount > Cost)
        {
            PlayerMoney.GetComponent<Powerup>().IncreasePowerCount(1);
            PlayerMoney.GetComponent<Money>().MoneyCount -= Cost;
        }
        else
        {
            return;
        }
    }
    public void BulletsBuy(int Cost)
    {
        if (PlayerMoney.GetComponent<Money>().MoneyCount == Cost || PlayerMoney.GetComponent<Money>().MoneyCount > Cost && Trigger.GetComponent<ArtilleryController>().BulletCount < Trigger.GetComponent<ArtilleryController>().MaxBulletcount)
        {
            Trigger.GetComponent<ArtilleryController>().BulletCount = Trigger.GetComponent<ArtilleryController>().MaxBulletcount;
            Trigger.GetComponent<ArtilleryController>().Reloadingtext.SetActive(false);
            Trigger.GetComponent<ArtilleryController>().Reloading = false;
            PlayerMoney.GetComponent<Money>().MoneyCount -= Cost;
        }
        else
        {
            return;
        }
    }
}
