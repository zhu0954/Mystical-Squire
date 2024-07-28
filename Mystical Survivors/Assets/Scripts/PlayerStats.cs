using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float playerHealth = 100f;
    public float playerMaxHealth = 100f;
    public int playerXP;
    public int Level;
    public float XPForNextLevel = 5f;
    public int XPIncreasePerLevel = 5;
    public int Bonus;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerXP >= XPForNextLevel )
        {
            LevelUp();
        }

        if(playerHealth <= 0)
        {
            Debug.Log("YOU DIE!!");
            Die();
        }
    }


    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Handle player death (e.g., respawn, game over screen)
        Debug.Log("Player died");
    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("BlueXP"))
        {
            playerXP += 10;
            Destroy(collider.gameObject);
        }
        else if(collider.gameObject.CompareTag("PurpleXP"))
        {
            playerXP += 25;
            Destroy(collider.gameObject);
        }
        else if (collider.gameObject.CompareTag("YellowXP"))
        {
            playerXP += 50;
            Destroy(collider.gameObject);
        }      
    }

    void LevelUp()
    {
        Level++;
        Debug.Log("LEVEL UP!");
        Bonus = playerXP - (int)XPForNextLevel;
        XPForNextLevel *= 2.5f;
        playerXP = 0;
        playerXP += Bonus;
    }
}