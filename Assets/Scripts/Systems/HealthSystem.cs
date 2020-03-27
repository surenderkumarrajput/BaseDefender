using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [HideInInspector]
    public float Health;
    public float Maxhealth;

    public void Start()
    {
        Health = Maxhealth;
    }
    public void HealthDecrese(float Damage)
    {
        Health -= Damage;
    }
    public void HealthIncrease(float Health)
    {
        this.Health += Health;
    }
}
