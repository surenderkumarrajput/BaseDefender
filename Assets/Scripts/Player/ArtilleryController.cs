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
    public Vector2 dir,Crosshairdir;

    public int BulletCount;
    public int MaxBulletcount;

    public float elapsedTime;
    public float TimebtwBullets;

    public Transform effectPos;
    public Transform crosshair;

    [HideInInspector]
    public bool Reloading=false;

    Rigidbody2D rb;

    Touch touch;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        BulletCount = MaxBulletcount;
        Reloadingtext.SetActive(false);
    }

    void Update()
    {
        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                pos = Camera.main.ScreenToWorldPoint(touch.position);
            }
        }
        crosshair.position = pos;
        dir = pos - rb.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angle;
        if (Reloading && BulletCount <= 0)
        {
            return;
        }
    
        else if(BulletCount<=0)
        {
            StartCoroutine(Reload());
        }
    }
    public void Shoot()
    {
        if(BulletCount>0)
        {
            FindObjectOfType<AudioManager>().Play("Attack");
            Instantiate(bullet, transform.position, Quaternion.identity);
            BulletCount--;
        }
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
        if(powerup.powerCount>0)
        {
            Instantiate(PowerupEffect, effectPos.position, Quaternion.identity);
            Instantiate(PowerupBullet, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Powerup");
            powerup.decresePowerCount(1);
        }
    }
}

