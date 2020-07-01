using UnityEngine;

public class UIManager : MonoBehaviour
{

   [SerializeField]
   private HealthBar healthBar;

    public void OnEnable()
    {
        PlayerHealth.OnHealthChange += UpdateHealthBar;
    }

    private void UpdateHealthBar(int health)
    {
        healthBar.SetHealth(health);
        Debug.Log(health);
    }

    public void OnDisable()
    {
        PlayerHealth.OnHealthChange -= UpdateHealthBar;
    }
}
