using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Money : MonoBehaviour
{
    public int MoneyCount;
    void Start()
    {
        MoneyCount = 0;
    }
    private void Update()
    {
    }
    public void AddMoney(int Money)
    {
        MoneyCount += Money;
    }
  public void DecreseMoney(int Money)
    {
        MoneyCount -= Money;
    }
}
