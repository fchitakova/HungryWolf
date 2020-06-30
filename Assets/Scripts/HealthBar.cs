using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = slider.maxValue;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}