using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    private PlayerAnimation playerAnimation;
    private PlayerStats playerStats;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
        playerStats = GetComponent<PlayerStats>();

        if (playerStats == null)
        {
            Debug.LogError("PlayerStats component not found on the player object.");
        }
    }

    void Update()
    {
        // Get input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Update animation based on movement
        playerAnimation.UpdateAnimation(movement);
    }

    void FixedUpdate()
    {
        if (playerStats != null)
        {
            // Move the character using the speed from PlayerStats
            rb.MovePosition(rb.position + movement * playerStats.speed * Time.fixedDeltaTime);
        }
    }
}