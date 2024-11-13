using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float playerHealth = 100f;
    public float playerMaxHealth = 100f;
    public int playerXP;
    public int Level;
    public int XPForNextLevel = 5;
    public int XPIncreasePerLevel = 5;
    public int Bonus;
    public int additionalProjectiles = 0;

    // Add these properties
    public float damage = 10f; // Default damage value
    public float speed = 5f;   // Default speed value
    
    public UpgradeManager upgradeManager;
    public GameObject upgradePanel; // UI Panel to display upgrades
    public Button[] upgradeButtons; // Buttons to select upgrades


    void Start()
    {
        // Initialization code
        upgradePanel.SetActive(false);
    }

    void Update()
    {
        if (playerXP >= XPForNextLevel)
        {
            LevelUp();
        }

        if (playerHealth <= 0)
        {
            Debug.Log("YOU DIE!!");
            Die();
        }
    }

    public void TakeDamage(float damageAmount)
    {
        playerHealth -= damageAmount;
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
        if (collider.gameObject.CompareTag("BlueXP"))
        {
            playerXP += 10;
            Destroy(collider.gameObject);
        }
        else if (collider.gameObject.CompareTag("PurpleXP"))
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
        Bonus = playerXP - XPForNextLevel;
        XPForNextLevel += XPIncreasePerLevel;
        playerXP = Bonus;

        ShowUpgradeOptions();
    }
    
    void ShowUpgradeOptions()
    {
        upgradePanel.SetActive(true);
        List<Upgrade> selectedUpgrades = new List<Upgrade>();
        while (selectedUpgrades.Count < 3)
        {
            Upgrade randomUpgrade = upgradeManager.allUpgrades[Random.Range(0, upgradeManager.allUpgrades.Count)];
            if (!selectedUpgrades.Contains(randomUpgrade))
            {
                selectedUpgrades.Add(randomUpgrade);
            }
        }

        for (int i = 0; i < upgradeButtons.Length; i++)
        {
            if (i < selectedUpgrades.Count)
            {
                Upgrade upgrade = selectedUpgrades[i];
                upgradeButtons[i].GetComponentInChildren<Text>().text = upgrade.Name;
                upgradeButtons[i].onClick.RemoveAllListeners();
                upgradeButtons[i].onClick.AddListener(() => ApplyUpgrade(upgrade));
            }
            else
            {
                upgradeButtons[i].gameObject.SetActive(false);
            }
        }
    }
    
    void ApplyUpgrade(Upgrade upgrade)
    {
        upgrade.ApplyEffect(this);
        // Hide the upgrade panel after applying the upgrade
        upgradePanel.SetActive(false);
    }


}