using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider healthSlider;  // Reference to the UI Slider for health.
    public GameObject enemy;    // Reference to the enemy GameObject.

    private void Start()
    {
        healthSlider.value = 1;
    }

    private void Update()
    {
        // Make sure the health bar follows the enemy's position.
        if (enemy != null)
        {
            Vector3 enemyScreenPos = Camera.main.WorldToScreenPoint(enemy.transform.position);
            healthSlider.transform.position = enemyScreenPos + new Vector3(10, 50, 0); // Adjust the offset as needed.
        }
    }

    // Function to update the health bar based on enemy's health.
    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        if (healthSlider != null)
        {
            // Calculate the health percentage.
            float healthPercentage = currentHealth/maxHealth;
            healthSlider.value = healthPercentage;
        }
    }
}
