using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float enemySpeed = 3.0f;
    private Rigidbody2D rb;
    public int damageAmount = 10;
    public int enemyHealth = 20;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public float flashDuration = 1.0f;
    public List<GameObject> weaponDrops;
    public float dropChance = 0.2f;
    public Transform dropPosition;
    private Animator animator;
    private bool isDead = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        if(spriteRenderer != null){
            originalColor = spriteRenderer.color;
        }
    }

    public void TakeDamage(int damage){
        if(isDead) return;
    
        enemyHealth -= damage;
        StartCoroutine(FlashRed());
        if(enemyHealth <= 0){
            Die();
        }
    }

    void Die(){
        if (weaponDrops.Count > 0 && Random.value < dropChance){
            DropWeapon();
        }
        isDead = true;
        rb.linearVelocity = Vector2.zero;
        animator.SetBool("EnemyDeath", true); // Trigger death animation
        StartCoroutine(DestroyAfterDeathAnimation());
        GameManager.Instance.AddScore(15);
    }
    void DropWeapon(){
        int randomIndex = Random.Range(0, weaponDrops.Count);
        Instantiate(weaponDrops[randomIndex], dropPosition.position, Quaternion.identity);
    }

    private IEnumerator DestroyAfterDeathAnimation(){
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length); // Wait for the death animation to finish
        Destroy(gameObject);
    }

    private IEnumerator FlashRed(){
        if(spriteRenderer != null){
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(flashDuration);
            spriteRenderer.color = originalColor;
        }
    }

    void FixedUpdate()
    {
        if (player != null && !isDead)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * enemySpeed;
            if (direction.x < 0)
        {
            spriteRenderer.flipX = true; // Flip when moving left
        }
        else if (direction.x > 0)
        {
            spriteRenderer.flipX = false; // Reset when moving right
        }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
{
    Debug.Log($"💥 Enemy collided with: {collision.gameObject.name}");

    if (collision.gameObject.CompareTag("Player"))
    {
        Debug.Log("⚔️ Enemy hit the Player!");

        PlayerHealthScript playerHealth = collision.gameObject.GetComponent<PlayerHealthScript>();
        if(playerHealth != null)
        {
            Debug.Log($"🩸 Player took {damageAmount} damage.");
            playerHealth.TakeDamage(damageAmount);
        }
        else
        {
            Debug.Log("❌ PlayerHealthScript NOT found on Player.");
        }
    }
}

}
