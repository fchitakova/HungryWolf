using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public const int MIN_HEALTH = 0;
    public const int MAX_HEALTH = 100;
    
    private int currentHealth;

    public static Action<int> OnHealthChange;

    public void Start()
    {
        currentHealth = MAX_HEALTH;
    }


    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if(currentHealth < MIN_HEALTH)
        {
            currentHealth = MIN_HEALTH;
        }
        OnHealthChange?.Invoke(currentHealth);
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth > MAX_HEALTH)
        {
            currentHealth = MAX_HEALTH;
        }
        OnHealthChange?.Invoke(currentHealth);
        
    }

    public bool IsPositive()
    {
        return currentHealth > MIN_HEALTH;
    }
    
}
