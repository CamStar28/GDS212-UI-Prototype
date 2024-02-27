using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 100;
    public int damagePerBasicAttack = 6;
    public int healingAmount = 20;
    public int manaCostForHeal = 10;

    private int currentHealth;
    private int currentMana;

    void Start()
    {
        currentHealth = maxHealth;
        currentMana = 40; // Assuming player starts with 30 mana
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
    }

    public void PerformBasicAttack()
    {
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
        }
        else
        {
            Debug.Log("Not enough mana to perform Healing!");
        }
    }
}
