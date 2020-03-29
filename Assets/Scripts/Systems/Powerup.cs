using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public int powerCount=0;
    public void IncreasePowerCount(int Count)
    {
        powerCount += Count;
    }
    public void decresePowerCount(int count)
    {
        powerCount -= count;
    }
}
