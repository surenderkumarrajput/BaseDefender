using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private HealthSystem HealthSystem;
    void Start()
    {
        HealthSystem = GetComponent<HealthSystem>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            var Damage = collision.gameObject.GetComponent<EnemyController>().Enemytypes.AttackDamage;
            HealthSystem.HealthDecrese(Damage);
        }
    }
    private void Update()
    {
    }
}
