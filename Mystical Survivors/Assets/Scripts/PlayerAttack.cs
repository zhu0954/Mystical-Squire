using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform firePoint;

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
            Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
        }
        
    }
}
