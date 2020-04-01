using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;

public class ArtilleryController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject PowerupBullet;
    public GameObject PowerupEffect;
    public GameObject Reloadingtext;
    public Powerup powerup;
    Vector2 pos;
    [HideInInspector]
    public Vector2 dir;

    public int BulletCount;
    public int MaxBulletcount;

    public float elapsedTime;
    public float TimebtwBullets;

    public Transform effectPos;

    [HideInInspector]
    public bool Reloading=false;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        BulletCount = MaxBulletcount;
        Reloadingtext.SetActive(false);
    }

    void Update()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir = pos - rb.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angle;
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (Input.GetMouseButtonDown(1) && powerup.powerCount > 0)
        {
            ShootPowerup();
        }
        
        if (Reloading && BulletCount <= 0)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0) && BulletCount > 0 )
        {
            Shoot();
        }
        else if(BulletCount<=0)
        {
            StartCoroutine(Reload());
        }
    }
    public void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
        BulletCount--;
    }
    IEnumerator Reload()
    {
        Reloadingtext.SetActive(true);
        Reloading = true;
        yield return new WaitForSeconds(5f);
        BulletCount = MaxBulletcount;
        Reloadingtext.SetActive(false);
        Reloading = false;
    }
    public void ShootPowerup()
    {
        Instantiate(PowerupEffect, effectPos.position, Quaternion.identity);
        Instantiate(PowerupBullet, transform.position, Quaternion.identity);
        powerup.decresePowerCount(1);
    }
}

