using System.Collections;
using System.Collections.Generic;
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
}
