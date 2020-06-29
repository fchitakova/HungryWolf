
using UnityEngine;

public class PlayerHealth
{
    private const int maxHealth = 100;

    private int currentHealth;

    public PlayerHealth()
    {
        currentHealth = maxHealth;
    }

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    
}
