using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
public float playerHealth = 100f;
public float playerMaxHealth = 100f;
public int playerXP;
public int Level;
public int XPForNextLevel = 5;
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
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("BlueXP"))
        {
            playerXP += 1;
            Destroy(collider.gameObject);
        }
        else if(collider.gameObject.CompareTag("PurpleXP"))
        {
            playerXP += 5;
            Destroy(collider.gameObject);
        }
        else if(collider.gameObject.CompareTag("YellowXP"))
            playerXP += 15;
            Destroy(collider.gameObject);
    }

    void LevelUp()
    {
        Level++;
        Debug.Log("LEVEL UP!");
        Bonus = playerXP - XPForNextLevel;
         XPForNextLevel += 5;
        playerXP = 0;
        playerXP += Bonus;
    }
}