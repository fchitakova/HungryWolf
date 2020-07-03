using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class HealthBar : MonoBehaviour
{
    private Slider slider;

    public void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void OnEnable()
    {
        PlayerHealth.OnHealthChange += UpdateHealthBar;
    }

    private void UpdateHealthBar(int health)
    {
        slider.value = health;
    }

    public void OnDisable()
    {
        PlayerHealth.OnHealthChange -= UpdateHealthBar;
    }
}
