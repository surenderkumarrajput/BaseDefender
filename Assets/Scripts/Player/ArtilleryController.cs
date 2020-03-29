using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtilleryController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject PowerupBullet;

    public Powerup powerup;
    Vector2 pos;
    [HideInInspector]
    public Vector2 dir;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir = pos - rb.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angle;
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if(Input.GetMouseButtonDown(1)&&powerup.powerCount>0)
        {
            ShootPowerup();
        }
    }
    public void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
    public void ShootPowerup()
    {
        Instantiate(PowerupBullet, transform.position, Quaternion.identity);
        powerup.decresePowerCount(1);
    }
}

