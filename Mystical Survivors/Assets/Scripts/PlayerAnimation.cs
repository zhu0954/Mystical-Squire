using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void UpdateAnimation(Vector2 movement)
    {
        // Set animator parameters
    
        animator.SetBool("IsMoving", movement != Vector2.zero);

        // Flip sprite based on movement direction
        if (movement.x < 0)
        {
            spriteRenderer.flipX = true; // Flip the sprite to face left
        }
        else if (movement.x > 0)
        {
            spriteRenderer.flipX = false; // Flip the sprite to face right
        }
    }
}
