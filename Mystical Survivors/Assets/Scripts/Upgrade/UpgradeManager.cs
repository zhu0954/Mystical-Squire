using UnityEngine;
using System.Collections.Generic;

public class UpgradeManager : MonoBehaviour
{
    public List<Upgrade> allUpgrades = new List<Upgrade>();

    void Start()
    {
        // Initialize available upgrades
        allUpgrades.Add(new Upgrade("Increase Health", "Increase max health by 20.", IncreaseHealth));
        allUpgrades.Add(new Upgrade("Increase Damage", "Increase damage by 5.", IncreaseDamage));
        allUpgrades.Add(new Upgrade("Increase Speed", "Increase movement speed by 1.", IncreaseSpeed));
        allUpgrades.Add(new Upgrade("Add Projectile", "adds one more fireball projectile", AddProjectile));
        // Add more upgrades as needed
    }

    void IncreaseHealth(PlayerStats player)
    {
        player.playerMaxHealth += 20;
        player.playerHealth = player.playerMaxHealth; // Heal to full health
    }

    void IncreaseDamage(PlayerStats player)
    {
        player.damage += 5;
    }

    void IncreaseSpeed(PlayerStats player)
    {
        player.speed += 1;
    }

    void AddProjectile(PlayerStats player)
    {
        player.additionalProjectiles += 1;
    }
}

