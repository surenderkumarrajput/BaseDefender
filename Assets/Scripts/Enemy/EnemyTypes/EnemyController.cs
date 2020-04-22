using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public EnemyType Enemytypes;
    private HealthSystem HealthSystem;

    private Animator anim;
    
    private Rigidbody2D rb;
    
    public float speed;
    public float radius;
    float MaxHealth;

    public int HitBonus;

    private bool canWalk;
    private bool isAlive;

    public LayerMask layerMask;

    public Transform Trigger;
    public Image HealthBar;

    Money PlayerMoney;

    public GameObject EnemyBullet;

    void Start()
    {
        Wall.playerdeath += AfterPlayerdead;
        PlayerMoney = GameObject.FindGameObjectWithTag("Wall").GetComponent<Money>();
        HealthSystem = GetComponent<HealthSystem>();
        HealthSystem.Health = Enemytypes.Health;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canWalk = true;
        isAlive = true;
        MaxHealth = HealthSystem.Health;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            var hitDamage=collision.gameObject.GetComponent<Bullet>().Damage;
            HealthSystem.HealthDecrese(hitDamage);
            Camera.main.GetComponent<Animator>().SetTrigger("Shake");
            HealthSystem.Health = Mathf.Clamp(HealthSystem.Health, 0, 100f);
            PlayerMoney.AddMoney(HitBonus);
        }
        if (collision.gameObject.CompareTag("PowerupBullet"))
        {
            var hitDamage = collision.gameObject.GetComponent<PowerUpbullet>().Damage;
            HealthSystem.HealthDecrese(hitDamage);
            Camera.main.GetComponent<Animator>().SetTrigger("Shake");
            HealthSystem.Health = Mathf.Clamp(HealthSystem.Health, 0, 100f);
            PlayerMoney.AddMoney(HitBonus);
        }
    }
    void Update()
    {
        HealthBar.fillAmount = HealthSystem.Health / MaxHealth;
        if(HealthSystem.Health==0)
        {
            StartCoroutine(EnemyDeath());
        }
        if(isAlive==true)
        {
            Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, radius, layerMask);
            foreach (var item in collider)
            {
                Attack();
            }
            if (canWalk == true)
            {
                Move();
            }
        }
        else
        {
            anim.ResetTrigger("Walk");
            anim.ResetTrigger("Attack");
        }
    }
    public void Move()
    {
        anim.SetTrigger("Walk");
        transform.Translate(Vector2.right*Time.deltaTime*speed);
    }
    public void Attack()
    {
        canWalk = false;
        anim.SetTrigger("Attack");
    }
    IEnumerator EnemyDeath()
    {
        isAlive = false;
        anim.SetTrigger("Death");
        yield return new WaitForSeconds(0.4f);
        FindObjectOfType<AudioManager>().Play("EnemyDeath");
        Destroy(gameObject,0.001f);
    }
    IEnumerator Shoot()
    {
        FindObjectOfType<AudioManager>().Play("SpitterAttack");
        Instantiate(EnemyBullet, Trigger.position, Quaternion.identity);
        yield return new WaitForSeconds(4f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    public void AfterPlayerdead()
    {
        isAlive = false;
    }
}
