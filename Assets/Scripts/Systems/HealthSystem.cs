using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float Health=100f;
    public void HealthDecrese(float Damage)
    {
        Health -= Damage;
    }
    public void HealthIncrease(float Health)
    {
        this.Health += Health;
    }
}
