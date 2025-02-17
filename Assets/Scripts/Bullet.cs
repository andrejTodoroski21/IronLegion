using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletDamage = 5;
    public float lifetime = 2f;
    public float speed = 10f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime); // Clean up after lifetime expires
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyController enemy = collision.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(bulletDamage);
            }
            Destroy(gameObject); // Destroy bullet upon hitting an enemy
        }
    }
}
