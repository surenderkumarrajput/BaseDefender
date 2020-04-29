using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public float damage;

    public GameObject BulletEffect;
  
    void Start()
    {
         damage=FindObjectOfType<EnemyController>().Enemytypes.AttackDamage;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Instantiate(BulletEffect, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject,0.1f);
        }
    }
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        Destroy(gameObject, 4f);
    }
}
