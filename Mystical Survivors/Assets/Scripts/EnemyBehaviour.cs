using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float moveSpeed = 3f;
    public int maxHealth = 20;
    private int currentHealth;
    public float cooldown = 1f;
    private Transform player;
    private Rigidbody2D rb;
    private PlayerStats playerStats;
    private SpriteRenderer spriteRenderer;

    // Prefabs for different rarity drops
    public GameObject blueDropPrefab;
    public GameObject purpleDropPrefab;
    public GameObject yellowDropPrefab;

    // Rarity chances (adjust these values based on how common/rare you want each item)
    [Range(0, 1)] public float blueDropChance = 0.6f;
    [Range(0, 1)] public float purpleDropChance = 0.3f;
    [Range(0, 1)] public float yellowDropChance = 0.1f;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            playerStats = playerObject.GetComponent<PlayerStats>();
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
        DropItem();  // Call the method to drop an item
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (cooldown <= 0)
            {
                playerStats.TakeDamage(10); // Use the TakeDamage function from PlayerStats
                Debug.Log("Player hit by enemy");
                cooldown = 1;
            }
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (cooldown <= 0)
            {
                playerStats.TakeDamage(10); // Use the TakeDamage function from PlayerStats
                Debug.Log("Player hit by enemy");
                cooldown = 1;
            }
        }
    }

    // Method to drop an item based on rarity
    void DropItem()
    {
        float randomValue = Random.Range(0f, 1f); // Generate a random value between 0 and 1

        if (randomValue <= yellowDropChance)
        {
            Instantiate(yellowDropPrefab, transform.position, Quaternion.identity); // Drop yellow item
        }
        else if (randomValue <= purpleDropChance + yellowDropChance)
        {
            Instantiate(purpleDropPrefab, transform.position, Quaternion.identity); // Drop purple item
        }
        else
        {
            Instantiate(blueDropPrefab, transform.position, Quaternion.identity); // Drop blue item
        }
    }
}
