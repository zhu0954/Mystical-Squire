using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform firePoint;
    public PlayerStats playerStats;

    private float time = 3f;

    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Shoot();
            time = 3f; 
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

}
