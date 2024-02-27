using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 100;
    public int maxMana = 40;
    public int damagePerBasicAttack = 6;
    public int healingAmount = 20;
    public int manaCostForHeal = 10;

    private int currentHealth;
    private int currentMana;

    void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
    }

    void Update()
    {
        // Check for user input (left mouse button for basic attack just to make it easy for players can change to a button on the UI in a bit)
        if (Input.GetMouseButtonDown(0))
        {
            PerformBasicAttack();
        }

        // Check for user input ('H' for healing same as attack)
        if (Input.GetKeyDown(KeyCode.H))
        {
            PerformHeal();
        }
    }

    void PerformBasicAttack()
    {
        if (currentMana >= manaCostForHeal)
        {
            // Deduct mana for the basic attack
            currentMana -= manaCostForHeal;


            int enemyHealth = 100; // Example enemy health
            enemyHealth -= damagePerBasicAttack;

            Debug.Log("Performed Basic Attack! Enemy health: " + enemyHealth);
        }
        else
        {
            Debug.Log("Not enough mana to perform Basic Attack!");
        }
    }

    void PerformHeal()
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
