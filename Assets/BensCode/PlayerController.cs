using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 100;
    public int damagePerBasicAttack = 10;
    public int healingAmount = 20;
    public int manaCostForHeal = 10;
    public Slider playerHealthSlider; // Reference to the player health slider UI
    public Slider playerManaSlider; // Reference to the player mana slider UI

    public int currentHealth;
    public int currentMana;

    void Start()
    {
        currentHealth = maxHealth;
        currentMana = 60; // Assuming player starts with 60 mana
        UpdateHealthSlider();
    }

    void Update()
    {
        // Check for user input (left mouse button for basic attack)
        if (Input.GetMouseButtonDown(0))
        {
            PerformBasicAttack();
        }

        // Check for user input ('H' for healing)
        if (Input.GetKeyDown(KeyCode.H))
        {
            PerformHeal();
        }

        UpdateHealthSlider(); 
        UpdateManaSlider();
    }

    public void PerformBasicAttack()
    {
        // Deal damage to an enemy (For example, reduce enemy's health)
        int enemyHealth = 100; // Example enemy health
        enemyHealth -= damagePerBasicAttack;

        Debug.Log("Performed Basic Attack! Enemy health: " + enemyHealth);
    }

    public void PerformHeal()
    {
        if (currentMana >= manaCostForHeal)
        {
            // Deduct mana for the healing
            currentMana -= manaCostForHeal;

            // Heal the player
            currentHealth += healingAmount;

            // Ensure health doesn't exceed the maximum health
            currentHealth = Mathf.Min(currentHealth, maxHealth);

            Debug.Log("Performed Healing! Current health: " + currentHealth);
            //UpdateHealthSlider(); Commenting this out for now since the function is in Update, might change later idk
        }
        else
        {
            Debug.Log("Not enough mana to perform Healing!");
        }
    }

    void UpdateHealthSlider()
    {
        // Update the player health slider value
        playerHealthSlider.value = (float)currentHealth / maxHealth;
    }

    void UpdateManaSlider()
    {
        // Update the player health slider value
        playerManaSlider.value = (float)currentMana / 60;
    }
}
