using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 dir;
    public float speed;
    private void Start()
    {
        dir=FindObjectOfType<ArtilleryController>().dir;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    void Update()
    {
        transform.Translate(dir*speed*Time.deltaTime);
    }
}
