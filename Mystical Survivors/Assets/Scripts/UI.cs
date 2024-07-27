using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Slider healthBar; // Reference to the Slider component
    public Slider XPBar;
    public PlayerStats playerStats; // Reference to the PlayerStats component

    void Start()
    {
        if (playerStats == null)
        {
            playerStats = FindObjectOfType<PlayerStats>(); // Automatically find PlayerStats if not set
        }

        if (healthBar != null && playerStats != null)
        {
            healthBar.maxValue = playerStats.playerMaxHealth; // Set the max value of the slider
            healthBar.value = playerStats.playerHealth; // Set the current value of the slider
        }

          if (XPBar != null && playerStats != null)
        {
             // Set the max value of the slider
            XPBar.value = playerStats.playerXP; // Set the current value of the slider
        }
    }

    void Update()
    {
        if (healthBar != null && playerStats != null)
        {
            healthBar.value = playerStats.playerHealth; // Update the slider value based on current health
        }
         if (XPBar != null && playerStats != null)
        {
            XPBar.maxValue = playerStats.XPForNextLevel;
            XPBar.value = playerStats.playerXP; // Update the slider value based on current XP
        }
    }
}