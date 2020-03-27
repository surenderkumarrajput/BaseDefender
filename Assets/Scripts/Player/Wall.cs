using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Wall : MonoBehaviour
{
    private HealthSystem HealthSystem;

    public Image HealthSlider;

    public delegate void Playerdeath();
    public static Playerdeath playerdeath;

    void Start()
    {
        HealthSystem = GetComponent<HealthSystem>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("EnemyBullet"))
        {
            var Damage = collision.gameObject.GetComponent<EnemyBullet>().damage;
            HealthSystem.HealthDecrese(Damage);
            HealthSystem.Health = Mathf.Clamp(HealthSystem.Health, 0, 100);
        }
    }
    private void Update()
    {
        if(HealthSystem.Health==0)
        {
            playerdeath();
            Destroy(gameObject);
        }
        HealthSlider.fillAmount = HealthSystem.Health / 100;
    }
}
