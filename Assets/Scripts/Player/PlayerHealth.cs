using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth;
    private int currentHealth;

    public static Action<int> OnHealthChange;

    public void Start()
    {
        maxHealth = 100;
        currentHealth = 100;

    }


    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
        OnHealthChange?.Invoke(currentHealth);
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        OnHealthChange?.Invoke(currentHealth);
    }
    
}
