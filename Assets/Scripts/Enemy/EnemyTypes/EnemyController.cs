using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyType Enemytypes;
    private HealthSystem HealthSystem;

    private Animator anim;
    
    private Rigidbody2D rb;
    
    public float speed;
    
    void Start()
    {
        HealthSystem = GetComponent<HealthSystem>();
        HealthSystem.Health = Enemytypes.Health;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        Move();
      //  Destroy(gameObject, 5f);
      
       
    }
    public void Move()
    {
        transform.Translate(Vector2.right*Time.deltaTime*speed);
        anim.SetBool("Walk", true);
    }
}
