using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float moveSpeed = 3f;
    public int maxHealth = 20;
    private int currentHealth;
    public float cooldown = 100f;
    private Transform player;
    private Rigidbody2D rb;
    private PlayerStats P;
    private SpriteRenderer spriteRenderer;



    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            P = playerObject.GetComponent<PlayerStats>();
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;


    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;

            // Flip sprite based on movement direction
            if (direction.x < 0)
            {
                spriteRenderer.flipX = true; // Flip the sprite to face left
            }
            else if (direction.x > 0)
            {
                spriteRenderer.flipX = false; // Flip the sprite to face right
            }
        }
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // You can add more effects here like playing an animation or dropping loot
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (cooldown < 0)
            {
                P.playerHealth -= 10;
                Debug.Log("ow");
                cooldown = 1;
            }
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (cooldown < 0)
            {
                P.playerHealth -= 10;
                Debug.Log("owie");
                cooldown = 1;
            }
        }
    }
}
