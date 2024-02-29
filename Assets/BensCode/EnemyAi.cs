using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAi : MonoBehaviour
{
    public int maxHealth = 100;
    public int healingAmount = 20;
    public int halfHealthThreshold = 50; // Half of max health
    public Slider enemyHealthSlider; // Reference to the enemy health slider UI

    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthSlider();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }

        // Check if health is below the threshold for healing
        if (currentHealth <= halfHealthThreshold)
        {
            PerformHeal();
        }
    }

    void TakeDamage(int damage)
    {
        // Reduce enemy health when taking damage
        currentHealth -= damage;

        // Ensure health doesn't go below zero
        currentHealth = Mathf.Max(currentHealth, 0);

        Debug.Log("Enemy took " + damage + " damage. Current health: " + currentHealth);
        UpdateHealthSlider();
    }

    void PerformHeal()
    {
        // Simulate healing (for example, when triggered by certain conditions)
        // Replace this with your actual healing logic
        currentHealth += healingAmount;

        // Ensure health doesn't exceed the maximum health
        currentHealth = Mathf.Min(currentHealth, maxHealth);

        Debug.Log("Enemy performed healing! Current health: " + currentHealth);
        UpdateHealthSlider();
    }

    void UpdateHealthSlider()
    {
        // Update the enemy health slider value
        enemyHealthSlider.value = (float)currentHealth / maxHealth;
    }
}
