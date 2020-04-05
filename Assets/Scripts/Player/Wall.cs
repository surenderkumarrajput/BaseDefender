using UnityEngine;
using UnityEngine.UI;

public class Wall : MonoBehaviour
{
    private HealthSystem HealthSystem;

    public Image HealthSlider;

    public GameObject Deatheffect;

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
        if (HealthSystem.Health==0)
        {
            playerdeath();
            FindObjectOfType<AudioManager>().Play("Blast");
            Instantiate(Deatheffect, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.01f);
            SceneChangeManager.instance.SceneChangeMethod("Lost");
        }
        HealthSlider.fillAmount = HealthSystem.Health / 100;
     
    }
}
