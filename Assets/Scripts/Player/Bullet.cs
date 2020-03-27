using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 dir;

    public float speed;
    public float Damage;

    public GameObject DestroyEffect;

    private void Start()
    {
        dir=FindObjectOfType<ArtilleryController>().dir;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(DestroyEffect, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject, 0.01f);
        }
    }
    
    void Update()
    {
        transform.Translate(dir*speed*Time.deltaTime);
        Destroy(gameObject,6f);
    }
}
