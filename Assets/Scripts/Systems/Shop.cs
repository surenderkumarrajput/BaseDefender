using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    GameObject PlayerMoney;
    private void Start()
    {
        PlayerMoney = GameObject.FindGameObjectWithTag("Wall");
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

   
}
