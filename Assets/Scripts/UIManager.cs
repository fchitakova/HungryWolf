using UnityEngine;

public class UIManager : MonoBehaviour
{

   [SerializeField]
   private HealthBar healthBar;

    public void OnEnable()
    {
        PlayerHealth.OnHealthChange += UpdateHealthBar;
        PlayerController.OnPlayerDead += EndGame;
    }

    private void UpdateHealthBar(int health)
    {
        healthBar.SetHealth(health);
        Debug.Log(health);
    }

    private void EndGame()
    {
        //show game over
        //show restart
    }

    public void OnDisable()
    {
        PlayerHealth.OnHealthChange -= UpdateHealthBar;
        PlayerController.OnPlayerDead -= EndGame;
    }
}
