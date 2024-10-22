using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform firePoint;
    public PlayerStats playerStats;

    public float attackSpeed = 3f;  // This will be the current attack speed countdown
    public float resetAttackSpeed;  // This stores the original (or dynamically adjusted) attack speed

    void Start()
    {
        resetAttackSpeed = attackSpeed; // Set the reset value to the initial attack speed
    }

    void Update()
    {
        attackSpeed -= Time.deltaTime;
        if (attackSpeed <= 0)
        {
            Shoot();
            attackSpeed = resetAttackSpeed;  // Reset the attack speed timer
        }
    }

    void Shoot()
    {
        if (fireballPrefab != null && firePoint != null)
        {
            // Calculate the number of projectiles based on the player's level
            int numberOfProjectiles = Mathf.Max(1, playerStats.Level);

            // Calculate the angle between each projectile
            float angleStep = 30f; // Change this value to adjust the spread of projectiles
            float angleOffset = -(numberOfProjectiles - 1) * angleStep / 2;

            for (int i = 0; i < numberOfProjectiles; i++)
            {
                // Calculate the rotation for each projectile
                Quaternion rotation = firePoint.rotation * Quaternion.Euler(0, 0, angleOffset + angleStep * i);

                // Instantiate the projectile with the calculated rotation
                Instantiate(fireballPrefab, firePoint.position, rotation);
            }
        }
    }

    // Method to dynamically change the attack speed during gameplay
    public void SetAttackSpeed(float newAttackSpeed)
    {
        resetAttackSpeed = newAttackSpeed;  // This changes the reset value dynamically
        attackSpeed = newAttackSpeed;  // Also immediately affects the current attack timer if needed
    }
}