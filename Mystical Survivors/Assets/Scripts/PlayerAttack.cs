using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform firePoint;
    public PlayerStats playerStats;

    public float attackSpeed = 3f;  // Current attack speed countdown
    private float resetAttackSpeed; // Original or dynamically adjusted attack speed

    void Start()
    {
        resetAttackSpeed = attackSpeed; // Initialize the reset value
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
            // Calculate the total number of projectiles
            int baseProjectiles = 1; // Base number of projectiles
            int totalProjectiles = baseProjectiles + playerStats.additionalProjectiles;

            // Calculate the angle between each projectile
            float angleStep = 30f; // Adjust this value to change the spread
            float angleOffset = -(totalProjectiles - 1) * angleStep / 2;

            for (int i = 0; i < totalProjectiles; i++)
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
        resetAttackSpeed = newAttackSpeed;  // Update the reset value
        attackSpeed = newAttackSpeed;       // Immediately affect the current attack timer if needed
    }
}